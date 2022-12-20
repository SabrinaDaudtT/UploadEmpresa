using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_.Domain
{
    public class EMPRESA
    {
        [Key]
        public int ID { get; set; }
        public string cnpj { get; set; }
        public string nome { get; set; }
        public string fantasia { get; set; }
        public string data_situacao { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string cep { get; set; }
        public string municipio { get; set; }
    }
}
