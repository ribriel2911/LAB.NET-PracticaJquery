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
            string method = context.Request.QueryString["MethodName"];
            context.Response.ContentType = "application/json";

            switch (method)
            {
                case "GetTerritories":
                    context.Response.Write(solver.GetTerritories());
                    break;

                case "GetRegions":
                    context.Response.Write(solver.GetRegiones);
                    break;
            }

            
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