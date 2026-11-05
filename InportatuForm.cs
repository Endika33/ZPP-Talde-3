namespace ErronkaT3
{
    /// <summary>"Inportatu" leihoa: Java programa exekutatzen du XML fitxategiak datu-basera inportatzeko.</summary>
    public class InportatuForm : Form
    {
        private readonly Label fitxategiak = new() { Name = "Fitxategiak" };
        private readonly Button inportatuB = new() { Name = "InportatuB" };
        private readonly Button itxiB = new() { Name = "ItxiB" };
        private readonly ProgressBar aurrerapena = new() { Name = "Aurrerapena" };
        private readonly Label egoera = new() { Name = "Egoera" };
        private readonly TextBox log = new() { Name = "Log" };
        private bool okupatuta;

        public bool InportazioaAmaituta { get; private set; }

        public InportatuForm()
        {
            Text = "Datuak inportatu";
            ClientSize = new Size(620, 440);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Font = new Font("Segoe UI", 9F);
            BackColor = Color.FromArgb(245, 245, 245);

            var titulua = new Label
            {
                Text = "Datuak inportatu",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 16)
            };
            var azalpena = new Label
            {
                Text = "Kanpinen eta bezeroen XML fitxategiak Oracle datu-basera inportatuko dira (Java programarekin).",
                Size = new Size(580, 36),
                Location = new Point(22, 54)
            };

            fitxategiak.Location = new Point(22, 94);
            fitxategiak.Size = new Size(580, 58);

            Estiloa(inportatuB, "Inportatu");
            inportatuB.Location = new Point(22, 160);
            Estiloa(itxiB, "Itxi");
            itxiB.Location = new Point(162, 160);
            itxiB.Size = new Size(100, 34);
            itxiB.BackColor = Color.FromArgb(220, 220, 220);
            itxiB.ForeColor = Color.Black;

            aurrerapena.Style = ProgressBarStyle.Marquee;
            aurrerapena.MarqueeAnimationSpeed = 30;
            aurrerapena.Location = new Point(300, 168);
            aurrerapena.Size = new Size(298, 18);
            aurrerapena.Visible = false;

            egoera.AutoSize = true;
            egoera.Location = new Point(22, 206);

            log.Multiline = true;
            log.ReadOnly = true;
            log.ScrollBars = ScrollBars.Vertical;
            log.Font = new Font("Consolas", 9F);
            log.BackColor = Color.White;
            log.Location = new Point(22, 232);
            log.Size = new Size(576, 186);

            Controls.AddRange(new Control[] { titulua, azalpena, fitxategiak, inportatuB, itxiB, aurrerapena, egoera, log });
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