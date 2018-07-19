using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RegionDAO : DAO<Region>
    {
        NorthwindEntities contexto;

        public RegionDAO()
        {
            contexto = new NorthwindEntities();
            contexto.Configuration.ProxyCreationEnabled = false;
        }

        public void Create(Region r)
        {
                Region region = r;

                var query = contexto.Region.Where(c => c.RegionID == region.RegionID);

                /* var query = from reg in contexto.Region
                            where reg.RegionID == region.RegionID
                            select new
                            {
                                RegionID = reg.RegionID,
                                RegionDescription = region.RegionDescription
                            };
                */

                if (query.Any())
                {
                    region.RegionID = contexto.Region.ToList().Max(c => c.RegionID) + 1;
                }

                contexto.Region.Add(region);

                contexto.SaveChanges();
        }

        public void Delete(Region r)
        {

                Region region = r;

                if (contexto.Region.Contains(region)) {

                    contexto.Region.Remove(region);
                }
                
                contexto.SaveChanges();

        }

        public List<Region> GetList()
        {
            List<Region> regs = null;


                regs = contexto.Region.ToList();

                contexto.SaveChanges();


            return regs;
        }

        public Region Search(string desc)
        {
            Region ret = null;
            var query = contexto.Region.Where(c => c.RegionDescription == desc);
           foreach(var c in query)
            {
                ret = new Region();
                ret.RegionID = c.RegionID;
                ret.RegionDescription = c.RegionDescription;
            }
            return ret;
        }

        public void Update(Region r)
        {

                Region region = r;

                var query = contexto.Region.Where(c => c.RegionID==region.RegionID);

                foreach (var c in query)
                {
                    c.RegionDescription = region.RegionDescription;
                }

                contexto.SaveChanges();

        }

        public void Attach(Region r)
        {

                Region region = r;

                var query = contexto.Region.Max(c => c.RegionID) + 1;

                region.RegionID = query;

                contexto.Region.Attach(region);

                contexto.SaveChanges();

        }
    }
}
