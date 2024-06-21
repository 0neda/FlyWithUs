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
    internal class CompanyController
    {
		/* Método para atualizar o DGV com a tabela importada do banco de dados */
		public static void UpdateCompaniesTable(DataGridView dgv)
		{
			DataTable CompaniesTable = CompanyRepository.GetCompaniesFromDatabase();
			dgv.DataSource = CompaniesTable;
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
					case "Nome":
						column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
						column.ReadOnly = true;
						break;
				}
			}
		}
	}
}
