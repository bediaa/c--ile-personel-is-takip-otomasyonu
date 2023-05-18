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
    public partial class FormEmloyeesPage : Form
    {
        public FormEmloyeesPage()
        {
            InitializeComponent();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormTask frm6 = new FormTask();
            frm6.MdiParent = this;
            frm6.Show();
        }

     

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormTasksShow frm7 = new FormTasksShow();
            frm7.MdiParent = this;
            frm7.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormTasksShow frm8 = new FormTasksShow();
            frm8.MdiParent = this;
            frm8.Show();
        }
    }
}
