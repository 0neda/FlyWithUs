using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using FlyWithUs.Controllers;
using FlyWithUs.Models;
using FlyWithUs.Utils;
using MySql.Data.MySqlClient;

namespace FlyWithUs.Repositories
{
	internal class SeatRepository
	{
		/* Método para recuperar as poltronas da database */
		public static DataTable GetSeatsDataFromDatabase(bool filterByPlane, int filterPlaneId = 0)
		{
			DataTable SeatsTable = new DataTable();

			using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
			{
				connection.Open();
				string query;

				if (!filterByPlane)
                {
                    query = @"
                        SELECT
                            POLTRONA.ID AS 'ID',
                            POLTRONA.CLASSE AS 'Classe',
                            POLTRONA.ESTA_VAGA AS 'Está vaga?',
                            POLTRONA.LOCALIZACAO AS 'Localização',
                            AERONAVE.MODELO AS 'Aeronave',
                            COMPANHIA_AEREA.NOME AS 'Companhia'
                        FROM POLTRONA
                        JOIN AERONAVE ON POLTRONA.ID_AERONAVE = AERONAVE.ID
                        JOIN COMPANHIA_AEREA ON AERONAVE.ID_COMPANHIA_AEREA = COMPANHIA_AEREA.ID;";
                }
                else
                {
                    query = @"
                        SELECT
                            POLTRONA.ID AS 'ID',
                            POLTRONA.CLASSE AS 'Classe',
                            POLTRONA.ESTA_VAGA AS 'Está vaga?',
                            POLTRONA.LOCALIZACAO AS 'Localização',
                            AERONAVE.MODELO AS 'Aeronave',
                            COMPANHIA_AEREA.NOME AS 'Companhia'
                        FROM POLTRONA
                        JOIN AERONAVE ON POLTRONA.ID_AERONAVE = AERONAVE.ID
                        JOIN COMPANHIA_AEREA ON AERONAVE.ID_COMPANHIA_AEREA = COMPANHIA_AEREA.ID
                        WHERE AERONAVE.ID = @planeId;";
                }

				MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
				if (filterByPlane)
				{
					adapter.SelectCommand.Parameters.AddWithValue("@planeId", filterPlaneId);
				}
				adapter.Fill(SeatsTable);
			}
			return SeatsTable;
		}

		/* Método para conferir o estado de "vaga" da poltrona de acordo com a database */
		public static bool CheckSeatStatus(int seatId)
		{
			bool isVacant = false;
			using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
			{
				try
				{
					connection.Open();
					string isVacantQuery = "SELECT ESTA_VAGA FROM POLTRONA WHERE ID = @seatId;";
					MySqlCommand isVacantCommand = new MySqlCommand(isVacantQuery, connection);
					isVacantCommand.Parameters.AddWithValue("@seatId", seatId);
					object commandResult = isVacantCommand.ExecuteScalar();

					if (commandResult is not null && commandResult != DBNull.Value)
					{
						isVacant = Convert.ToBoolean(commandResult);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"[ERRO]: {ex.Message}");
				}
			}
			return isVacant;
		}

		/* Método "alternar" o estado de uma poltrona. */
		public static void BookSeat(int seatId)
		{
			using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
			{
				connection.Open();

				try
				{
					bool newStatus = !CheckSeatStatus(seatId);
					string updateQuery = @"
						UPDATE POLTRONA
						SET ESTA_VAGA = @newStatus
						WHERE ID = @seatId;";
					MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
					updateCommand.Parameters.AddWithValue("@seatId", seatId);
					updateCommand.Parameters.AddWithValue("@newStatus", newStatus);
					updateCommand.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					MessageBox.Show($"[ERRO]: {ex.Message}");
				}
			}
		}

		/* Método para a remoção de uma poltrona da database */
		public static void DeleteSeat(int seatId)
		{
			using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
			{
				connection.Open();

				try
				{
					string deleteQuery = @"
						DELETE FROM POLTRONA
						WHERE ID = @seatId;";
					MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection);
					deleteCommand.Parameters.AddWithValue("@seatId", seatId);
					deleteCommand.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					MessageBox.Show($"[ERRO]: {ex.Message}");
				}
			}
		}
	}
}
