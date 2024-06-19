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

namespace FlyWithUs.Repositories
{
    internal class CompanyRepository
    {
        // Método para retornar uma lista das companias contidas atualmente no BD, já convertidas em objeto de acordo com nosso model
        public List<Company> RetrieveCompanies()
        {
            List<Company> retCompanies = new List<Company>();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM COMPANIA_AEREA";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt16("Id");
                            string name = reader.GetString("Nome");
                            if (Company.ValidateName(name))
                                retCompanies.Add(new Company(id, name));                            
                        }
                    }
                }
                return retCompanies;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"[ERRO]: {ex.Message}");
            }
            return retCompanies;
        }

        // Método para inserir uma nova compania no BD
        public static bool InsertCompany(string companyName)
        {
            if (Company.ValidateName(companyName))
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
                    {
                        connection.Open();
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
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"[ERRO]: {ex.Message}");
                }
                return true;
            }
            else
                return false;
        }

        // Método para deletar uma compania do BD
        public static void DeleteCompany(int companyId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
                {
                    connection.Open();

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
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"[ERRO]: {ex.Message}");
            }
        }
    }
}
