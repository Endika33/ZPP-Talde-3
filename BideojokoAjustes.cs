using System.ComponentModel;
using System.Diagnostics;

namespace ErronkaT3
{
    /// <summary>
    /// Bideojokoaren (Unity, Camping2.exe) kokapena eta abiarazlea.
    /// Lehentasun-ordena: EUSKANP_JOKOA ingurune-aldagaia, erabiltzaileak aukeratutako .exe (gordeta),
    /// Documents\Euskanp\Bideojokoa\Camping2.exe eta aplikazioaren ondoko "bideojokoa" karpeta.
    /// </summary>
    public static class BideojokoAjustes
    {
        public const string ExeIzena = "Camping2.exe";

        private static readonly string AjusteFitxategia = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Euskanp", "bideojokoa-exe.txt");

        private static IEnumerable<string> Hautagaiak()
        {
            string? ingurunea = Environment.GetEnvironmentVariable("EUSKANP_JOKOA");
            if (!string.IsNullOrWhiteSpace(ingurunea))
            {
                yield return ingurunea;
            }

            string? gordeta = null;
            try
            {
                if (File.Exists(AjusteFitxategia))
                {
                    gordeta = File.ReadAllText(AjusteFitxategia).Trim();
                }
            }
            catch (IOException) { }
            catch (UnauthorizedAccessException) { }
            if (!string.IsNullOrWhiteSpace(gordeta))
            {
                yield return gordeta;
            }

            yield return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Euskanp", "Bideojokoa", ExeIzena);
            yield return Path.Combine(AppContext.BaseDirectory, "bideojokoa", ExeIzena);
        }

        private static string? Aurkitu() => Hautagaiak().FirstOrDefault(File.Exists);

        private static void Gorde(string bidea)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(AjusteFitxategia)!);
                File.WriteAllText(AjusteFitxategia, bidea);
            }
            catch (IOException) { }
            catch (UnauthorizedAccessException) { }
        }

        /// <summary>
        /// Jokoa abiarazten du. .exe-a aurkitzen ez bada, erabiltzaileari aukeratzeko eskatzen dio.
        /// </summary>
        public static void Abiarazi(IWin32Window? jabea)
        {
            string? exe = Aurkitu();
            if (exe == null)
            {
                MessageBox.Show(jabea,
                    "Ez da bideojokoa aurkitu (" + ExeIzena + ").\nAukeratu jokoaren .exe fitxategia.",
                    "Euskanp", MessageBoxButtons.OK, MessageBoxIcon.Information);

                using var elkarrizketa = new OpenFileDialog
                {
                    Title = "Aukeratu " + ExeIzena,
                    Filter = "Bideojokoa (" + ExeIzena + ")|" + ExeIzena + "|Aplikazioak (*.exe)|*.exe",
                    CheckFileExists = true
                };
                if (elkarrizketa.ShowDialog(jabea) != DialogResult.OK)
                {
                    return;
                }

                exe = elkarrizketa.FileName;
                Gorde(exe);
            }

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = exe,
                    WorkingDirectory = Path.GetDirectoryName(exe)!,
                    UseShellExecute = true
                });
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show(jabea, "Ezin izan da bideojokoa abiarazi:\n" + ex.Message, "Euskanp",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
