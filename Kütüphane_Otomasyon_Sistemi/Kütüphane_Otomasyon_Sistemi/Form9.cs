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
    public partial class grafikler : Form
    {
        public grafikler()
        {
            InitializeComponent();
        }
        SqlConnection sqlCon = new SqlConnection(@"Data Source=EMREZURNACI;Initial Catalog=DbMyLibrary;Integrated Security=True");
        private void grafikler_Load(object sender, EventArgs e)
        {
            sqlCon.Open();
            SqlCommand command = new SqlCommand("Select Count(*),YayınEviName from KitaplarTBL\r\ninner join YayinEviTBL\r\non KitaplarTBL.YayinEvi=YayinEviTBL.YayinEviID group by YayınEviName", sqlCon);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Kitaplar"].Points.AddXY(dr[1], dr[0]);
            }
            sqlCon.Close();

            sqlCon.Open();
            SqlCommand command1 = new SqlCommand("Select Count(*),Yaş from memberListTBL group by Yaş", sqlCon);
            SqlDataReader dr1 = command1.ExecuteReader();
            while (dr1.Read())
            {
                chart4.Series["Üyelerin Yaşları"].Points.AddXY(dr1[1], dr1[0]);
            }
            sqlCon.Close();

            sqlCon.Open();
            SqlCommand command2 = new SqlCommand("Select Count(*),AlınmaTarihi from ödünçAlınanKitaplarTBL group by AlınmaTarihi", sqlCon);
            SqlDataReader dr2 = command2.ExecuteReader();
            while (dr2.Read())
            {
                chart3.Series["Alınma Tarihi"].Points.AddXY(dr2[1], dr2[0]);
            }
            sqlCon.Close();


            sqlCon.Open();
            SqlCommand command3 = new SqlCommand("Select Count(*),AlınanKitap from ödünçAlınanKitaplarTBL Group By AlınanKitap", sqlCon);
            SqlDataReader dr3 = command3.ExecuteReader();
            while (dr3.Read())
            {
                chart2.Series["En Çok Alınan Kitaplar"].Points.AddXY(dr3[1], dr3[0]);
            }
            sqlCon.Close();

            


        }
    }
}
