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

        private void Datuak_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
