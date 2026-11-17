using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


//bezeroak ikusten duen lehioa, emendik esakerak egin ditzake eta idazkaritzatik bidalitako mezuak jaso
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

        private void btnEskuoihalak_Click(object sender, EventArgs e)
        {
            secretaria.GehituEskaera(id, izena, "Eskuoihalak", 2);
        }

        private void btnIzarak_Click(object sender, EventArgs e)
        {
            secretaria.GehituEskaera(id, izena, "Izarak", 3);
        }

        private void btnZaborra_Click(object sender, EventArgs e)
        {
            secretaria.GehituEskaera(id, izena, "Zaborra", 1);
        }

        private void btnJatetxea_Click(object sender, EventArgs e)
        {
            secretaria.GehituEskaera(id, izena, "Jatetxea", 1);
        }

        private void lstMezuak_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
