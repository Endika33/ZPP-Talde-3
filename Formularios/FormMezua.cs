using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//idazkaritza erabiltzen duen lehioa bezeroei mezua bidaltzekoe eta bezeroak jasotzen dute mezua bere Bezerolehioan
namespace ErronkaT3
{
        public partial class FormMezua : Form
        {
            public string Testua { get; private set; } = "";

            public FormMezua(string bezeroa)
            {
                InitializeComponent();
                lablIzena.Text = "Bezeroa: " + bezeroa;
                lablCont.Text = "0/" + txtMezua.MaxLength;
            }

            private void txtMezua_TextChanged(object sender, EventArgs e)
            {
                lablCont.Text = txtMezua.TextLength + "/" + txtMezua.MaxLength;
            }

            private void btnBidali_Click(object sender, EventArgs e)
            {
                if (txtMezua.Text.Trim() == "")
                {
                    MessageBox.Show("Idatzi mezua", "Oharra");
                    txtMezua.Focus();
                    return;
                }
                Testua = txtMezua.Text.Trim();
                DialogResult = DialogResult.OK;
            }

            private void button2_Click(object sender, EventArgs e)
            {
                DialogResult = DialogResult.Cancel;
            }
        }
    }

