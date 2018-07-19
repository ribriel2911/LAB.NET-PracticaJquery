using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Negocio
{
    public class SolverRegion
    {
        private RegionDAO dao;

        public SolverRegion()
        {
            dao = new RegionDAO();
        }

        public string GetRegiones()
        {
            string jsonOutput = string.Empty;

            jsonOutput = new JavaScriptSerializer().Serialize(dao.GetList());

            return jsonOutput;
        }

        public void CrearRegion(int id, string description)
        {
            Region r = new Region()
            {
                RegionID = id,
                RegionDescription = description
            };

            dao.Create(r);
        }

        public List<string> Descripciones()
        {
            List<string> ret = new List<string>();

            foreach(Region r in dao.GetList())
            {
                ret.Add((string) r.RegionDescription);
            }

            return ret;
        }

        public Region BuscarDescripcion(string description)
        {
            return dao.Search(description);
        }

        internal Region BuscarId(int id)
        {
            Region ret = null;

            foreach (Region r in dao.GetList())
            {
                if (r.RegionID == id) return r;
            }

            return ret;
        }
    }
}
