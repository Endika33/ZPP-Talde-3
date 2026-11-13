using System.Diagnostics;

namespace ErronkaT3
{
    /// <summary>"Esportatu" leihoa: probintzia eta herria aukeratu eta Java programarekin CSV eta XML sortzen ditu.</summary>
    public partial class EsportatuForm : Form
    {
        private List<Herria> herriak = new();
        private bool kargatuta;
        private bool okupatuta;

     
        public EsportatuForm()
        {
            InitializeComponent(); 
            formatuaCombo.Items.AddRange(new object[] { "CSV eta XML", "CSV", "XML" });
            formatuaCombo.SelectedIndex = 0;

            irteeraBox.Text = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Euskanp", "esportazioak");
            esportatuB.Enabled = false;
            karpetaIrekiB.Enabled = false;
            CancelButton = itxiB;

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

            
            int formatua = formatuaCombo.SelectedIndex;

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
                        // El Java genera los dos formatos: se elimina el que no se ha elegido
                        try
                        {
                            if (formatua == 1)
                                foreach (var f in Directory.GetFiles(irteera, "*.xml")) File.Delete(f);
                            else if (formatua == 2)
                                foreach (var f in Directory.GetFiles(irteera, "*.csv")) File.Delete(f);
                        }
                        catch (IOException) { }
                        catch (UnauthorizedAccessException) { }

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
