using FlyWithUs.Models;
using FlyWithUs.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWithUs.Controllers
{
    internal class PlaneController
    {
		/* Método para atualizar o DGV com a tabela importada do banco de dados */
		public static void UpdatePlanesTable(DataGridView dgv)
        {
			DataTable planesData = PlaneRepository.GetPlanesDataFromDatabase();
			dgv.DataSource = planesData;
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
					case "Tipo":
						column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
						column.ReadOnly = true;
						break;
					case "Modelo":
						column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
						column.FillWeight = 3;
						column.ReadOnly = true;
						break;
					case "Companhia":
						column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
						column.FillWeight = 1;
						column.ReadOnly = true;
						break;
				}
			}
		}

		// Função auxiliar para preencher o combobox de companhias
		public static void FillPlaneCompanies(ComboBox companiesBox)
		{
			DataTable CompaniesTable = CompanyRepository.GetCompaniesFromDatabase();
			companiesBox.Items.Clear();

			foreach (DataRow row in CompaniesTable.Rows)
			{
				companiesBox.Items.Add(row["Nome"].ToString());
			}

			if (companiesBox.Items.Count > 0)
				companiesBox.SelectedIndex = 0;
		}

		// Necessário rever lógica de acordo com database para futuras adições de tipos
		public static void FillPlaneTypes(ComboBox typesBox)
		{
			typesBox.Items.Add("1 - Helicóptero");
			typesBox.Items.Add("2 - Avião");
			typesBox.Items.Add("3 - Jato");
			typesBox.SelectedIndex = 0;
		}
	}
}
