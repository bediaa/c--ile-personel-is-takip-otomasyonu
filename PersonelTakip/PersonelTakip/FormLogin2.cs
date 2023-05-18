using DevExpress.Utils.Extensions;
using DevExpress.XtraBars.Ribbon;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.XtraEditors.Mask.MaskSettings;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Security.Cryptography;
using DevExpress.Office.Crypto;

namespace PersonelTakip
{
    public partial class FormLogin2 : Form
    {

        public FormLogin2()
        {
            InitializeComponent();
        }


        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=personelTakipOtomanyonu; user ID=postgres; password=12345");

        static string GetMD5hash(MD5 md5,string input)
        {
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(input)); 
            StringBuilder sb = new StringBuilder();
            for (int i=0; i<data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }
            return sb.ToString();
        }


        private void BtnAdmin_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            string name;
            string Password;

            name = txtUserName.Text;
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            Password = txtPassword.Text;
            string hash = GetMD5hash(md5, Password);
            Console.WriteLine(hash);

            
            
            
            /*byte[] inputpassword = System.Text.Encoding.ASCII.GetBytes(Password);
            byte[] hashpassword = md5.ComputeHash(inputpassword); 
          
            Console.WriteLine(hashpassword.ToString());*/
        
         using( NpgsqlCommand komut = new NpgsqlCommand("Select * from director WHERE kullaniciadi='"+name+"' AND sifre='"+hash+"'", baglanti))

            using (NpgsqlDataReader reader = komut.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    Form1 frm6 = new Form1();
                    frm6.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Giriş Başarısız...");
                }
            }

            
            baglanti.Close();
        }

        private void txtUserName_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.White;
            panel3.BackColor = SystemColors.Control;

        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            panel2.BackColor = SystemColors.Control;
            panel3.BackColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {


            baglanti.Open();
            string name;
            string Password;

            name = txtUserName.Text;
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            Password = txtPassword.Text;
            string hash = GetMD5hash(md5, Password);
            Console.WriteLine(hash);




            /*byte[] inputpassword = System.Text.Encoding.ASCII.GetBytes(Password);
            byte[] hashpassword = md5.ComputeHash(inputpassword); 
          
            Console.WriteLine(hashpassword.ToString());*/

            using (NpgsqlCommand komut = new NpgsqlCommand("Select * from employees WHERE name='" + name + "' AND password='" + hash + "'", baglanti))

            using (NpgsqlDataReader reader = komut.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    FormEmloyeesPage frm7 = new FormEmloyeesPage();
                    frm7.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Giriş Başarısız...");
                }
            }


            baglanti.Close();
           
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }
    }
}

