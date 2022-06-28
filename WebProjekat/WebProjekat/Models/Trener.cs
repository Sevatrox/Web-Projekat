using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class Trener : Korisnik
    {
        public List<GrupniTrening> ListaTreningaTrenera { get; set; }
        public FitnesCentar AngazovanFitnesCentar { get; set; }

        public Trener(string korisnickoIme, string lozinka, string ime, string prezime, string pol, string email, DateTime datumRodjenja, Uloga uloga, FitnesCentar angazovanFitnesCentar, List<GrupniTrening> listaTreningaTrenera)
        {
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
            Ime = ime;
            Prezime = prezime;
            Pol = pol;
            Email = email;
            string format = datumRodjenja.ToString("dd/M/yyyy");
            DatumRodjenja = format;
            Uloga = uloga;
            AngazovanFitnesCentar = angazovanFitnesCentar;
            ListaTreningaTrenera = new List<GrupniTrening>();
            ListaTreningaTrenera = listaTreningaTrenera;
        }

        public Trener() { }
    }
}