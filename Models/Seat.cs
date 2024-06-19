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
            Class = ConvertToSeatClass(seatClass);
            Localization = ConvertToSeatLocalization(seatLocalization);
            IsVacant = isVacant;
            Plane = plane;
        }

        // Método para converter a string da classe da poltrona para o ENUM criado
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

        // Método para converter a string da localização da poltrona para o ENUM criado
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
