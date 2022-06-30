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
        public List<GrupniTrening> Get()
        {
            //List<FitnesCentar> lista = (List<FitnesCentar>)HttpContext.Current.Application["fitnesCentri"];
            return GrupniTreningManager.GetList();
            //return lista;
        }
        public List<GrupniTrening> Get(int id)
        {
            //List<FitnesCentar> lista = (List<FitnesCentar>)HttpContext.Current.Application["fitnesCentri"];
            return GrupniTreningManager.GetListByCentar(id);
            //return lista;
        }
    }
}
