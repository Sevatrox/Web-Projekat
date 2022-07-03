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

        public IHttpActionResult Post(FitnesCentar centar)
        {
            if (FitnesCentarManager.FindByName(centar))
            {
                return BadRequest();
            }
            else
                return Ok(FitnesCentarManager.AddFitnesCentar(centar));
        }

        public IHttpActionResult Put(FitnesCentar centar)
        {
            if (centar.Id == 0)
            {
                return BadRequest();
            }
            if(centar.Naziv != null)
            {
                return Ok(FitnesCentarManager.UpdateCentar(centar));
            }
            return Ok(FitnesCentarManager.DeleteCentar(centar));
        }
    }
}
