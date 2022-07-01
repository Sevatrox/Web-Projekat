using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class Posetilac : Korisnik
    {
        public List<int> ListaTreningaPosetioca { get; set; }

        public Posetilac(string korisnickoIme, string lozinka, string ime, string prezime, string pol, string email, string datumRodjenja, Uloga uloga, List<int> listaTreningaPosetioca)
        {
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
            Ime = ime;
            Prezime = prezime;
            Pol = pol;
            Email = email;
            DatumRodjenja = datumRodjenja;
            Uloga = uloga;
            ListaTreningaPosetioca = listaTreningaPosetioca;
        }

        public Posetilac() { }
    }
}