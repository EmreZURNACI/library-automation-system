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
    public partial class listOfMembers : Form
    {
        public listOfMembers()
        {
            InitializeComponent();
        }

        private void listOfMembers_Load(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=EMREZURNACI;Initial Catalog=DbMyLibrary;Integrated Security=True");
            sqlCon.Open();
            SqlCommand command = new SqlCommand("Select memberID,firstName,lastName,yaş from memberListTBL",sqlCon);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlCon.Close();
        }
    }
}
