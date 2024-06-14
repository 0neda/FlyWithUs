using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAviação.Models
{
    internal class Seat
    {
        public enum SeatClass
        {
            Eco = 1,
            First = 2,
            Luxo = 3
        }
        public enum SeatLocalization
        {
            Window = 1,
            Corridor = 2,
            Right = 3,
            Left = 4,
            Center = 5
        }

        public int Id { get; set; }
        public required SeatClass Class { get; set; }
        public required SeatLocalization Localization { get; set; }
        public required bool IsVacant { get; set; }
        public required Plane Plane { get; set; }
    }
}
