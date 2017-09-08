using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace Onde_esta_meu_carro.Src.Class
{
    public class Vehicle : Model
    {

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set;  }

        [Column(CanBeNull = false)]
        public String Name { get; set; }

    }
}
