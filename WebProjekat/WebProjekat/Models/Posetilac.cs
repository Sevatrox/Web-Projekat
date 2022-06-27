using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class Posetilac : Korisnik
    {
        public List<GrupniTrening> listaTreningaPosetioca = new List<GrupniTrening>();

        public Posetilac(string korisnickoIme, string lozinka, string ime, string prezime, char pol, string email, DateTime datumRodjenja, Uloga uloga)
        {
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
            Ime = ime;
            Prezime = prezime;
            Pol = pol;
            Email = email;
            DatumRodjenja = datumRodjenja;
            Uloga = uloga;
        }
    }
}