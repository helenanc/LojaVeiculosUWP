using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaApp.Models
{
    class Fabricante
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        //public List<Veiculo> Veiculos;
        public override string ToString()
        {
            return $"{Id} - {Descricao}";
        }
    }
}
