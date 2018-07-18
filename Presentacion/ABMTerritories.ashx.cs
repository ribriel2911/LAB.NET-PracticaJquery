using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion
{
    /// <summary>
    /// Descripción breve de ABMTerritories
    /// </summary>
    public class ABMTerritories : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "texto/normal";
            context.Response.Write("Hola a todos");
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