using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public enum TipTreninga { YOGA, LES_MILLS_TONE, BODY_PUMP};
    public class GrupniTrening
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public TipTreninga TipTreninga { get; set; }
        public FitnesCentar FitnesCentar { get; set; }
        public int TrajanjeTreninga { get; set; }
        public string DatumVremeneTreninga { get; set; }
        public int MaxBrojPosetilaca { get; set; }
        public List<int> SpisakPosetilaca { get; set; }
        public Trener Trener { get; set; }

        public GrupniTrening(string naziv, TipTreninga tipTreninga, FitnesCentar fitnesCentar, int trajanjeTreninga, DateTime datumVremeneTreninga, int maxBrojPosetilaca, List<int> spisakPosetilaca, Trener trener)
        {
            Naziv = naziv;
            TipTreninga = tipTreninga;
            FitnesCentar = fitnesCentar;
            TrajanjeTreninga = trajanjeTreninga;
            string format = datumVremeneTreninga.ToString("dd/MM/yyyy HH:mm");
            DatumVremeneTreninga = format;
            MaxBrojPosetilaca = maxBrojPosetilaca;
            SpisakPosetilaca = spisakPosetilaca;
            Trener = trener;
        }

        public GrupniTrening() { }
    }
}