using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Presentacion
{
    public class ABMTerritories : IHttpHandler
    {
        SolverTerritories solver = new SolverTerritories();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";

            context.Response.Write(solver.GetTerritories());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}