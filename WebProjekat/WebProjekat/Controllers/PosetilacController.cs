using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebProjekat.Models;

namespace WebProjekat.Controllers
{
    public class PosetilacController : ApiController
    {
        public IHttpActionResult Post(Posetilac posetilac)
        {
            if (posetilac == null)
            {
                return BadRequest();
            }
            if (posetilac.KorisnickoIme == null || posetilac.KorisnickoIme.Length == 0)
            {
                return BadRequest();
            }
            if (posetilac.Lozinka == null || posetilac.Lozinka.Length == 0)
            {
                return BadRequest();
            }
            if(PosetilacManager.FindByUsername(posetilac.KorisnickoIme) || TrenerManager.FindByUsername(posetilac.KorisnickoIme) || VlasnikManager.FindByUsername(posetilac.KorisnickoIme))
            {
                return BadRequest();
            }
            return Ok(PosetilacManager.AddPosetilac(posetilac));
        }
    }
}
