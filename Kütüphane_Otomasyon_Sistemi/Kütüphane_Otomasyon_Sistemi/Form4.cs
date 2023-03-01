using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kütüphane_Otomasyon_Sistemi
{
    public partial class ListDeleteUpdate : Form
    {
        public ListDeleteUpdate()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=EMREZURNACI;Initial Catalog=DbMyLibrary;Integrated Security=True");
            sqlCon.Open();
            SqlCommand command = new SqlCommand("Select ID,KitapAdi,YazarAdi,SayfaSayisi,SatisFiyati,YayınEviName as 'Yayınevi' from KitaplarTBL\r\ninner join YayinEviTBL\r\non YayinEviTBL.YayinEviID=KitaplarTBL.YayinEvi", sqlCon);
            SqlDataAdapter da=new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlCon.Close();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            sqlCon.Open();
            SqlCommand command1 = new SqlCommand("Select * from YayinEviTBL", sqlCon);
            SqlDataAdapter da = new SqlDataAdapter(command1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "YayınEviName";
            comboBox1.ValueMember = "YayinEviID";
            comboBox1.DataSource = dt;
            sqlCon.Close();
            textBox1.Text= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            

        }
        SqlConnection sqlCon = new SqlConnection(@"Data Source=EMREZURNACI;Initial Catalog=DbMyLibrary;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            
            sqlCon.Open();
            SqlCommand command = new SqlCommand("Select ID,KitapAdi,YazarAdi,SayfaSayisi,SatisFiyati,YayınEviName as 'Yayınevi' from KitaplarTBL inner join YayinEviTBL on YayinEviTBL.YayinEviID=KitaplarTBL.YayinEvi", sqlCon);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlCon.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=EMREZURNACI;Initial Catalog=DbMyLibrary;Integrated Security=True");
            sqlCon.Open();
            SqlCommand command = new SqlCommand("Delete from KitaplarTBL where  ID=@p1", sqlCon);
            command.Parameters.AddWithValue("@p1", textBox1.Text);
            command.ExecuteNonQuery();
            sqlCon.Close();
            MessageBox.Show("Silinme İşlemi Başarıyla Gerçekleşmiştir.", "Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=EMREZURNACI;Initial Catalog=DbMyLibrary;Integrated Security=True");
            sqlCon.Open();
            SqlCommand command = new SqlCommand("Update KitaplarTBL set KitapAdi=@p2,YazarAdi=@p3,SayfaSayisi=@p4,SatisFiyati=@p5,YayinEvi=@p6 where ID=@p1", sqlCon);
            command.Parameters.AddWithValue("@p1", textBox1.Text);
            command.Parameters.AddWithValue("@p2", textBox2.Text);
            command.Parameters.AddWithValue("@p3", textBox3.Text);
            command.Parameters.AddWithValue("@p4", textBox4.Text);
            command.Parameters.AddWithValue("@p5", textBox5.Text);
            command.Parameters.AddWithValue("@p6", comboBox1.SelectedValue);
            command.ExecuteNonQuery();
            sqlCon.Close();
            MessageBox.Show("Düzenleme İşlemi Başarıyla Gerçekleşmiştir.", "Düzenlendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
