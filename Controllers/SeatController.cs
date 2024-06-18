using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyWithUs.Models;
using FlyWithUs.Repositories;

namespace FlyWithUs.Controllers
{
    internal class SeatController
    {
        public List<Seat> RetrieveSeats (Plane plane)
        {
            PlaneRepository planeRepository = new PlaneRepository ();
            SeatRepository seatRepository = new SeatRepository ();
            List<Seat> retSeats = new List<Seat> ();

            foreach (var p in planeRepository.RetrievePlanes())
            {
                foreach (var s in seatRepository.RetrieveSeats())
                {

                }
            }
            return retSeats;
        }

        public Seat.SeatClass ConvertToSeatClass(string seatClass)
        {
            switch (seatClass.ToString().ToUpperInvariant())
            {
                case "ECONÔMICA":
                    return Seat.SeatClass.Eco;
                case "PRIMEIRA CLASSE":
                    return Seat.SeatClass.First;
                case "LUXO":
                    return Seat.SeatClass.Deluxe;
            };
            return Seat.SeatClass.Eco;
        }

        public Seat.SeatLocalization ConvertToSeatLocalization(string seatLocalization)
        {
            switch (seatLocalization.ToString().ToUpperInvariant())
            {
                case "JANELA":
                    return Seat.SeatLocalization.Window;
                case "CORREDOR":
                    return Seat.SeatLocalization.Corridor;
                case "DIREITA":
                    return Seat.SeatLocalization.Right;
                case "ESQUERDA":
                    return Seat.SeatLocalization.Left;
                case "CENTRO":
                    return Seat.SeatLocalization.Center;
            };
            return Seat.SeatLocalization.Center;
        }
    }
}
