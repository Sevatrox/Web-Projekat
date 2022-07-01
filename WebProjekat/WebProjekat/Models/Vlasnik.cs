using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class Vlasnik : Korisnik
    {
        public List<int> VlasnikFitnesCentri { get; set; }

        public Vlasnik(string korisnickoIme, string lozinka, string ime, string prezime, string pol, string email, string datumRodjenja, Uloga uloga, List<int> vlasnikFitnesCentri)
        {
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
            Ime = ime;
            Prezime = prezime;
            Pol = pol;
            Email = email;
            DatumRodjenja = datumRodjenja;
            Uloga = uloga;
            VlasnikFitnesCentri = new List<int>();
            VlasnikFitnesCentri = vlasnikFitnesCentri;
        }

        public Vlasnik() { }
    }
}