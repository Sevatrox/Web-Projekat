using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class Komentar
    {
        public int Id { get; set; }
        public Posetilac Posetilac { get; set; }
        public FitnesCentar FitnesCentar { get; set; }
        public string TekstKomentara { get; set; }
        public int Ocena { get; set; }
        public bool Odobren { get; set; }

        public Komentar(Posetilac posetilac, FitnesCentar fitnesCentar, string tekstKomentara, int ocena, bool odobren = false, int id = 0)
        {
            Posetilac = posetilac;
            FitnesCentar = fitnesCentar;
            TekstKomentara = tekstKomentara;
            Ocena = ocena;
            Odobren = odobren;
            Id = id;
        }

        public Komentar() { }
    }
}