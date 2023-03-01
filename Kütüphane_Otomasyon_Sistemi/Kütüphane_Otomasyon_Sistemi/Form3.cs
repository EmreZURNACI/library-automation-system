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

namespace Kütüphane_Otomasyon_Sistemi
{
    public partial class addNewBook : Form
    {
        public addNewBook()
        {
            InitializeComponent();
        }
        SqlConnection sqlCon = new SqlConnection(@"Data Source=EMREZURNACI;Initial Catalog=DbMyLibrary;Integrated Security=True");
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCon.Open();
                SqlCommand command = new SqlCommand("insert into KitaplarTBL (KitapAdi,YazarAdi,SayfaSayisi,SatisFiyati,YayinEvi) values (@p1,@p2,@p3,@p4,@p5)", sqlCon);
                command.Parameters.AddWithValue("@p1", txtKitapAdi.Text);
                command.Parameters.AddWithValue("@p2", txtYazarAdi.Text);
                command.Parameters.AddWithValue("@p3", numericUpDown1.Value.ToString());
                command.Parameters.AddWithValue("@p4", numericUpDown2.Value.ToString());
                command.Parameters.AddWithValue("@p5", comboBox1.SelectedValue);
                command.ExecuteNonQuery();
                sqlCon.Close();
                MessageBox.Show("Kitap Başarıyla Kaydedilmiştir.", "Yeni Kitap", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                throw new Exception("SQL HATASI");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            sqlCon.Open();
            SqlCommand command1 = new SqlCommand("Select KitapAdi,YayinEvi,YayınEviName from KitaplarTBL inner join YayinEviTBL on KitaplarTBL.ID=YayinEviTBL.YayinEviID", sqlCon);
            SqlDataAdapter da = new SqlDataAdapter(command1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "YayınEviName";
            comboBox1.ValueMember = "YayinEvi";
            comboBox1.DataSource = dt;
            sqlCon.Close();
        }
    }
}
