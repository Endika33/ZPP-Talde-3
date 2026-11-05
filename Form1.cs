using System.Drawing.Drawing2D;

namespace ErronkaT3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            GraphicsPath camino = new GraphicsPath();
            camino.AddEllipse(Perfil.ClientRectangle);
            Perfil.Region = new Region(camino);

            // Datuak atala: Java programarekin konektatuta
            button7.Click += InportatuB_Click;   // Inportatu
            button8.Click += EsportatuB_Click;   // Esportatu
            button6.Click += BideojokoaB_Click;  // Bideojokoa
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EskaeraZerrendaB_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void InportatuB_Click(object? sender, EventArgs e)
        {
            using var leihoa = new InportatuForm();
            leihoa.ShowDialog(this);
        }

        private void BideojokoaB_Click(object? sender, EventArgs e)
        {
            BideojokoAjustes.Abiarazi(this);
        }

        private void EsportatuB_Click(object? sender, EventArgs e)
        {
            using var leihoa = new EsportatuForm();
            leihoa.ShowDialog(this);
        }

        private void Datuak_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
