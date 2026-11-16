using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Collections.Concurrent;
using ErronkaT3.Modelos;
using ErronkaT3;

namespace ErronkaT3
{
    public partial class Form1 : Form
    {
        private int siguienteId = 1;

        private Dictionary<int, BezeroLehioa> leihoak = new();
        private BindingList<Eskaera> eskaerak = new();
        private BlockingCollection<Eskaera> kola = new();
        private ManualResetEventSlim lanaldia = new(false);
        private BindingList<BezeroDatuak> bezeroak = new();
        public void GehituEskaera(int bezeroId, string bezeroa, string mota, int segundos)
        {
            var e = new Eskaera { BezeroId = bezeroId, Bezeroa = bezeroa, Mota = mota, Segundos = segundos };
            eskaerak.Add(e);
            kola.Add(e);
        }

        private void SortuLangileak()
        {
            for (int i = 1; i <= 2; i++)
            {
                string izena = "Langilea " + i;
                new Thread(() => Lan(izena)) { IsBackground = true }.Start();
            }
        }

        private void Lan(string langilea)
        {
            while (true)
            {
                lanaldia.Wait();

                if (!kola.TryTake(out var e, 200))
                    continue;

                if (e.Ezeztatuta) continue;   

                Invoke(() => { e.Langilea = langilea; e.Egoera = "Egiten"; });
                Thread.Sleep(e.Segundos * 1000);

                Invoke(() =>
                {
                    e.Egoera = "Eginda";
                    if (e.Ezeztatuta) eskaerak.Remove(e);  
                });
            }
        }
        private void BezeroarenEskaerakKendu(int id)
        {
            foreach (var e in eskaerak.Where(x => x.BezeroId == id).ToList())
            {
                e.Ezeztatuta = true;
                if (e.Egoera != "Egiten")
                    eskaerak.Remove(e);
            }
        }
        private void BezeroakKargatu()
        {
            try
            {
                bezeroak.Clear();
                foreach (var b in BezeroDb.Kargatu()) bezeroak.Add(b);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ezin izan dira bezeroak kargatu:\n" + ex.Message);
            }
        }
        public Form1()
        {
            InitializeComponent();
            SortuLangileak();
            dgvEskaerak.DataSource = eskaerak;
            dgvEskaerak.Columns["Bezeroa"].Width = 80;
            dgvEskaerak.Columns["Mota"].Width = 80;
            dgvEskaerak.Columns["Segundos"].HeaderText = "Segunduak";
            dgvEskaerak.Columns["Langilea"].Width = 80;
            dgvEskaerak.Columns["Egoera"].Width = 80;
            dgvEskaerak.Columns["Ezeztatuta"].Visible = false;
            dgvEskaerak.Columns["BezeroId"].Visible = false;
            

            dgvBezeroak.DataSource = bezeroak;
            BezeroakKargatu();
            dgvBezeroak.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBezeroak.Columns["Id"].HeaderText = "ID";
            dgvBezeroak.Columns["Izena"].HeaderText = "Bezeroa";
            dgvBezeroak.Columns["Abizenak"].HeaderText = "Abizenak";
            dgvBezeroak.Columns["Emaila"].HeaderText = "Emaila";
            dgvBezeroak.Columns["Telefonoa"].HeaderText = "Telefonoa";
            dgvBezeroak.Columns["ostatuMota"].HeaderText = "Ostatua";
            dgvBezeroak.Columns["sortzeEguna"].HeaderText = "Sortze Eguna";


            GraphicsPath camino = new GraphicsPath();
            camino.AddEllipse(Perfil.ClientRectangle);
            Perfil.Region = new Region(camino);
            button7.Click += InportatuB_Click;
            button8.Click += EsportatuB_Click;
            button6.Click += BideojokoaB_Click;
        }

        private void label1_Click(object sender, EventArgs e)
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

        private void Perfil_Click(object sender, EventArgs e)
        {

        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (!lanaldia.IsSet)
            {
                MessageBox.Show("Lanaldia ez da hasi. Ezin da bezero berrik erregistratu.", "Oharra");
                return;
            }

            using var f = new FormBezeroBerria();
            if (f.ShowDialog(this) != DialogResult.OK) return;

            var datuak = new BezeroDatuak
            {
                Izena = f.Izena,
                Abizenak = f.Abizenak,
                Emaila = f.Emaila,
                Telefonoa = f.Telefonoa,
                ostatuMota = f.Mota
            };

            try
            {
                datuak.Id = BezeroDb.Gehitu(datuak);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ezin izan da bezeroa gorde:\n" + ex.Message);
                return;
            }

            bezeroak.Add(datuak);

            var leihoa = new BezeroLehioa(this, datuak.Id, datuak.Izena, datuak.ostatuMota);
            leihoak[datuak.Id] = leihoa;
            leihoa.FormClosed += (s, ev) =>
            {
                leihoak.Remove(datuak.Id);
                BezeroarenEskaerakKendu(datuak.Id);
            };
            leihoa.Show(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lanaldia.Reset();

            btnLanaldiaHasi.Text = "Lanaldia hasi";
        }

        private void btnLanaldiaHasi_Click(object sender, EventArgs e)
        {
            lanaldia.Set();
            btnLanaldiaHasi.Text = "Lanaldia martxan";
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (!lanaldia.IsSet)
            {
                MessageBox.Show("Lanaldia ez da hasi. Ezin da mezurik bidali.", "Oharra");
                return;
            }
            if (dgvBezeroak.CurrentRow?.DataBoundItem is not BezeroDatuak b)
            {
                MessageBox.Show("Aukeratu bezero bat");
                return;
            }
            if (!leihoak.TryGetValue(b.Id, out var leihoa))
            {
                MessageBox.Show("Bezero hau ez dago konektatuta.", "Oharra");
                return;
            }

            using var f = new FormMezua(b.Id + " - " + b.Izena);
            if (f.ShowDialog(this) == DialogResult.OK) leihoa.JasoMezua(f.Testua);
        }

        private void dgvBezeroak_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }
    }
}
