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

        public class Parametri
        {
            public int idKorisnika { get; set; }
            public int idTreninga { get; set; }
            public Parametri() { }
            public Parametri(int string1, int string2) { idKorisnika = string1; idTreninga = string2; }
        }

        public List<Posetilac> Get()
        {
            return PosetilacManager.GetList();
        }

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
        public IHttpActionResult Put(Posetilac posetilac)
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
            if (PosetilacManager.FindIfExitsById(posetilac.Id, posetilac.KorisnickoIme) || TrenerManager.FindByUsername(posetilac.KorisnickoIme) || VlasnikManager.FindByUsername(posetilac.KorisnickoIme))
            {
                return BadRequest();
            }
            return Ok(PosetilacManager.UpdatePosetilac(posetilac));
        }
        [HttpDelete]
        public IHttpActionResult Delete(Posetilac posetilac)
        {
            if (posetilac.Id == 0)
                return BadRequest();
            else
                return Ok(PosetilacManager.RemovePosetilac(posetilac));
        }
    }
}
