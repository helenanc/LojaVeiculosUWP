using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaApp.Models
{
    class Veiculo
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public double Preco { get; set; }
        public bool Vendido { get; set; }
        public int IdFabricante { get; set; }
        public Fabricante Fabricante { get; set; }
        public override string ToString()
        {
            return $"{Id} - {Fabricante} - {Modelo} - {Ano} - {Preco:0.00}";
        }
    }
}
