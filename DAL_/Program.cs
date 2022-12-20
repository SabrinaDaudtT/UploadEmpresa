using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL_
{
    public partial class LabetCadastros : DbContext
    {
        public LabetCadastros() : base("name=CadastroConnString")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public LabetCadastros(string connString) : base("name=" + connString)
        {
            Configuration.LazyLoadingEnabled = false;
        }

    }
}
