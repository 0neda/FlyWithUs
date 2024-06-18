using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyWithUs.Controllers;
using FlyWithUs.Models;
using FlyWithUs.Utils;
using MySql.Data.MySqlClient;

namespace FlyWithUs.Repositories
{
    internal class SeatRepository
    {
        public List<Seat> RetrieveSeats()
        {
            List<Seat> retSeats = new List<Seat>();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM POLTRONA";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    PlaneRepository planeRepository = new PlaneRepository();
                    SeatController seatController = new SeatController();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int seatId = reader.GetInt16("Id");
                            string seatClass = reader.GetString("Classe");
                            bool isVacant = reader.GetBoolean("Esta_Vaga");
                            string localization = reader.GetString("Localizacao");
                            int planeId = reader.GetInt16("FK_ID_AERONAVE");
                            Plane plane = new Plane();

                            foreach (var p in planeRepository.RetrievePlanes())
                            {
                                if (p.Id == planeId)
                                {
                                    plane = p;
                                }
                            }
                            retSeats.Add(new Seat(seatId, seatClass, localization, isVacant, plane));
                        }
                    }
                }
                return retSeats;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"[ERRO]: {ex.Message}");
            }
            return retSeats;
        }
    }
}
