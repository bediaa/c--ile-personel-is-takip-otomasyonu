using DevExpress.XtraBars.Ribbon;
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
    public partial class Form1 : Form
    {
     
        public Form1()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormDepartment frm = new FormDepartment();
            frm.MdiParent= this;
            frm.Show();
        }

        private void BtnListEmployees_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             FormEmployees frm2= new FormEmployees();
            frm2.MdiParent= this;
            frm2.Show();
        }

        private void BtnEmployeStatistic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormEmployeStatistic frm3 = new FormEmployeStatistic();
            frm3.MdiParent = this;
            frm3.Show();

        }

        private void BtnTaskList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormTaskList frm4 = new FormTaskList();
            frm4.MdiParent = this;
            frm4.Show();
        }

        private void BtnCreateNewTask_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormTask frm5 = new FormTask();
            frm5.MdiParent = this;
            frm5.Show();
        }

        private void BtnHomePage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormHomePage frm6 = new FormHomePage ();
            frm6.MdiParent = this;
            frm6.Show();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=personelTakipOtomanyonu; user ID=postgres; password=12345");
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /* baglanti.Open();
             var cmd = new NpgsqlCommand("Select (*) from admin where sifre=54321", baglanti);
             var reader = cmd.ExecuteReader();
             while (reader.Read())
             {
                 string sifre = reader["sifre"].ToString();
                 if (sifre == "54321")
                 {
                     // satırın sifre değeri 54321
                     FormShift frm = new FormShift();
                     frm.MdiParent = this;
                     frm.Show();
                 }
                 else
                 {
                     MessageBox.Show("Yetkiniz yok");
                 }
             }
             baglanti.Close();*/
            FormShift frm = new FormShift();
            frm.MdiParent = this;
            frm.Show();

        }

       
        private void Form1_Load(object sender, EventArgs e)
        {
           // button1 = new Button();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormTaskDetail frm = new FormTaskDetail();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
