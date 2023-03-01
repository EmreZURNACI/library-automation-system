using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kütüphane_Otomasyon_Sistemi
{
    public partial class ödünçKitapAl : Form
    {
        public ödünçKitapAl()
        {
            InitializeComponent();
        }
        SqlConnection sqlCon = new SqlConnection(@"Data Source=EMREZURNACI;Initial Catalog=DbMyLibrary;Integrated Security=True");
        private void Form8_Load(object sender, EventArgs e)
        {
            sqlCon.Open();
            SqlCommand command = new SqlCommand("Select KitapAdi,YazarAdi from KitaplarTBL",sqlCon);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlCon.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlCon.Open();
            SqlCommand commannd = new SqlCommand("Select firstName,lastName,password from memberListTBL where firstName=@p1 and lastName=@p2 and password=@p3", sqlCon);
            commannd.Parameters.AddWithValue("@p1", textBox1.Text);
            commannd.Parameters.AddWithValue("@p2", textBox2.Text);
            commannd.Parameters.AddWithValue("@p3", textBox3.Text);
            SqlDataReader dr=commannd.ExecuteReader();
            if (dr.Read())
            {
                sqlCon.Close();
                sqlCon.Open();
                SqlCommand command1 = new SqlCommand("insert into ödünçAlınanKitaplarTBL (mfirstName,mlastName,alınmaTarihi,KalanGün,AlınanKitap) values (@p1,@p2,@p3,@p4,@p5)", sqlCon);
                command1.Parameters.AddWithValue("@p1",textBox1.Text);
                command1.Parameters.AddWithValue("@p2", textBox2.Text);
                command1.Parameters.AddWithValue("@p3", DateTime.Now);
                command1.Parameters.AddWithValue("@p4", comboBox1.Text);
                command1.Parameters.AddWithValue("@p5", textBox5.Text);
                command1.ExecuteNonQuery();
                sqlCon.Close();
                MessageBox.Show("İşleminiz başarıyla Gerçekleşmiştir.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Kitap Alabilmek İçin Öncelikle Kütüphanemize Kaydolmanız Gerekmektedir.", "GEÇERSİZ KAYIT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addNewMember anm = new addNewMember();
            anm.Show();
            this.Hide();

        }
    }
}
