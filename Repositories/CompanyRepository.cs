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
using System.Data;

namespace FlyWithUs.Repositories
{
    internal class CompanyRepository
    {

		/* Método para recuperar as companhias da database */
		public static DataTable GetCompaniesFromDatabase()
		{
			DataTable CompaniesTable = new DataTable();

			using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
			{
				connection.Open();

                string query = @"
					SELECT
                        ID AS 'ID',
						NOME AS 'Nome'
					FROM COMPANHIA_AEREA;";

				MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
				adapter.Fill(CompaniesTable);
			}
			return CompaniesTable;
		}

		/* Método para a remoção de uma companhia da database */
		public static void DeleteCompany(int companyId)
		{
			using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
			{
				connection.Open();

				try
				{
					string deleteQuery = @"
						DELETE FROM COMPANHIA_AEREA
						WHERE ID = @companyId;";
					MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection);
					deleteCommand.Parameters.AddWithValue("@companyId", companyId);
					deleteCommand.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					MessageBox.Show($"[ERRO]: {ex.Message}");
				}
			}
		}

		/* Método para a inserção de uma nova companhia na database */
		public static bool InsertCompany(string name)
		{
			bool successState = false;
			using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
			{
				connection.Open();

				try
				{
					string insertQuery = @"
						INSERT INTO COMPANHIA_AEREA (NOME)
						VALUES (@companyName)";
					MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection);
					insertCommand.Parameters.AddWithValue("@companyName", name);
					insertCommand.ExecuteNonQuery();
					successState = true;
				}
				catch (Exception ex)
				{
					MessageBox.Show($"[ERRO]: {ex.Message}");
				}
			}
			return successState;
		}

		/* Método para converter o nome da companhia em seu respectivo ID de acordo com a database */
		public static int ConvertCompanyNameToId(string companyName)
		{
			int resultId = -1;
			DataTable CompaniesTable = CompanyRepository.GetCompaniesFromDatabase();
			foreach (DataRow row in CompaniesTable.Rows)
			{
				if (companyName == row["NOME"].ToString())
				{
					resultId = Convert.ToInt32(row["ID"].ToString());
					break;
				}
			}
			return resultId;
		}
	}
}
