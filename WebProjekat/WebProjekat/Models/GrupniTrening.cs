using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public enum TipTreninga { YOGA, LES_MILLS_TONE, BODY_PUMP};
    public class GrupniTrening
    {
        public string Naziv { get; set; }
        public TipTreninga TipTreninga { get; set; }
        public FitnesCentar FitnesCentar { get; set; }
        public int TrajanjeTreninga { get; set; }
        public DateTime DatumVremeneTreninga { get; set; }
        public int MaxBrojPosetilaca { get; set; }
        List<Posetilac> spisakPosetilaca = new List<Posetilac>();

        public GrupniTrening(string naziv, TipTreninga tipTreninga, FitnesCentar fitnesCentar, int trajanjeTreninga, DateTime datumVremeneTreninga, int maxBrojPosetilaca, List<Posetilac> spisakPosetilaca)
        {
            Naziv = naziv;
            TipTreninga = tipTreninga;
            FitnesCentar = fitnesCentar;
            TrajanjeTreninga = trajanjeTreninga;
            DatumVremeneTreninga = datumVremeneTreninga;
            MaxBrojPosetilaca = maxBrojPosetilaca;
            this.spisakPosetilaca = spisakPosetilaca;
        }

        public GrupniTrening() { }
    }
}