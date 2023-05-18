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
    public partial class FormTaskList : Form
    {
        public FormTaskList()
        {
            InitializeComponent();
        }


        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=personelTakipOtomanyonu; user ID=postgres; password=12345");
        private void FormTaskList_Load(object sender, EventArgs e)
        {

            baglanti.Open();
            string sorgu = "Select * from tasks";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
            baglanti.Close();
            baglanti.Open();
          
            int satir_sayisi = 0;
            var cmd = new NpgsqlCommand("Select count(*) from departments", baglanti);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                satir_sayisi = Int32.Parse(reader[0].ToString());
            }

            labelControl2.Text = satir_sayisi.ToString();
            baglanti.Close();

            baglanti.Open();
            int satir_sayisi1 = 0;
            var cmd1 = new NpgsqlCommand("Select count(*) from tasks where status=false", baglanti);
            var reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                satir_sayisi1 = Int32.Parse(reader1[0].ToString());
            }

            labelControl4.Text = satir_sayisi1.ToString();
            baglanti.Close();

           baglanti.Open();
            int satir_sayisi2 = 0;
            var cmd2 = new NpgsqlCommand("Select count(*) from tasks where status=true", baglanti);
            var reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                satir_sayisi2 = Int32.Parse(reader2[0].ToString());
            }

            labelControl6.Text = satir_sayisi2.ToString();
            baglanti.Close();


            chartControl1.Series["Series1"].Points.AddPoint("Aktif görevler",int.Parse(labelControl4.Text));
            chartControl1.Series["Series1"].Points.AddPoint("Pasif görevler", int.Parse(labelControl6.Text));
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
