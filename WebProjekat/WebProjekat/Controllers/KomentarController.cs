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
        public List<Komentar> Get(string naziv)
        {
            return KomentarManager.GetListByCentar(naziv);
        }
        public IHttpActionResult Post(Komentar komentar)
        {
            return Ok(KomentarManager.AddKomentar(komentar));
        }
    }
}
