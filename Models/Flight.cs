using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAviação.Models
{
    internal class Flight
    {
        public int Id { get; set; }
        public Plane Plane { get; set; }
        public Airport Departure { get; set; }
        public Airport Destination { get; set; }
        public DateTime DepartureDate{ get; set; }
        public DateTime ArrivalDate { get; set; }
    }
}
