using System.ComponentModel;


//bezeroak egin dituen eskaerak gordetzeko klasea, eskaeraren egoera eta langilea gordetzen dira
namespace ErronkaT3.Modelos
{
    public class Eskaera : INotifyPropertyChanged
    {
        public int BezeroId { get; set; }
        public string Bezeroa { get; set; } = "";
        public string Mota { get; set; } = "";
        public int Segundos { get; set; }

        public bool Ezeztatuta { get; set; }
        private string langilea = "-";
        public string Langilea
        {
            get => langilea;
            set { langilea = value; Aldatu(nameof(Langilea)); }
        }

        private string egoera = "Zain";
        public string Egoera
        {
            get => egoera;
            set { egoera = value; Aldatu(nameof(Egoera)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void Aldatu(string izena) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(izena));
    }
}