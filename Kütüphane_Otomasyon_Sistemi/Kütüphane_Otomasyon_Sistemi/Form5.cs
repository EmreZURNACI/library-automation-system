using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Data.SqlClient;

namespace Kütüphane_Otomasyon_Sistemi
{
    public partial class addNewMember : Form
    {

        SqlConnection sqlCon = new SqlConnection(@"Data Source=EMREZURNACI;Initial Catalog=DbMyLibrary;Integrated Security=True");

        public addNewMember()
        {
            InitializeComponent();
        }
        public static bool IsValid(string email)
        {
            var valid = true;

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox2.Text != null && textBox3.Text != null && textBox4.Text != null && IsValid(textBox3.Text))
            {
                sqlCon.Open();
                SqlCommand command = new SqlCommand("insert into memberListTBL (firstName,lastName,yaş,mail,password) values (@p1,@p2,@p3,@p4,@p5)", sqlCon);
                command.Parameters.AddWithValue("@p1", textBox1.Text);
                command.Parameters.AddWithValue("@p2", textBox2.Text);
                command.Parameters.AddWithValue("@p3", numericUpDown1.Value);
                command.Parameters.AddWithValue("@p4", textBox3.Text);
                command.Parameters.AddWithValue("@p5", textBox4.Text);
                command.ExecuteNonQuery();
                sqlCon.Close();
                MessageBox.Show("Kaydınız Başarıyla Gerçekleşmiştir. \n Yeni Üyemiz Hoş Geldiniz...", "KAYIT BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Geçersiz Bilgiler Bulunmaktadır,Düzenleyiniz!", "KAYIT BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void addNewMember_Load(object sender, EventArgs e)
        {

        }
    }
}
