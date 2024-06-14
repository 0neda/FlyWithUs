using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAviação.Models
{
    internal class Suitcase
    {
        public int Id { get; set; }
        public Customer Owner { get; set; }
        public float Weight { get; set; }
        public Flight Flight { get; set; }
    }
}
