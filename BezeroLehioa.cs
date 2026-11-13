using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ErronkaT3
{
    public partial class BezeroLehioa : Form
    {
        private Form1 secretaria;
        private string izena;
        private int id;
        public BezeroLehioa(Form1 secretaria, int id, string izena, string mota)
        {
            InitializeComponent();
            this.secretaria = secretaria;
            this.id = id;
            this.izena = izena;


            txtboId.Text = id.ToString();
            txtboIzena.Text = izena;
            txtboMota.Text = mota;
        }
        public void JasoMezua(string testua)
        {
            lstMezuak.Items.Add(DateTime.Now.ToString("HH:mm") + " Idazkaritza: " + testua);
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnIzarak_Click(object sender, EventArgs e)
        {
            secretaria.GehituEskaera(izena, "Izarak", 3);
        }

        private void btnEskuoihalak_Click(object sender, EventArgs e)
        {
            secretaria.GehituEskaera(izena, "Eskuoihalak", 2);
        }

        private void btnJatetxea_Click(object sender, EventArgs e)
        {
            secretaria.GehituEskaera(izena, "Jatetxea", 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            secretaria.GehituEskaera(izena, "Zaborra", 1);
        }

        private void lstMezuak_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
