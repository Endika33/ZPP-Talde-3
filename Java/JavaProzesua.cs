using System.Diagnostics;
using System.Text;

// <summary>Java programaren prozesua exekutatzeko eta bere irteera-kodea itzultzeko.</summary>
namespace ErronkaT3
{
    /// <summary>Java programaren emaitza: irteera-kodea eta idatzitako testua.</summary>
    public record JavaEmaitza(int IrteeraKodea, string Irteera, string Akatsak)
    {
        public bool Ondo => IrteeraKodea == JavaProzesua.Ondo;
    }

    public record Probintzia(int Kodea, string Izena)
    {
        public override string ToString() => Izena;
    }

    public record Herria(int ProbintziaKodea, int Kodea, string Izena)
    {
        public override string ToString() => Izena;
    }

    /// <summary>
    /// Java programa (kanpinak.jar) prozesu gisa exekutatzen du eta bere irteera-kodea itzultzen du.
    /// Irteera-kodeak: 0 ondo | 1 errorea | 2 argumentu okerrak | 3 daturik ez | -1 Java ez dago.
    /// </summary>
    public static class JavaProzesua
    {
        public const int Ondo = 0;
        public const int Errorea = 1;
        public const int ArgumentuOkerrak = 2;
        public const int DaturikEz = 3;
        public const int JavaEzDaAurkitu = -1;

        /// <param name="karpeta">kanpinak.jar eta KONFIGURAZIOA.txt dauden karpeta (lan-karpeta)</param>
        /// <param name="argumentuak">adib. "inportatu" edo "esportatu 20 0"</param>
        /// <param name="lerroBakoitzeko">Javak lerro bat idazten duen bakoitzean deitzen da (hari ezberdin batetik!)</param>
        public static async Task<JavaEmaitza> ExekutatuAsync(string karpeta, string argumentuak, Action<string>? lerroBakoitzeko = null)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "java",
                Arguments = "-Dfile.encoding=UTF-8 -Dstdout.encoding=UTF-8 -Dstderr.encoding=UTF-8 " +
                            "-Duser.language=es -Duser.country=ES -jar " + JavaAjustes.JarIzena + " " + argumentuak,
                WorkingDirectory = karpeta,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                StandardOutputEncoding = Encoding.UTF8,
                StandardErrorEncoding = Encoding.UTF8
            };

            var irteera = new StringBuilder();
            var akatsak = new StringBuilder();

            using var prozesua = new Process { StartInfo = psi };
            prozesua.OutputDataReceived += (_, e) =>
            {
                if (e.Data is null) return;
                lock (irteera) { irteera.AppendLine(e.Data); }
                lerroBakoitzeko?.Invoke(e.Data);
            };
            prozesua.ErrorDataReceived += (_, e) =>
            {
                if (e.Data is null) return;
                lock (akatsak) { akatsak.AppendLine(e.Data); }
                lerroBakoitzeko?.Invoke(e.Data);
            };

            try
            {
                prozesua.Start();
            }
            catch (System.ComponentModel.Win32Exception)
            {
                return new JavaEmaitza(JavaEzDaAurkitu, "",
                    "Ez da Java aurkitu. Instalatu Java (JRE/JDK) eta egiaztatu PATH aldagaian dagoela.");
            }

            prozesua.BeginOutputReadLine();
            prozesua.BeginErrorReadLine();
            await prozesua.WaitForExitAsync();

            string irteeraTestua;
            string akatsTestua;
            lock (irteera) { irteeraTestua = irteera.ToString(); }
            lock (akatsak) { akatsTestua = akatsak.ToString(); }
            return new JavaEmaitza(prozesua.ExitCode, irteeraTestua, akatsTestua);
        }

        /// <summary>Errore baten mezu ulergarria (idazkariarentzat).</summary>
        public static string AkatsMezua(JavaEmaitza emaitza)
        {
            if (emaitza.IrteeraKodea == JavaEzDaAurkitu)
            {
                return emaitza.Akatsak;
            }

            string guztia = emaitza.Akatsak + Environment.NewLine + emaitza.Irteera;
            if (guztia.Contains("ORA-00001"))
            {
                return "Datuak dagoeneko inportatuta daude datu-basean.";
            }
            if (guztia.Contains("ORA-01017"))
            {
                return "Datu-baseko erabiltzailea edo pasahitza okerra da (KONFIGURAZIOA.txt).";
            }
            if (guztia.Contains("IO Error") || guztia.Contains("ORA-12541") || guztia.Contains("ORA-12514")
                || guztia.Contains("Connection refused"))
            {
                return "Ezin da datu-basera konektatu. Egiaztatu Oracle martxan dagoela.";
            }
            if (emaitza.IrteeraKodea == ArgumentuOkerrak)
            {
                return "Argumentu okerrak Java programari deitzean.";
            }

            string? lerroa = emaitza.Akatsak
                .Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .FirstOrDefault(l => l.StartsWith("Errorea"));
            if (lerroa is not null)
            {
                return lerroa;
            }
            return emaitza.Akatsak.Trim().Length > 0
                ? emaitza.Akatsak.Trim()
                : "Errore ezezaguna (irteera-kodea " + emaitza.IrteeraKodea + ").";
        }
    }

    /// <summary>"zerrendatu" aginduaren irteera irakurtzen du: "P;kodea;izena" eta "H;probintzia;kodea;izena".</summary>
    public static class Kokalekuak
    {
        public static (List<Probintzia> Probintziak, List<Herria> Herriak) Irakurri(string testua)
        {
            var probintziak = new List<Probintzia>();
            var herriak = new List<Herria>();

            foreach (string lerroa in testua.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                string[] zatiak = lerroa.Split(';');
                if (zatiak.Length >= 3 && zatiak[0] == "P" && int.TryParse(zatiak[1], out int probintziaKodea))
                {
                    probintziak.Add(new Probintzia(probintziaKodea, string.Join(';', zatiak.Skip(2))));
                }
                else if (zatiak.Length >= 4 && zatiak[0] == "H"
                         && int.TryParse(zatiak[1], out int herriProbintzia) && int.TryParse(zatiak[2], out int herriKodea))
                {
                    herriak.Add(new Herria(herriProbintzia, herriKodea, string.Join(';', zatiak.Skip(3))));
                }
            }
            return (probintziak, herriak);
        }
    }
}