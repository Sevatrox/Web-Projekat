using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class FitnesCentar
    {

        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public int GodinaOtvaranja { get; set; }
        public Korisnik Vlasnik { get; set; }
        public double MesecnaCena { get; set; }
        public double GodisnjaCena { get; set; }
        public double CenaTreninga { get; set; }
        public double CenaGrupnogTreninga { get; set; }
        public double CenaTreningaSaPersonalnim { get; set; }

        public FitnesCentar(string naziv, string adresa, int godinaOtvaranja, Korisnik vlasnik, double mesecnaCena, double godisnjaCena, double cenaTreninga, double cenaGrupnogTreninga, double cenaTreningaSaPersonalnim)
        {
            Naziv = naziv;
            Adresa = adresa;
            GodinaOtvaranja = godinaOtvaranja;
            Vlasnik = vlasnik;
            MesecnaCena = mesecnaCena;
            GodisnjaCena = godisnjaCena;
            CenaTreninga = cenaTreninga;
            CenaGrupnogTreninga = cenaGrupnogTreninga;
            CenaTreningaSaPersonalnim = cenaTreningaSaPersonalnim;
        }
    }
}