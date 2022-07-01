using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebProjekat.Models;

namespace WebProjekat.Controllers
{
    public class FitnesCentarController : ApiController
    {
        public List<FitnesCentar> Get()
        {
            return FitnesCentarManager.GetList();
        }
        public FitnesCentar Get(int id)
        {
            return FitnesCentarManager.FindById(id);
        }

    }
}
