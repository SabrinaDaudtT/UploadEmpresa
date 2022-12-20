using DAL_.Context;
using DAL_.Domain;
using DAL_.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_.Repository
{
    public class EMPRESARepository : Repository<EMPRESA>, IEMPRESARepository
    {
        public EMPRESARepository(Base dbContext) : base(dbContext) { }

    }
}
