using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAviação.Models
{
    internal class FlightTicket
    {
        public int Id { get; set; }
        public Seat Seat { get; set; }
        public Customer Customer { get; set; }
        public Flight Flight { get; set; }
    }
}
