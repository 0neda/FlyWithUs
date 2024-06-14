using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAviação.Models
{
    internal class Connection
    {
        public int Id { get; set; }
        public Airport Departure { get; set; }
        public DateTime DepartureDate { get; set; }
        public Flight Flight { get; set; }
    }
}
