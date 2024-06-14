using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAviação.Models
{
    internal class Airport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string FederalState { get; set; }
        public string Country { get; set; }
    }
}
