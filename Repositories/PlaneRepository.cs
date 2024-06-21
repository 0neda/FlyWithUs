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
using System.Data;

namespace FlyWithUs.Repositories
{
    internal class PlaneRepository
    {
		/* Método para recuperar as aeronaves da database */
		public static DataTable GetPlanesDataFromDatabase()
		{
			DataTable PlanesTable = new DataTable();

			using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
			{
				connection.Open();

				string query = @"
					SELECT
						AERONAVE.ID AS 'ID',
						AERONAVE.TIPO AS 'Tipo',
						AERONAVE.MODELO AS 'Modelo',
						COMPANHIA_AEREA.NOME AS 'Companhia'
					FROM AERONAVE
					JOIN COMPANHIA_AEREA ON AERONAVE.ID_COMPANHIA_AEREA = COMPANHIA_AEREA.ID;";

				MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
				adapter.Fill(PlanesTable);
			}
			return PlanesTable;
		}

		/* Método para a remoção de uma aeronave da database */
		public static void DeletePlane(int planeId)
		{
			using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
			{
				connection.Open();

				try
				{
					string deleteQuery = @"
						DELETE FROM AERONAVE
						WHERE ID = @planeId;";
					MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection);
					deleteCommand.Parameters.AddWithValue("@planeId", planeId);
					deleteCommand.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					MessageBox.Show($"[ERRO]: {ex.Message}");
				}
			}
		}

		/* Método para a inserção de uma nova aeronave na database */
		public static void InsertPlane(int type, string model, int companyId)
		{
			using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
			{
				connection.Open();

				try
				{
					string insertQuery = @"
						INSERT INTO AERONAVE (TIPO, MODELO, ID_COMPANHIA_AEREA)
						VALUES (@planeType, @planeModel, @companyId)";
					MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection);
					insertCommand.Parameters.AddWithValue("@planeType", type);
					insertCommand.Parameters.AddWithValue("@planeModel", model);
					insertCommand.Parameters.AddWithValue("@companyId", companyId);
					insertCommand.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					MessageBox.Show($"[ERRO]: {ex.Message}");
				}
			}
		}

		/* Método para converter o modelo da aeronave em seu respectivo ID de acordo com a database */
		public static int ConvertPlaneModelToId(string planeModel)
		{
			int resultId = -1;
			DataTable CompaniesTable = PlaneRepository.GetPlanesDataFromDatabase();
			foreach (DataRow row in CompaniesTable.Rows)
			{
				if (planeModel == row["MODELO"].ToString())
				{
					resultId = Convert.ToInt32(row["ID"].ToString());
					break;
				}
			}
			return resultId;
		}
	}
}
