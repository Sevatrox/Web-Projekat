using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class Trener : Korisnik
    {
        public List<int> ListaTreningaTrenera { get; set; }
        public FitnesCentar AngazovanFitnesCentar { get; set; }

        public Trener(string korisnickoIme, string lozinka, string ime, string prezime, string pol, string email, DateTime datumRodjenja, Uloga uloga, FitnesCentar angazovanFitnesCentar, List<int> listaTreningaTrenera)
        {
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
            Ime = ime;
            Prezime = prezime;
            Pol = pol;
            Email = email;
            string format = datumRodjenja.ToString("dd/MM/yyyy");
            DatumRodjenja = format;
            Uloga = uloga;
            AngazovanFitnesCentar = angazovanFitnesCentar;
            ListaTreningaTrenera = listaTreningaTrenera;
        }

        public Trener() { }
    }
}