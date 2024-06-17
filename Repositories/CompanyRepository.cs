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

namespace FlyWithUs.Repositories
{
    internal class CompanyRepository
    {
        public List<Company> RetrieveCompanies()
        {
            List<Company> retCompanies = new List<Company>();
            if (!Database.dbConnected)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
                    {
                        connection.Open();
                        Database.dbConnected = true;
                        string query = "SELECT * FROM COMPANIA_AEREA";
                        MySqlCommand command = new MySqlCommand(query, connection);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt16("Id");
                                string name = reader.GetString("Nome");

                                retCompanies.Add(new Company(id, name));
                            }
                        }
                    }
                    Database.dbConnected = false;
                    return retCompanies;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"[ERRO]: {ex.Message}");
                    Database.dbConnected = false;
                }
            }
            return retCompanies;
        }

        public static void InsertCompany(string companyName)
        {
            if (!Database.dbConnected)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
                    {
                        connection.Open();
                        Database.dbConnected = true;
                        string query = "INSERT INTO COMPANIA_AEREA (NOME) VALUES (@companyName)";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@companyName", companyName);

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

        public static void DeleteCompany(int companyId)
        {
            if (!Database.dbConnected)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
                    {
                        connection.Open();
                        Database.dbConnected = true;

                        string deleteCompanyString = "DELETE FROM COMPANIA_AEREA WHERE ID = @id";
                        MySqlCommand deleteCompanyCommand = new MySqlCommand(deleteCompanyString, connection);
                        deleteCompanyCommand.Parameters.AddWithValue("@id", companyId);

                        try
                        {
                            deleteCompanyCommand.ExecuteNonQuery();
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
