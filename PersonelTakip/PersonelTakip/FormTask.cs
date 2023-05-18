using DevExpress.XtraGrid;
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
    public partial class FormTask : Form
    {
        public FormTask()
        {
            InitializeComponent();
        }

        private void pictureEdit4_EditValueChanged(object sender, EventArgs e)
        {

        }


        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=personelTakipOtomanyonu; user ID=postgres; password=12345");
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string sorgu = "Select * from tasks";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            

            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into tasks( sender, receiver,date, status,statement) values (@p1, @p2,@p3,@p4,@p5)", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(TxtSender.Text));
            komut1.Parameters.AddWithValue("@p2", int.Parse(TxtReceiver.Text));
            komut1.Parameters.AddWithValue("@p3", DateTime.Parse(TxtDate.Text));
            komut1.Parameters.AddWithValue("@p4", true);
            komut1.Parameters.AddWithValue("@p5", TxtStatement.Text);
            komut1.ExecuteNonQuery();
            

            baglanti.Close();
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("insert into taskdetail(tasksid, statement,date) values (@p6, @p7,@p3)", baglanti);
            komut2.Parameters.AddWithValue("@p6", int.Parse(TxtTaskId.Text));
            komut2.Parameters.AddWithValue("@p7", TxtTaskDetailStatement.Text);
            komut2.Parameters.AddWithValue("@p3", DateTime.Parse(TxtDate.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();   
            MessageBox.Show("successful");
        }

        private void FormTask_Load(object sender, EventArgs e)
        {

        }
    }
}
