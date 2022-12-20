using DAL_.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL_.Context
{
    public partial class Base : DbContext
    {
        #region Constructors
        public Base() : base("name=BaseConnString")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public Base(string connString) : base("name=" + connString)
        {
            Configuration.LazyLoadingEnabled = false;
        }
        #endregion

        #region DBSets
        public virtual DbSet<EMPRESA> EMPRESA { get; set; }
        #endregion
    }
}
