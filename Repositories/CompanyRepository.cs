using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SistemaAviação.Models;
using SistemaAviação.Utils;
using SistemaAviação.Data;
using System.Xml.Linq;

namespace SistemaAviação.Repositories
{
    internal class CompanyRepository
    {
        public void RetrieveCompanies()
        {
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

                                Company c = new Company(id, name);
                                Dataset.Companies.Add(c);
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
