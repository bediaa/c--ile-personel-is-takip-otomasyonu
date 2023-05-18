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
    public partial class FormShift : Form
    {
        public FormShift()
        {
            InitializeComponent();
        }


        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=personelTakipOtomanyonu; user ID=postgres; password=12345");

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string sorgu2 = "Select * from shift";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu2, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            baglanti.Open();

            
            NpgsqlCommand komut2 = new NpgsqlCommand("insert into shift( adminid, employeesid, date,totalhour,shifthourprice,totalprice,salarystatus) values ( @p2,@p3,@p4,@p5,@p6,@p7,@p8)", baglanti);
           // komut2.Parameters.AddWithValue("@p1", int.Parse(txtShiftID.Text));
            komut2.Parameters.AddWithValue("@p2", int.Parse(txtAdminID.Text));
            komut2.Parameters.AddWithValue("@p3", int.Parse(txtEmployeesID.Text));
            komut2.Parameters.AddWithValue("@p4", DateTime.Parse(dateTimePicker1.Text));
            komut2.Parameters.AddWithValue("@p5", int.Parse(txtTotalHour.Text));
            komut2.Parameters.AddWithValue("@p6", int.Parse(txtShiftHourPrice.Text));
            //komut2.Parameters.AddWithValue("@p7", int.Parse(txtTotalPrice.Text));
            komut2.Parameters.AddWithValue("@p7", int.Parse(txtTotalHour.Text) * int.Parse(txtShiftHourPrice.Text));
            komut2.Parameters.AddWithValue("@p8", (checkEdit1.Checked));

            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("successful");
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut4 = new NpgsqlCommand("update shift set salarystatus=@p2 where shiftid=@p1", baglanti);
            komut4.Parameters.AddWithValue("@p1", int.Parse(txtShiftID.Text));
            komut4.Parameters.AddWithValue("@p2", true);
          
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("successful");
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtShiftID.Text = gridView1.GetFocusedRowCellValue("shiftid").ToString();
            txtAdminID.Text = gridView1.GetFocusedRowCellValue("adminid").ToString();
            txtEmployeesID.Text = gridView1.GetFocusedRowCellValue("employeesid").ToString();
            dateTimePicker1.Text = gridView1.GetFocusedRowCellValue("date").ToString();
            txtTotalHour.Text = gridView1.GetFocusedRowCellValue("totalhour").ToString();
            txtShiftHourPrice.Text = gridView1.GetFocusedRowCellValue("shifthourprice").ToString();
            txtTotalPrice.Text = gridView1.GetFocusedRowCellValue("totalprice").ToString();
            checkEdit1.Text = gridView1.GetFocusedRowCellValue("salarystatus").ToString();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete From shift where employeesid=@p1 ", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(txtEmployeesID.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("successful");
        }

        private void FormShift_Load(object sender, EventArgs e)
        {
            DateTime selectedTime = dateTimePicker1.Value;
           
        }
    }
}
