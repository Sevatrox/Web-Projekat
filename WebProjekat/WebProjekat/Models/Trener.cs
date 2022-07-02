﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class Trener : Korisnik
    {
        public List<int> ListaTreningaTrenera { get; set; }
        public FitnesCentar AngazovanFitnesCentar { get; set; }

        public Trener(string korisnickoIme, string lozinka, string ime, string prezime, string pol, string email, string datumRodjenja, Uloga uloga, FitnesCentar angazovanFitnesCentar, List<int> listaTreningaTrenera, int id = 0)
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
            ListaTreningaTrenera = listaTreningaTrenera;
            Id = id;
        }

        public Trener() { }
    }
}