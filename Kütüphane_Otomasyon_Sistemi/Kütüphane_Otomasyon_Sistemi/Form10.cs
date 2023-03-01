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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        SqlConnection sqlCon = new SqlConnection(@"Data Source=EMREZURNACI;Initial Catalog=DbMyLibrary;Integrated Security=True");
        private void Form10_Load(object sender, EventArgs e)
        {
            sqlCon.Open();
            SqlCommand command = new SqlCommand("Select KitapAdi from KitaplarTBl where SatisFiyati=(Select Max(SatisFiyati) from KitaplarTBL)", sqlCon);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                label2.Text = dr[0].ToString();
            }
            sqlCon.Close();
            sqlCon.Open();
            SqlCommand command2 = new SqlCommand("Select KitapAdi from KitaplarTBl where SatisFiyati=(Select Min(SatisFiyati) from KitaplarTBL)", sqlCon);
            SqlDataReader dr2 = command2.ExecuteReader();
            while (dr2.Read())
            {
                label5.Text = dr2[0].ToString();
            }
            sqlCon.Close();
            sqlCon.Open();
            SqlCommand command3 = new SqlCommand("Select KitapAdi from KitaplarTBl where SayfaSayisi = (Select Max(SayfaSayisi) from KitaplarTBL)", sqlCon);
            SqlDataReader dr3 = command3.ExecuteReader();
            while (dr3.Read())
            {
                label11.Text = dr3[0].ToString();
            }
            sqlCon.Close();
            sqlCon.Open();
            SqlCommand command4 = new SqlCommand("Select KitapAdi from KitaplarTBl where SayfaSayisi = (Select Min(SayfaSayisi) from KitaplarTBL)", sqlCon);
            SqlDataReader dr4 = command4.ExecuteReader();
            while (dr4.Read())
            {
                label7.Text = dr4[0].ToString();
            }
            sqlCon.Close();
            sqlCon.Open();
            SqlCommand command7 = new SqlCommand("Select firstName, lastName from memberListTBL where yaş = (Select Max(yaş) from memberListTBL)", sqlCon);
            SqlDataReader dr7 = command7.ExecuteReader();
            while (dr7.Read())
            {
                label17.Text = dr7[0].ToString()+"  "+dr7[1].ToString();
            }
            sqlCon.Close();
            sqlCon.Open();
            SqlCommand command8 = new SqlCommand("Select firstName, lastName from memberListTBL where yaş = (Select Min(yaş) from memberListTBL)", sqlCon);
            SqlDataReader dr8 = command8.ExecuteReader();
            while (dr8.Read())
            {
                label15.Text = dr8[0].ToString()+"   " +dr8[1].ToString();
            }
            sqlCon.Close();
            


        }
    }
}
