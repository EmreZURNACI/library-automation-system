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

    public partial class listofBooks : Form
    {
        public listofBooks()
        {
            InitializeComponent();
        }
        SqlConnection sqlCon = new SqlConnection(@"Data Source=EMREZURNACI;Initial Catalog=DbMyLibrary;Integrated Security=True");
        private void listofBooks_Load(object sender, EventArgs e)
        {
            sqlCon.Open();
            SqlCommand command = new SqlCommand("Select mfirstName,mlastName,alınmatarihi,KalanGün,AlınanKitap from ödünçAlınanKitaplarTBL", sqlCon);
            SqlDataAdapter da= new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlCon.Close();

        }
    }
}
