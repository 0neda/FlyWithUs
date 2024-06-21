using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyWithUs.Models;
using FlyWithUs.Repositories;
using FlyWithUs.Services;
using MySql.Data.MySqlClient;
using FlyWithUs.Utils;
using static FlyWithUs.Services.SeatServices;
using System.Windows.Forms;
using System.ComponentModel;

namespace FlyWithUs.Controllers
{
	internal class SeatController
	{
		/* Método para atualizar o DGV com a tabela importada do banco de dados */
		public static void UpdateSeatsTable(DataGridView dgv, bool filterByPlane, int filterPlaneId = 0)
		{
			DataTable SeatsTable = SeatRepository.GetSeatsDataFromDatabase(filterByPlane, filterPlaneId);
			dgv.DataSource = SeatsTable;
			UpdateColumns(dgv);
			dgv.Sort(dgv.Columns["ID"], ListSortDirection.Ascending);
		}


		/* Método utilizado para atualizar o modo de AutoSize das colunas de acordo com o Header e conteúdo (assumido pelo header) */
		public static void UpdateColumns(DataGridView dgv)
		{
			foreach (DataGridViewColumn column in dgv.Columns)
			{
				switch (column.Name)
				{
					case "ID":
						column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
						column.ReadOnly = true;
						break;
					case "Classe":
						column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
						column.ReadOnly = true;
						break;
					case "Está vaga?":
						column.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
						break;
					case "Localização":
						column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
						column.ReadOnly = true;
						break;
					case "Aeronave":
						column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
						column.ReadOnly = true;
						break;
					case "Companhia":
						column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
						column.ReadOnly = true;
						break;
				}
			}
		}


		/* Método utilizado para preencher o ComboBox para filtragem por aeronave */
		public static void FillPlanesFilter(ComboBox planesFilterComboBox)
		{
			DataTable PlanesTable = PlaneRepository.GetPlanesDataFromDatabase();
			planesFilterComboBox.Items.Clear();
			planesFilterComboBox.Items.Add("* - TODAS AS AERONAVES");

			foreach (DataRow row in PlanesTable.Rows)
			{
				planesFilterComboBox.Items.Add(row["MODELO"].ToString());
			}

			if (planesFilterComboBox.Items.Count > 0)
				planesFilterComboBox.SelectedIndex = 0;
		}
	}
}
