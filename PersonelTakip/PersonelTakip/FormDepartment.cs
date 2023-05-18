using DevExpress.Utils.About;
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
using System.Xml.Linq;

namespace PersonelTakip
{
    public partial class FormDepartment : Form
    {
        public FormDepartment()
        {
            InitializeComponent();
        }
       
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=personelTakipOtomanyonu; user ID=postgres; password=12345");
        private void BtnList_Click(object sender, EventArgs e)
        {
            string sorgu = "Select * from departments";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            NpgsqlCommand komut1= new NpgsqlCommand("insert into departments(departmentid, departmentname) values (@p1, @p2)",baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(txtDepartmentID.Text));
            komut1.Parameters.AddWithValue("@p2", txtDeparmentName.Text);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("successful");

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete From departments where departmentid=@p1 ", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(txtDepartmentID.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("successful");
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update departments set departmentname=@p1 where departmentid=@p2", baglanti);
            komut3.Parameters.AddWithValue("@p2", int.Parse(txtDepartmentID.Text));
            komut3.Parameters.AddWithValue("@p1", txtDeparmentName.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("successful");
            
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtDepartmentID.Text=gridView1.GetFocusedRowCellValue("departmentid").ToString();
            txtDeparmentName.Text = gridView1.GetFocusedRowCellValue("departmentname").ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            string sorgu7 = "Select * from departments where departmentname like '%" + txtDeparmentName.Text + " %'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu7, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
            baglanti.Close();
        }
    }
}
