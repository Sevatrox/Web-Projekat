using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class Trener : Korisnik
    {
        public List<GrupniTrening> listaTreningaTrenera = new List<GrupniTrening>();
        public FitnesCentar AngazovanFitnesCentar { get; set; }

        public Trener(string korisnickoIme, string lozinka, string ime, string prezime, char pol, string email, DateTime datumRodjenja, Uloga uloga, FitnesCentar angazovanFitnesCentar)
        {
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
            Ime = ime;
            Prezime = prezime;
            Pol = pol;
            Email = email;
            DatumRodjenja = datumRodjenja;
            Uloga = uloga;
            AngazovanFitnesCentar = angazovanFitnesCentar;
        }
    }
}