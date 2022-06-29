using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class FitnesCentar
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public int GodinaOtvaranja { get; set; }
        public Vlasnik Vlasnik { get; set; }
        public double MesecnaCena { get; set; }
        public double GodisnjaCena { get; set; }
        public double CenaTreninga { get; set; }
        public double CenaGrupnogTreninga { get; set; }
        public double CenaTreningaSaPersonalnim { get; set; }

        public FitnesCentar() { }
    }
}