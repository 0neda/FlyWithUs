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
