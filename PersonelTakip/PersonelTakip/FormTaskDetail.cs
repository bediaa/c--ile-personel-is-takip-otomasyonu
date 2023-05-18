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
    public partial class FormTaskDetail : Form
    {
        public FormTaskDetail()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=personelTakipOtomanyonu; user ID=postgres; password=12345");
        private void BtnList_Click(object sender, EventArgs e)
        {
            string sorgu6 = "Select * from taskdetail";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu6, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into taskdetail(tasksid,statement,date) values (@p1, @p2,@p3)", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(TxtTasksid.Text));
            komut1.Parameters.AddWithValue("@p2", txtTaskDetailStatement.Text);
            komut1.Parameters.AddWithValue("@p3", DateTime.Parse(dateTimePicker1.Text));
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("successful");
        }

        private void FormTaskDetail_Load(object sender, EventArgs e)
        {
            DateTime selectedTime = dateTimePicker1.Value;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete From taskdetail where tasksid=@p1 ", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(TxtTasksid.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("successful");
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update taskdetail set statement=@p2, date=@p3 where tasksid=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", int.Parse(TxtTasksid.Text));
            komut3.Parameters.AddWithValue("@p2", txtTaskDetailStatement.Text);
            komut3.Parameters.AddWithValue("@p3", DateTime.Parse(dateTimePicker1.Text));
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("successful");
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            baglanti.Open();

           string sorgu7 = "Select * from taskdetail where statement like '%" + txtTaskDetailStatement.Text + " %'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu7, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
            baglanti.Close();
            
        }
    }
}
