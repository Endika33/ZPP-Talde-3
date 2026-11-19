using System;
using System.Collections.Generic;
using System.Text;

//Bezeroaren datuak gordetzeko klasea

namespace ErronkaT3.Modelos
{
   public class BezeroDatuak
    {
        public int Id { get; set; }
        public string Izena { get; set; } = "";
        public string Abizenak { get; set; } = "";
        public string Emaila { get; set; } = "";
        public string Telefonoa { get; set; } = "";
        public string ostatuMota { get; set; } = "";
        public string sortzeEguna { get; set; } = "";
    }
}
