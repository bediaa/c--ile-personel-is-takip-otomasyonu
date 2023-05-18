using Npgsql;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PersonelTakip
{
    public partial class FormEmployeStatistic : Form
    {
        public FormEmployeStatistic()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=personelTakipOtomanyonu; user ID=postgres; password=12345");
        private  void FormEmployeStatistic_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            int satir_sayisi = 0;
            var cmd = new NpgsqlCommand("Select count(*) from employees", baglanti);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                satir_sayisi = Int32.Parse(reader[0].ToString());
            }
  
            Lbltotalemploye.Text=satir_sayisi.ToString();
            baglanti.Close();


            baglanti.Open();
            int satir_sayisi2 = 0;
            var cmd1 = new NpgsqlCommand("Select count(*) from departments", baglanti);
            var reader2 = cmd1.ExecuteReader();
            while (reader2.Read())
            {
                satir_sayisi2= Int32.Parse(reader2[0].ToString());
            }
            LblTotalDepartments.Text=satir_sayisi2.ToString();
            baglanti.Close();


            baglanti.Open();
            int satir_sayisi3= 0;
            var cmd2 = new NpgsqlCommand("Select count(status) from tasks where status=true", baglanti);
            var reader3 = cmd2.ExecuteReader();
            while (reader3.Read())
            {
                satir_sayisi3 = Int32.Parse(reader3[0].ToString());
            }
            LblActiveTasks.Text=satir_sayisi3.ToString();   
            baglanti.Close();

            baglanti.Open();
            int satir_sayisi4= 0;
            var cmd4 = new NpgsqlCommand("Select count(status) from tasks where status=false", baglanti);
            var reader4 = cmd4.ExecuteReader();
            while (reader4.Read())
            {
                satir_sayisi4= Int32.Parse(reader4[0].ToString());
            }
            LblPassiveTasks.Text=satir_sayisi4.ToString();
            baglanti.Close();



        }

      
    }
}
