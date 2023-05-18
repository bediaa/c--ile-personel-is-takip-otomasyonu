using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonelTakip
{
    public partial class FormEmployees : Form
    {
        public FormEmployees()
        {
            InitializeComponent();
        }


        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=personelTakipOtomanyonu; user ID=postgres; password=12345");
    
        void employees()
        {
            string sorgu = "Select employeid,name,surname,phonenumber,email,departmentid,salary from employees";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }
        
      

        private void BtnList_Click(object sender, EventArgs e)
        {
            employees();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into employees(employeid, name, surname,phoneNumber,email,departmentid,salary) values (@p1, @p2,@p3,@p4,@p5,@p6,@p7)", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(txtEmployeID.Text));
            komut1.Parameters.AddWithValue("@p2", txtName.Text);
            komut1.Parameters.AddWithValue("@p3", txtSurname.Text);
            komut1.Parameters.AddWithValue("@p4", txtPhoneNumber.Text);
            komut1.Parameters.AddWithValue("@p5", txtEmail.Text);
            komut1.Parameters.AddWithValue("@p6", int.Parse(txtDepartmentID.Text));
            komut1.Parameters.AddWithValue("@p7", int.Parse(txtSalary.Text));
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("successful");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete From employees where employeid=@p1 ", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(txtEmployeID.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("successful");
        }

        public void CalisanMaasiniGuncelle(int calisanId, decimal yeniMaas)
        {
          
                baglanti.Open();

                using (var command = new NpgsqlCommand("update_employee_salary", baglanti))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Depolama işlemine girdi parametrelerini ayarlayın
                    command.Parameters.AddWithValue("emp_id", calisanId);
                    command.Parameters.AddWithValue("new_salary", yeniMaas);

                    // Depolama işlemini çalıştırın
                    command.ExecuteNonQuery();
                }
            baglanti.Close();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            baglanti.Open();


            NpgsqlCommand komut3 = new NpgsqlCommand("update employees set name=@p1, surname=@p2, phonenumber=@p3, email=@p4,departmentid=@p5,salary=@p6 where employeid=@p7", baglanti);
            komut3.Parameters.AddWithValue("@p7", int.Parse(txtEmployeID.Text));
            komut3.Parameters.AddWithValue("@p1", txtName.Text);
            komut3.Parameters.AddWithValue("@p2", txtSurname.Text);
            komut3.Parameters.AddWithValue("@p3", txtPhoneNumber.Text);
            komut3.Parameters.AddWithValue("@p4", txtEmail.Text);
            komut3.Parameters.AddWithValue("@p5", int.Parse(txtDepartmentID.Text));
            komut3.Parameters.AddWithValue("@p6", int.Parse(txtSalary.Text));
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("successful");
        }
        
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtEmployeID.Text = gridView1.GetFocusedRowCellValue("employeid").ToString();
            txtName.Text = gridView1.GetFocusedRowCellValue("name").ToString();
            txtSurname.Text = gridView1.GetFocusedRowCellValue("surname").ToString();
            txtPhoneNumber.Text = gridView1.GetFocusedRowCellValue("phonenumber").ToString();
            txtEmail.Text = gridView1.GetFocusedRowCellValue("email").ToString();
            txtDepartmentID.Text = gridView1.GetFocusedRowCellValue("departmentid").ToString();
            txtSalary.Text = gridView1.GetFocusedRowCellValue("salary").ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            string sorgu7 = "Select * from employees where email like '%" + txtEmail.Text + " %'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu7, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            CalisanMaasiniGuncelle( int.Parse(txtEmployeID.Text), int.Parse( txtSalary.Text));
            MessageBox.Show("successful");
        }
    }
}
