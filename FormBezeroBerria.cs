using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ErronkaT3
{
    public partial class FormBezeroBerria : Form
    {
        public string Izena { get; private set; } = "";
        public string Abizenak { get; private set; } = "";
        public string Emaila { get; private set; } = "";
        public string Telefonoa { get; private set; } = "";
        public string Mota { get; private set; } = "";

        public FormBezeroBerria()
        {
            InitializeComponent();
            cbxMota.Items.AddRange(new object[] { "denda", "autoka", "bungalow" });
            cbxMota.SelectedIndex = 0;
        }

        private void btnGorde_Click(object sender, EventArgs e)
        {
            if (txtIzena.Text.Trim() == "" || txtAbizenak.Text.Trim() == "")
            {
                MessageBox.Show("Idatzi izena eta abizenak");
                return;
            }

            Izena = txtIzena.Text.Trim();
            Abizenak = txtAbizenak.Text.Trim();
            Emaila = txtEmaila.Text.Trim();
            Telefonoa = txtTelefonoa.Text.Trim();
            Mota = cbxMota.SelectedItem?.ToString() ?? "denda";
            DialogResult = DialogResult.OK;
        }
    }
}