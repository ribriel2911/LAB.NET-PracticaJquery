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
        private DataTable regiones;
        private DAO<Region> dao;

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

            foreach(DataRow r in regiones.Rows)
            {
                ret.Add((string) r["RegionDescription"]);
            }

            return ret;
        }

        public Region BuscarDescripcion(string description)
        {
            Region ret = null;

            DataRow[] rows = regiones.Select(String.Format("RegionDescription='{0}'",description));

            if (rows.Length != 0)
            {
                DataRow row = rows[0];

                ret = new Region
                {
                    RegionID = (int)row["RegionID"],
                    RegionDescription = (string)row["RegionDescription"]
                };
            }

            return ret;
        }

        internal Region BuscarId(int id)
        {
            Region ret = null;

            DataRow[] rows = regiones.Select(String.Format("RegionID='{0}'",id));

            if (rows.Length != 0)
            {
                DataRow row = rows[0];

                ret = new Region
                {
                    RegionID = (int)row["RegionID"],
                    RegionDescription = (string)row["RegionDescription"]
                };
            }

            return ret;
        }
    }
}
