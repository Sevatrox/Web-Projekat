using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebProjekat.Models;

namespace WebProjekat.Controllers
{
    public class TrenerController : ApiController
    {
        public IHttpActionResult Put(Trener trener)
        {
            if (trener == null)
            {
                return BadRequest();
            }
            if (trener.KorisnickoIme == null || trener.KorisnickoIme.Length == 0)
            {
                return BadRequest();
            }
            if (trener.Lozinka == null || trener.Lozinka.Length == 0)
            {
                return BadRequest();
            }
            if (TrenerManager.FindIfExitsById(trener.Id, trener.KorisnickoIme) || PosetilacManager.FindByUsername(trener.KorisnickoIme) || VlasnikManager.FindByUsername(trener.KorisnickoIme))
            {
                return BadRequest();
            }
            return Ok(TrenerManager.UpdateTrener(trener));
        }
    }
}
