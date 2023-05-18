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
    public partial class FormHomePage : Form
    {
        public FormHomePage()
        {
            InitializeComponent();
        }


        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=personelTakipOtomanyonu; user ID=postgres; password=12345");
        private void FormHomePage_Load(object sender, EventArgs e)
        {
            string sorgu = "Select receiver,statement from Tasks where status=true";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];

            DateTime today = DateTime.Parse(DateTime.Now.ToShortDateString());
           // MessageBox.Show(today.ToString());
            
            string sorgu1 = "Select tasks.statement from taskdetail inner join tasks on taskdetail.tasksid=tasks.tasksid ";
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sorgu1, baglanti);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            gridControl2.DataSource = dataSet.Tables[0];


        }
    }
}
