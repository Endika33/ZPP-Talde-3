
using System.Data;


//lehio bat, Java programaren fitxategiak inportatzeko erabiltzen da, kanpinak eta bezeroak inportatzen dira
namespace ErronkaT3
{
   
    public partial class InportatuForm : Form
    {
        private bool okupatuta;

        public bool InportazioaAmaituta { get; private set; }

        public InportatuForm()
        {
            InitializeComponent();

            AcceptButton = inportatuB;
            CancelButton = itxiB;

            inportatuB.Click += async (_, _) => await InportatuAsync();
            itxiB.Click += (_, _) => Close();
            Shown += (_, _) => FitxategiakErakutsi();
            FormClosing += (_, e) => { if (okupatuta) e.Cancel = true; };
        }

        internal static void Estiloa(Button botoia, string testua)
        {
            botoia.Text = testua;
            botoia.Size = new Size(130, 34);
            botoia.FlatStyle = FlatStyle.Flat;
            botoia.FlatAppearance.BorderSize = 0;
            botoia.BackColor = Color.FromArgb(152, 179, 208);
            botoia.ForeColor = Color.White;
            botoia.Cursor = Cursors.Hand;
        }

        private void FitxategiakErakutsi()
        {
            string karpeta = JavaAjustes.Karpeta;
            if (!JavaAjustes.Baliozkoa(karpeta))
            {
                fitxategiak.Text = "Java programaren karpeta ez dago konfiguratuta.\nInportatu sakatzean aukeratu ahal izango duzu.";
                return;
            }

            string kanpinak = "?";
            string bezeroak = "?";
            try
            {
                foreach (string lerroa in File.ReadAllLines(Path.Combine(karpeta, "KONFIGURAZIOA.txt")))
                {
                    int i = lerroa.IndexOf('=');
                    if (i < 0) continue;
                    string gakoa = lerroa[..i].Trim().ToLowerInvariant();
                    string balioa = lerroa[(i + 1)..].Trim();
                    if (gakoa == "kanpinak") kanpinak = balioa;
                    else if (gakoa == "bezeroak") bezeroak = balioa;
                }
            }
            catch (IOException) { }
            catch (UnauthorizedAccessException) { }

            fitxategiak.Text = "Kanpinen XML:  " + kanpinak + "\nBezeroen XML:  " + bezeroak + "\nJava programa:  " + karpeta;
        }

        private void Okupatuta(bool balioa)
        {
            okupatuta = balioa;
            inportatuB.Enabled = !balioa;
            itxiB.Enabled = !balioa;
            aurrerapena.Visible = balioa;
        }

        private void Idatzi(string lerroa)
        {
            if (IsDisposed || !IsHandleCreated) return;
            BeginInvoke(() => log.AppendText(lerroa + Environment.NewLine));
        }

        private async Task InportatuAsync()
        {
            if (!JavaAjustes.Ziurtatu(this)) return;
            FitxategiakErakutsi();

            Okupatuta(true);
            log.Clear();
            egoera.Text = "Inportatzen...";
            try
            {
                JavaEmaitza emaitza = await JavaProzesua.ExekutatuAsync(JavaAjustes.Karpeta, "inportatu", Idatzi);
                Amaitu(emaitza);
            }
            finally
            {
                Okupatuta(false);
            }
        }

        private void Amaitu(JavaEmaitza emaitza)
        {
            if (emaitza.Ondo)
            {
                InportazioaAmaituta = true;
                egoera.Text = "Inportazioa amaituta.";
                string laburpena = string.Join(Environment.NewLine,
                    emaitza.Irteera.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                        .Where(l => l.Contains("irakurrita")));
                MessageBox.Show(this, "Inportazioa amaituta.\n\n" + laburpena, "Euskanp",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                egoera.Text = "Errorea inportatzean.";
                MessageBox.Show(this, "Errorea inportatzean:\n\n" + JavaProzesua.AkatsMezua(emaitza), "Euskanp",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}