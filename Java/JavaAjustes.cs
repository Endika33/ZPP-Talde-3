

//java programaren karpetaren kokapena (kanpinak.jar, lib\ojdbc11.jar eta KONFIGURAZIOA.txt dauden "dist" karpeta).
namespace ErronkaT3
{
    /// <summary>
    /// Java programaren karpetaren kokapena (kanpinak.jar, lib\ojdbc11.jar eta KONFIGURAZIOA.txt dauden "dist" karpeta).
    /// Lehentasun-ordena: EUSKANP_JAVA ingurune-aldagaia, erabiltzaileak aukeratutako karpeta (gordeta)
    /// eta, hori ez badago, aplikazioaren ondoko "java" karpeta.
    /// </summary>
    public static class JavaAjustes
    {
        public const string JarIzena = "kanpinak.jar";

        private static readonly string AjusteFitxategia = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Euskanp", "java-karpeta.txt");

        public static string Karpeta { get; private set; } = Kargatu();

        private static string Kargatu()
        {
            string? ingurunea = Environment.GetEnvironmentVariable("EUSKANP_JAVA");
            if (!string.IsNullOrWhiteSpace(ingurunea))
            {
                return ingurunea;
            }

            try
            {
                if (File.Exists(AjusteFitxategia))
                {
                    string gordeta = File.ReadAllText(AjusteFitxategia).Trim();
                    if (gordeta.Length > 0)
                    {
                        return gordeta;
                    }
                }
            }
            catch (IOException) { }
            catch (UnauthorizedAccessException) { }

            return Path.Combine(AppContext.BaseDirectory, "java");
        }

        public static bool Baliozkoa(string? karpeta) =>
            !string.IsNullOrWhiteSpace(karpeta) && File.Exists(Path.Combine(karpeta, JarIzena));

        public static void Aldatu(string karpeta)
        {
            Karpeta = karpeta;
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(AjusteFitxategia)!);
                File.WriteAllText(AjusteFitxategia, karpeta);
            }
            catch (IOException) { }
            catch (UnauthorizedAccessException) { }
        }

        /// <summary>
        /// Karpeta baliozkoa dagoela ziurtatzen du; bestela, erabiltzaileari aukeratzeko eskatzen dio.
        /// </summary>
        public static bool Ziurtatu(IWin32Window? jabea)
        {
            if (Baliozkoa(Karpeta))
            {
                return true;
            }

            MessageBox.Show(jabea,
                "Ez da Java programaren karpeta aurkitu (" + JarIzena + ").\nAukeratu Java proiektuko 'dist' karpeta.",
                "Euskanp", MessageBoxButtons.OK, MessageBoxIcon.Information);

            using var elkarrizketa = new FolderBrowserDialog
            {
                Description = "Aukeratu " + JarIzena + " daukan karpeta (dist)",
                UseDescriptionForTitle = true,
                ShowNewFolderButton = false
            };
            if (elkarrizketa.ShowDialog(jabea) != DialogResult.OK)
            {
                return false;
            }

            if (!Baliozkoa(elkarrizketa.SelectedPath))
            {
                MessageBox.Show(jabea, "Karpeta horretan ez dago " + JarIzena + ".", "Euskanp",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            Aldatu(elkarrizketa.SelectedPath);
            return true;
        }
    }
}