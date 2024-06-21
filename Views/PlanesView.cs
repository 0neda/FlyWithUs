using FlyWithUs.Controllers;

using FlyWithUs.Models;
using FlyWithUs.Repositories;
using FlyWithUs.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlyWithUs.Views
{
    public partial class PlanesView : Form
    {
        public PlanesView()
        {
            InitializeComponent();
            PlaneController.UpdatePlanesTable(planesDataGridView);
			PlaneController.FillPlaneCompanies(planeCompanyBox);
			PlaneController.FillPlaneTypes(planeTypeBox);
		}

		/* Métodos para as chamadas dos botões */
		#region Botões
		/* Lógica para remoção de aeronaves já existentes,
		 * utilizamos funções do repositório e do controller
		 * e deletamos apenas a aeronave com o checkbox marcado*/
		private void removePlane_Click(object sender, EventArgs e)
        {
			PlaneRepository.DeletePlane(selectedCheckbox);
			PlaneController.UpdatePlanesTable(planesDataGridView);

		}

		/* Lógica para adição de novas aeronaves, utilizamos try/catch
		 * para lidar com possíveis erros e lançar
		 * messageboxes personalizadas de acordo com cada erro. */
        private void addPlane_Click(object sender, EventArgs e)
        {
			try
			{
				if (planeTypeBox.SelectedIndex == -1)
				{
					throw new ArgumentException("Selecione o tipo da aeronave!");
				}
				if (string.IsNullOrEmpty(newPlaneModelInput.Text) || string.IsNullOrWhiteSpace(newPlaneModelInput.Text))
				{
					throw new ArgumentException("Digite o nome do modelo da aeronave!");
				}
				if (CompanyRepository.ConvertCompanyNameToId(planeCompanyBox.SelectedItem.ToString()) == -1)
				{
					throw new ArgumentException("Selecione a companhia da aeronave!");
				}

				PlaneRepository.InsertPlane(planeTypeBox.SelectedIndex + 1, newPlaneModelInput.Text, CompanyRepository.ConvertCompanyNameToId(planeCompanyBox.SelectedItem.ToString()));
				PlaneController.UpdatePlanesTable(planesDataGridView);

				MessageBox.Show("Aeronave adicionada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (ArgumentException ex)
			{
				MessageBox.Show(ex.Message, "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"{ex.Message}", "Erro Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		/* Métodos auxiliares para os checkboxes e células do DGV */
		#region Checkboxes e Células DGV
		int selectedCheckbox = -1;
		/* Método responsável por chamar a "ativação única" dos Checkbox */
		private void planesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			ViewsHelper.SingleCheckbox(e, planesDataGridView, "planeSelection");
		}

		/* Método responsável por "efetuar" a alteração de checkbox/célula selecionada */
		private void planesDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (planesDataGridView.CurrentCell is DataGridViewCheckBoxCell && planesDataGridView.IsCurrentCellDirty)
			{
				planesDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}

		/* Método responsável por transferir o valor do ID da linha onde o checkbox está marcado */
		private void planesDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == planesDataGridView.Columns["planeSelection"].Index)
			{
				selectedCheckbox = ViewsHelper.GetSelectedId(planesDataGridView, "planeSelection");
			}
		}
		#endregion
	}
}
