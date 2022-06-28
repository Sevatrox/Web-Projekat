using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class Vlasnik : Korisnik
    {
        public List<FitnesCentar> VlasnikFitnesCentri { get; set; }

        public Vlasnik(string korisnickoIme, string lozinka, string ime, string prezime, string pol, string email, DateTime datumRodjenja, Uloga uloga, List<FitnesCentar> vlasnikFitnesCentri)
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
            VlasnikFitnesCentri = new List<FitnesCentar>();
            VlasnikFitnesCentri = vlasnikFitnesCentri;
        }

        public Vlasnik() { }
    }
}