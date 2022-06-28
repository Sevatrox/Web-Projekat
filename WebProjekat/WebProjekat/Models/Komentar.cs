using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class Komentar
    {

        public Posetilac Posetilac { get; set; }
        public FitnesCentar FitnesCentar { get; set; }
        public string TekstKomentara { get; set; }

        public Komentar(Posetilac posetilac, FitnesCentar fitnesCentar, string tekstKomentara)
        {
            Posetilac = posetilac;
            FitnesCentar = fitnesCentar;
            TekstKomentara = tekstKomentara;
        }

        public Komentar() { }
    }
}