using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kütüphane_Otomasyon_Sistemi
{
    public partial class Directions : Form
    {
        public Directions()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void panel1_Paint (object sender, EventArgs e)
        {
           
        }
        //1.Panel 
        private void panel1_Click(object sender, EventArgs e)
        {
            addNewBook anb = new addNewBook();
            anb.Show();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            addNewBook anb = new addNewBook();
            anb.Show();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            addNewBook anb = new addNewBook();
            anb.Show();
        }
        //2.Panel
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ListDeleteUpdate ldu = new ListDeleteUpdate();
            ldu.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ListDeleteUpdate ldu = new ListDeleteUpdate();
            ldu.Show();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            ListDeleteUpdate ldu = new ListDeleteUpdate();
            ldu.Show();
        }
        //3.Panel
        private void label5_Click(object sender, EventArgs e)
        {
            addNewMember anm = new addNewMember();
            anm.Show();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            addNewMember anm = new addNewMember();
            anm.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            addNewMember anm = new addNewMember();
            anm.Show();
        }
        //4.Panel
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            listOfMembers lom = new listOfMembers();
            lom.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            listOfMembers lom = new listOfMembers();
            lom.Show();
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            listOfMembers lom = new listOfMembers();
            lom.Show();
        }
        //5.panel
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            listofBooks lob = new listofBooks();
            lob.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            listofBooks lob = new listofBooks();
            lob.Show();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            listofBooks lob = new listofBooks();
            lob.Show();
        }
        //6.Panel
        private void label3_Click(object sender, EventArgs e)
        {
            ödünçKitapAl öka = new ödünçKitapAl();
                öka.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ödünçKitapAl öka = new ödünçKitapAl();
            öka.Show();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            ödünçKitapAl öka = new ödünçKitapAl();
            öka.Show();
        }
        //7.Panel
        //private void pictureBox7_Click(object sender, EventArgs e)
        //{
            
        //}

        private void label7_Click(object sender, EventArgs e)
        {
            grafikler g = new grafikler();
            g.Show();
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            grafikler g = new grafikler();
            g.Show();
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            grafikler g = new grafikler();
            g.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form10 frm10 = new Form10();
            frm10.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form10 frm10 = new Form10();
            frm10.Show();
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            Form10 frm10 = new Form10();
            frm10.Show();
        }
    }
}
