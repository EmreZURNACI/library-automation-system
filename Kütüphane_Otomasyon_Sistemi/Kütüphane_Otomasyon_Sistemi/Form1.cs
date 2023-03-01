using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Kütüphane_Otomasyon_Sistemi
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }
        public string kod = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            kod=rnd.Next(1000000,10000000).ToString();
            txtKod.Text = kod;
           
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=EMREZURNACI;Initial Catalog=DbMyLibrary;Integrated Security=True");
            sqlCon.Open();
            SqlCommand command = new SqlCommand("Select * from AdminTBL where Username=@p1 and Password=@p2", sqlCon);
            command.Parameters.AddWithValue("@p1", txtUsername.Text);
            command.Parameters.AddWithValue("@p2", txtPassword.Text);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read() && txtKod.Text == maskedTextBox1.Text)
            {
                Directions form2 = new Directions();
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(" Girdiğiniz Bilgiler Eksik veya Hatalıdır. \n Düzenleyip,Tekrar Deneyiniz...", "HATALI GİRİŞ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
