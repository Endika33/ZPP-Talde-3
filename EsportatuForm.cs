using System.Diagnostics;

namespace ErronkaT3
{
    /// <summary>"Esportatu" leihoa: probintzia eta herria aukeratu eta Java programarekin CSV eta XML sortzen ditu.</summary>
    public class EsportatuForm : Form
    {
        private readonly ComboBox probintziaCombo = new() { Name = "ProbintziaCombo", DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly ComboBox herriaCombo = new() { Name = "HerriaCombo", DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly TextBox irteeraBox = new() { Name = "IrteeraBox" };
        private readonly Button arakatuB = new() { Name = "ArakatuB" };
        private readonly Button esportatuB = new() { Name = "EsportatuB" };
        private readonly Button karpetaIrekiB = new() { Name = "KarpetaIrekiB" };
        private readonly Button itxiB = new() { Name = "ItxiB" };
        private readonly ProgressBar aurrerapena = new() { Name = "Aurrerapena" };
        private readonly Label egoera = new() { Name = "Egoera" };
        private readonly TextBox log = new() { Name = "Log" };

        private List<Herria> herriak = new();
        private bool kargatuta;
        private bool okupatuta;

        public EsportatuForm()
        {
            Text = "Datuak esportatu";
            ClientSize = new Size(620, 440);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Font = new Font("Segoe UI", 9F);
            BackColor = Color.FromArgb(245, 245, 245);

            var titulua = new Label
            {
                Text = "Datuak esportatu",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 16)
            };
            var probintziaEtiketa = new Label { Text = "Probintzia:", AutoSize = true, Location = new Point(22, 72) };
            var herriaEtiketa = new Label { Text = "Herria:", AutoSize = true, Location = new Point(22, 106) };
            var irteeraEtiketa = new Label { Text = "Irteera karpeta:", AutoSize = true, Location = new Point(22, 140) };

            probintziaCombo.Location = new Point(130, 68);
            probintziaCombo.Size = new Size(300, 24);
            herriaCombo.Location = new Point(130, 102);
            herriaCombo.Size = new Size(300, 24);

            irteeraBox.Location = new Point(130, 136);
            irteeraBox.Size = new Size(430, 24);
            irteeraBox.Text = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Euskanp", "esportazioak");
            arakatuB.Text = "...";
            arakatuB.Location = new Point(566, 135);
            arakatuB.Size = new Size(32, 26);

            InportatuForm.Estiloa(esportatuB, "Esportatu");
            esportatuB.Location = new Point(22, 178);
            InportatuForm.Estiloa(karpetaIrekiB, "Karpeta ireki");
            karpetaIrekiB.Location = new Point(162, 178);
            karpetaIrekiB.Enabled = false;
            InportatuForm.Estiloa(itxiB, "Itxi");
            itxiB.Location = new Point(302, 178);
            itxiB.Size = new Size(100, 34);
            itxiB.BackColor = Color.FromArgb(220, 220, 220);
            itxiB.ForeColor = Color.Black;

            aurrerapena.Style = ProgressBarStyle.Marquee;
            aurrerapena.MarqueeAnimationSpeed = 30;
            aurrerapena.Location = new Point(420, 186);
            aurrerapena.Size = new Size(178, 18);
            aurrerapena.Visible = false;

            egoera.AutoSize = true;
            egoera.Location = new Point(22, 224);

            log.Multiline = true;
            log.ReadOnly = true;
            log.ScrollBars = ScrollBars.Vertical;
            log.Font = new Font("Consolas", 9F);
            log.BackColor = Color.White;
            log.Location = new Point(22, 250);
            log.Size = new Size(576, 168);

            Controls.AddRange(new Control[]
            {
                titulua, probintziaEtiketa, herriaEtiketa, irteeraEtiketa,
                probintziaCombo, herriaCombo, irteeraBox, arakatuB,
                esportatuB, karpetaIrekiB, itxiB, aurrerapena, egoera, log
            });
            CancelButton = itxiB;
            esportatuB.Enabled = false;

            probintziaCombo.SelectedIndexChanged += (_, _) => HerriakEguneratu();
            arakatuB.Click += (_, _) => KarpetaAukeratu();
            esportatuB.Click += async (_, _) => await EsportatuAsync();
            karpetaIrekiB.Click += (_, _) => KarpetaIreki();
            itxiB.Click += (_, _) => Close();
            Shown += async (_, _) => await KargatuAsync();
            FormClosing += (_, e) => { if (okupatuta) e.Cancel = true; };
        }

        private void Okupatuta(bool balioa)
        {
            okupatuta = balioa;
            probintziaCombo.Enabled = !balioa;
            herriaCombo.Enabled = !balioa;
            esportatuB.Enabled = !balioa && kargatuta;
            itxiB.Enabled = !balioa;
            aurrerapena.Visible = balioa;
        }

        private void Idatzi(string lerroa)
        {
            if (IsDisposed || !IsHandleCreated) return;
            BeginInvoke(() => log.AppendText(lerroa + Environment.NewLine));
        }

        // Probintziak eta herriak datu-basetik irakurtzen dira (Java programaren "zerrendatu" aginduarekin)
        private async Task KargatuAsync()
        {
            if (!JavaAjustes.Ziurtatu(this))
            {
                Close();
                return;
            }

            Okupatuta(true);
            egoera.Text = "Probintziak eta herriak kargatzen...";
            try
            {
                JavaEmaitza emaitza = await JavaProzesua.ExekutatuAsync(JavaAjustes.Karpeta, "zerrendatu");
                if (emaitza.IrteeraKodea == JavaProzesua.DaturikEz)
                {
                    egoera.Text = "Datu-basea hutsik dago.";
                    MessageBox.Show(this, "Datu-basea hutsik dago. Inportatu datuak lehenengo.", "Euskanp",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!emaitza.Ondo)
                {
                    egoera.Text = "Errorea datuak kargatzean.";
                    MessageBox.Show(this, "Errorea:\n\n" + JavaProzesua.AkatsMezua(emaitza), "Euskanp",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var (probintziak, kargatutakoHerriak) = Kokalekuak.Irakurri(emaitza.Irteera);
                herriak = kargatutakoHerriak;
                probintziaCombo.DataSource = probintziak;
                kargatuta = probintziak.Count > 0;
                egoera.Text = "Aukeratu probintzia eta herria.";
            }
            finally
            {
                Okupatuta(false);
            }
        }

        private void HerriakEguneratu()
        {
            if (probintziaCombo.SelectedItem is not Probintzia probintzia) return;

            var zerrenda = new List<Herria> { new Herria(probintzia.Kodea, 0, "Guztiak") };
            zerrenda.AddRange(herriak.Where(h => h.ProbintziaKodea == probintzia.Kodea));
            herriaCombo.DataSource = zerrenda;
            herriaCombo.SelectedIndex = 0;
        }

        private void KarpetaAukeratu()
        {
            using var elkarrizketa = new FolderBrowserDialog
            {
                Description = "Aukeratu fitxategiak gordetzeko karpeta",
                UseDescriptionForTitle = true
            };
            if (elkarrizketa.ShowDialog(this) == DialogResult.OK)
            {
                irteeraBox.Text = elkarrizketa.SelectedPath;
            }
        }

        private void KarpetaIreki()
        {
            string karpeta = irteeraBox.Text.Trim();
            if (Directory.Exists(karpeta))
            {
                Process.Start(new ProcessStartInfo("explorer.exe", "\"" + karpeta + "\"") { UseShellExecute = true });
            }
        }

        private async Task EsportatuAsync()
        {
            if (probintziaCombo.SelectedItem is not Probintzia probintzia || herriaCombo.SelectedItem is not Herria herria) return;

            string irteera = irteeraBox.Text.Trim().TrimEnd('\\');
            if (irteera.Length == 0)
            {
                MessageBox.Show(this, "Aukeratu fitxategiak gordetzeko karpeta.", "Euskanp",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Okupatuta(true);
            log.Clear();
            karpetaIrekiB.Enabled = false;
            egoera.Text = "Esportatzen...";
            try
            {
                string argumentuak = "esportatu " + probintzia.Kodea + " " + herria.Kodea + " \"--irteera=" + irteera + "\"";
                JavaEmaitza emaitza = await JavaProzesua.ExekutatuAsync(JavaAjustes.Karpeta, argumentuak, Idatzi);

                switch (emaitza.IrteeraKodea)
                {
                    case JavaProzesua.Ondo:
                        egoera.Text = "Esportazioa amaituta.";
                        karpetaIrekiB.Enabled = true;
                        string laburpena = emaitza.Irteera
                            .Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                            .FirstOrDefault(l => l.StartsWith("Esportazioa amaituta")) ?? "Esportazioa amaituta.";
                        MessageBox.Show(this, laburpena + "\n\nFitxategiak: " + irteera, "Euskanp",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case JavaProzesua.DaturikEz:
                        egoera.Text = "Ez dago kanpinik.";
                        MessageBox.Show(this, "Ez dago kanpinik aukeratutako lekuan.", "Euskanp",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        egoera.Text = "Errorea esportatzean.";
                        MessageBox.Show(this, "Errorea esportatzean:\n\n" + JavaProzesua.AkatsMezua(emaitza), "Euskanp",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            finally
            {
                Okupatuta(false);
            }
        }
    }
}