using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using FlyWithUs.Models;
using FlyWithUs.Utils;
using System.Xml.Linq;
using static FlyWithUs.Models.Plane;
using FlyWithUs.Controllers;

namespace FlyWithUs.Repositories
{
    internal class PlaneRepository
    {
        // Método para retornar uma lista das aeronaves contidas atualmente no BD, já convertidas em objeto de acordo com nosso model
        public List<Plane> RetrievePlanes()
        {
            List<Plane> retPlanes = new List<Plane>();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM AERONAVE";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt16("ID");
                            string model = reader.GetString("MODELO");
                            string type_db = reader.GetString("TIPO");
                            planeType type;

                            switch (type_db.ToUpperInvariant())
                            {
                                case "HELICÓPTERO":
                                    type = planeType.Helicopter;
                                    break;
                                case "AVIÃO":
                                    type = planeType.Plane;
                                    break;
                                case "JATO":
                                    type = planeType.Jet;
                                    break;
                                default:
                                    type = planeType.Plane;
                                    break;
                            }

                                
                            int companyId = reader.GetInt16("ID_COMPANIA_AEREA");
                            Plane p = new (id, type, model, companyId);
                            retPlanes.Add(p);
                        }
                    }
                }
                return retPlanes;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"[ERRO]: {ex.Message}");
            }
            return retPlanes;
        }

        // Método para inserir uma nova aeronave no BD
        public static bool InsertPlane(int planeType, string planeModel, int planeCompany, ComboBox companyComboBox)
        {
            SeatRepository seatRepository = new SeatRepository();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO AERONAVE (TIPO, MODELO, ID_COMPANIA_AEREA) VALUES (@planeType, @planeModel, @planeCompany)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@planeType", planeType);
                        command.Parameters.AddWithValue("@planeModel", planeModel);
                        command.Parameters.AddWithValue("@planeCompany", planeCompany);

                        try
                        {
                            command.ExecuteNonQuery();
                            return true;
                        }
                        catch (MySqlException ex)
                        {
                            Console.WriteLine($"[ERRO]: {ex.Message}");
                            return false;
                            throw;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"[ERRO]: {ex.Message}");
                return false;
                throw;
            }
        }

        // Método para remover uma aeronave do BD
        public static void DeletePlane(int planeId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
                {
                    connection.Open();

                    string deletePlaneString = "DELETE FROM AERONAVE WHERE ID = @id";
                    MySqlCommand deletePlaneCommand = new MySqlCommand(deletePlaneString, connection);
                    deletePlaneCommand.Parameters.AddWithValue("@id", planeId);

                    try
                    {
                        deletePlaneCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"[ERRO]: {ex.Message}");
            }
        }
    }
}
