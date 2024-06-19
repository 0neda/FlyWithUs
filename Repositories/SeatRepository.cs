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
        // Método para retornar uma lista das poltronas contidas atualmente no BD, já convertidas em objeto de acordo com nosso model
        public static List<Seat> RetrieveSeats()
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
                            int planeId = reader.GetInt16("ID_AERONAVE");
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

        public static bool VerifySeatVacancy (int seatId)
        {
            bool isVacant = false;
            foreach (var s in RetrieveSeats())
            {
                if (s.Id == seatId)
                {
                    if (s.IsVacant)
                    {
                        MessageBox.Show("Reservado!");
                        isVacant = true;
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Poltrona já ocupada!");
                        isVacant = false;
                    }
                }
                else
                {
                    MessageBox.Show("Erro ao verificar se a poltrona está vaga!");
                    isVacant = false;
                }
            }
            return isVacant;
        }

        public static void BookSeat(int seatId)
        {
            bool nextStatus = false;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
                {
                    connection.Open();

                    string selectQuery = "SELECT ESTA_VAGA FROM POLTRONAS WHERE ID = (@seatId)";
                    MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection);
                    selectCommand.Parameters.AddWithValue("@seatId", seatId);

                    using (MySqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bool dbIsVacant = reader.GetBoolean("ESTA_VAGA");

                            if (dbIsVacant)
                            {
                                nextStatus = true;
                            }
                            else
                                nextStatus = false;

                            try
                            {
                                string updateQuery = "UPDATE POLTRONAS SET ESTA_VAGA = (@nextStatus) WHERE ID = (@seatId)";
                                MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                                updateCommand.Parameters.AddWithValue("@seatId", seatId);
                                updateCommand.Parameters.AddWithValue("@nextStatus", nextStatus);

                                updateCommand.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Erro ao atualizar poltrona: " + ex.Message);
                            }
                        }
                        else
                            MessageBox.Show("Poltrona não encontrada!");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro de MySQL: {ex.Message}");
            }
        }
    }
}
