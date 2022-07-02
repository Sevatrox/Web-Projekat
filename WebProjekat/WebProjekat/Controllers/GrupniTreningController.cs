using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebProjekat.Models;

namespace WebProjekat.Controllers
{
    public class GrupniTreningController : ApiController
    {
        public class Parametri
        {
            public int idKorisnika { get; set; }
            public int idTreninga { get; set; }
            public Parametri() { }
            public Parametri(int string1, int string2) { idKorisnika = string1; idTreninga = string2; }
        }

        public List<GrupniTrening> Get()
        {
            return GrupniTreningManager.GetList();
        }

        public List<GrupniTrening> Get(int id)
        {
            return GrupniTreningManager.GetListByCentar(id);
        }

        public IHttpActionResult Put(Parametri test)
        {
            if (test.idKorisnika == 0 || test.idTreninga == 0)
            {
                return BadRequest();
            }
            return Ok(GrupniTreningManager.UpdateTrening(test.idKorisnika, test.idTreninga));
        }
    }
}
