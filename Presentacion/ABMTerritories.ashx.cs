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
            string get = context.Request.QueryString["GetMethod"];
                

            switch (get)
            {
                case "Territories":
                    context.Response.Write(solver.GetTerritories());
                    break;

                case "Regions":
                    context.Response.Write(solver.GetRegiones);
                    break;
            }

            string press = context.Request.QueryString["ButtonMethod"];

            string id = context.Request.QueryString["TerritoryID"];
            string description = context.Request.QueryString["TerritoryDescription"];
            string region = context.Request.QueryString["RegionDescription"];

            switch (press)
            {
                case "NewTerritory":
                    solver.CrearTerritory(id, description, region);
                    break;

                case "ModifyTerritory":
                    solver.ModificarTerritory(id, description, region);
                    break;

                case "AttachTerritory":
                    solver.AdjuntarTerritory(id, description, region);
                    break;

                case "DeleteTerritory":
                    solver.BorrarTerritory(id, description, region);
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