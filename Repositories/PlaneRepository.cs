using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using FlyWithUs.Models;
using FlyWithUs.Utils;
using FlyWithUs.Data;
using System.Xml.Linq;
using static FlyWithUs.Models.Plane;

namespace FlyWithUs.Repositories
{
    internal class PlaneRepository
    {
        public void RetrievePlanes()
        {
            if (!Database.dbConnected)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
                    {
                        connection.Open();
                        Database.dbConnected = true;
                        string query = "SELECT * FROM AERONAVE";
                        MySqlCommand command = new MySqlCommand(query, connection);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt16("ID");
                                string model = reader.GetString("MODELO");

                                Plane.planeType type = new Plane.planeType();
                                switch (reader.GetString("TIPO"))
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

                                Company company = new();
                                int companyId = reader.GetInt16("FK_ID_COMPANIA_AEREA");
                                foreach (var c in Dataset.Companies)
                                {
                                    if (c.Id == companyId)
                                    {
                                        company = c;
                                    }
                                }

                                Plane p = new Plane(id, type, model, company);
                                Dataset.Planes.Add(p);
                            }
                        }
                    }
                    Database.dbConnected = false;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"[ERRO]: {ex.Message}");
                    Database.dbConnected = false;
                }
            }
        }

        public static void InsertPlane(int planeType, string planeModel, int planeCompany)
        {
            if (!Database.dbConnected)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
                    {
                        connection.Open();
                        Database.dbConnected = true;
                        string query = "INSERT INTO AERONAVE (TIPO, MODELO, FK_ID_COMPANIA_AEREA) VALUES (@planeType, @planeModel, @planeCompany)";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@planeType", planeType);
                        command.Parameters.AddWithValue("@planeModel", planeModel);
                        command.Parameters.AddWithValue("@planeCompany", planeCompany);

                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    Database.dbConnected = false;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"[ERRO]: {ex.Message}");
                    Database.dbConnected = false;
                }
            }
        }

        public static void DeletePlane(int planeId)
        {
            if (!Database.dbConnected)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
                    {
                        connection.Open();
                        Database.dbConnected = true;

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
                    Database.dbConnected = false;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"[ERRO]: {ex.Message}");
                    Database.dbConnected = false;
                }
            }
        }
    }
}
