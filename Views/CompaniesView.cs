using FlyWithUs.Controllers;

using FlyWithUs.Repositories;
using FlyWithUs.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlyWithUs
{
	public partial class CompaniesView : Form
	{
		public CompaniesView()
		{
			InitializeComponent();
			CompanyController.UpdateCompaniesTable(companiesDataGridView);
			CompanyController.UpdateColumns(companiesDataGridView);
		}

		/* Métodos para as chamadas dos botões */
		#region BUTTONS
		private void updateCompaniesList_Click(object sender, EventArgs e)
		{
			CompanyController.UpdateCompaniesTable(companiesDataGridView);
		}

		/* Lógica para adição de novas companhias,
		 * neste caso não foi utilizado try/catch pois é uma estrutura simples */
		private void addCompany_Click(object sender, EventArgs e)
		{
			string name = newCompanyNameInput.Text;
			if (CompanyRepository.InsertCompany(name))
			{
				CompanyController.UpdateCompaniesTable(companiesDataGridView);
				newCompanyNameInput.Clear();
				newCompanyNameInput.Focus();
			}
			else
				MessageBox.Show("Digite um nome para a companhia!");
		}

		/* Lógica para remoção de companhias já existentes,
		 * utilizamos funções do repositório e do controller 
		 * e deletamos apenas a companhia com o checkbox marcado */
		private void removeCompany_Click(object sender, EventArgs e)
		{
			CompanyRepository.DeleteCompany(selectedCheckbox);
			CompanyController.UpdateCompaniesTable(companiesDataGridView);
		}
		#endregion

		/* Métodos auxiliares para os checkboxes e células do DGV */
		#region Checkboxes e Células DGV
		int selectedCheckbox = -1;
		/* Método responsável por chamar a "ativação única" dos Checkbox */
		private void companiesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			ViewsHelper.SingleCheckbox(e, companiesDataGridView, "companySelection");
		}

		/* Método responsável por "efetuar" a alteração de checkbox/célula selecionada */
		private void companiesDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (companiesDataGridView.CurrentCell is DataGridViewCheckBoxCell && companiesDataGridView.IsCurrentCellDirty)
			{
				companiesDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}

		/* Método responsável por transferir o valor do ID da linha onde o checkbox está marcado */
		private void companiesDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == companiesDataGridView.Columns["companySelection"].Index)
			{
				selectedCheckbox = ViewsHelper.GetSelectedId(companiesDataGridView, "companySelection");
			}
		}
		#endregion
	}
}
