using FlyWithUs.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWithUs.Models
{
    internal class Seat
    {
        SeatController controller = new SeatController();
        public enum SeatClass
        {
            Eco = 1,
            First = 2,
            Deluxe = 3
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
        public SeatClass Class { get; set; }
        public SeatLocalization Localization { get; set; }
        public bool IsVacant { get; set; }
        public Plane Plane { get; set; }

        public Seat (int id, string seatClass, string seatLocalization, bool isVacant, Plane plane)
        {
            Id = id;
            Class = controller.ConvertToSeatClass(seatClass);
            Localization = controller.ConvertToSeatLocalization(seatLocalization);
            IsVacant = isVacant;
            Plane = plane;
        }
    }
}
