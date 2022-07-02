using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebProjekat.Models;

namespace WebProjekat.Controllers
{
    public class KorisnikController : ApiController
    {
        public class Parametri
        {
            public string KorisnickoIme { get; set; }
            public string Lozinka { get; set; }
            public Parametri() { }
            public Parametri(string string1, string string2) { KorisnickoIme = string1; Lozinka = string2; }
        }
        public IHttpActionResult Post(Parametri test)
        {
            if (PosetilacManager.FindAccount(test.KorisnickoIme, test.Lozinka) != null)
                return Ok(PosetilacManager.FindAccount(test.KorisnickoIme, test.Lozinka));

            else if (TrenerManager.FindAccount(test.KorisnickoIme, test.Lozinka) != null)
                return Ok(TrenerManager.FindAccount(test.KorisnickoIme, test.Lozinka));

            else if (VlasnikManager.FindAccount(test.KorisnickoIme, test.Lozinka) != null)
                return Ok(VlasnikManager.FindAccount(test.KorisnickoIme, test.Lozinka));

            return BadRequest();
        }
    }
}
