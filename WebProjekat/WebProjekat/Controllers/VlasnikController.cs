using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebProjekat.Models;

namespace WebProjekat.Controllers
{
    public class VlasnikController : ApiController
    {
        public IHttpActionResult Put(Vlasnik vlasnik)
        {
            if (vlasnik == null)
            {
                return BadRequest();
            }
            if (vlasnik.KorisnickoIme == null || vlasnik.KorisnickoIme.Length == 0)
            {
                return BadRequest();
            }
            if (vlasnik.Lozinka == null || vlasnik.Lozinka.Length == 0)
            {
                return BadRequest();
            }
            if (VlasnikManager.FindIfExitsById(vlasnik.Id, vlasnik.KorisnickoIme) || PosetilacManager.FindByUsername(vlasnik.KorisnickoIme) || TrenerManager.FindByUsername(vlasnik.KorisnickoIme))
            {
                return BadRequest();
            }
            return Ok(VlasnikManager.UpdateVlasnik(vlasnik));
        }
    }
}
