using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonelTakip
{
    public partial class FormTasksShow : Form
    {
        public FormTasksShow()
        {
            InitializeComponent();
        }


        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=personelTakipOtomanyonu; user ID=postgres; password=12345");

        private void FormTasksShow_Load(object sender, EventArgs e)
        {
  

            string sorgu2 = "Select * from tasks where status=false";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu2, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
           

            string sorgu3 = "Select * from tasks where status=true";
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sorgu3, baglanti);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            gridControl2.DataSource = dataSet.Tables[0];
            


        }
    }
}
