﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebProjekat.Models;

namespace WebProjekat.Controllers
{
    public class KomentarController : ApiController
    {
        public List<Komentar> Get()
        {
            return KomentarManager.GetList();
        }
        public List<Komentar> Get(int id)
        {
            return KomentarManager.GetListByCentar(id);
        }
        public IHttpActionResult Post(Komentar komentar)
        {
            return Ok(KomentarManager.AddKomentar(komentar));
        }

        public IHttpActionResult Put(Komentar komentar)
        {
            if (komentar.Id == 0)
            {
                return BadRequest();
            }
            return Ok(KomentarManager.UpdateKomentar(komentar));
        }
    }
}
