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

namespace FlyWithUs.Views
{
	public partial class SeatsView : Form
	{
		bool isFiltered = false;

		public SeatsView()
		{
			InitializeComponent();
			SeatController.UpdateSeatsTable(seatsDataGridView, isFiltered);
			SeatController.FillPlanesFilter(planeFilterComboBox);
		}

		/* Métodos para as chamadas dos botões */
		#region Botões
		/* Botão para atualizar a listagem das poltronas, desnecessário, mas implementado até o momento. */
		private void updateSeatsButton_Click(object sender, EventArgs e)
		{
			int planeId = 0;
			if (planeFilterComboBox.SelectedItem is not null)
				planeId = PlaneRepository.ConvertPlaneModelToId(planeFilterComboBox.SelectedItem.ToString());
			SeatController.UpdateSeatsTable(seatsDataGridView, isFiltered, planeId);
		}

		/* Botão para efetuar a remoção da poltrona selecionada. */
		private void deleteSeatButton_Click(object sender, EventArgs e)
		{
			if (selectedCheckbox != -1)
			{
				SeatRepository.DeleteSeat(selectedCheckbox);
				SeatController.UpdateSeatsTable(seatsDataGridView, isFiltered);
			}
			else
			{
				MessageBox.Show("Nenhuma poltrona selecionada para deletar.");
			}
		}
		#endregion

		/* Função para atualizar o estado do filtro de acordo com a escolha do combobox */
		private void planeFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (planeFilterComboBox.SelectedIndex == 0)
			{
				isFiltered = false;
				SeatController.UpdateSeatsTable(seatsDataGridView, isFiltered);
			}
			else
			{
				isFiltered = true;
				int planeId = PlaneRepository.ConvertPlaneModelToId(planeFilterComboBox.SelectedItem.ToString());
				SeatController.UpdateSeatsTable(seatsDataGridView, isFiltered, planeId);
			}
		}

		/* Método auxiliar para detectarmos o ID da poltrona quando marcamos/desmarcamos
		 * "Está vaga" no DGV e atualizarmos o valor de acordo com o atual (SeatRepository.BookSeat) */
		private void AuxBook(DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex == seatsDataGridView.Columns["Está vaga?"].Index)
			{
				int seatId = Convert.ToInt32(seatsDataGridView.Rows[e.RowIndex].Cells["ID"].Value);
				SeatRepository.BookSeat(seatId);
			}
		}

		/* Métodos auxiliares para os checkboxes e células do DGV */
		#region Checkboxes e Células DGV
		int selectedCheckbox = -1;
		/* Método responsável por chamar a "ativação única" dos Checkbox e fazer a "reserva" da poltrona se for o caso */
		private void seatsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			ViewsHelper.SingleCheckbox(e, seatsDataGridView, "seatSelection");
			AuxBook(e);
		}

		/* Método responsável por "efetuar" a alteração de checkbox/célula selecionada */
		private void seatsDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (seatsDataGridView.CurrentCell is DataGridViewCheckBoxCell && seatsDataGridView.IsCurrentCellDirty)
			{
				seatsDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}

		/* Método responsável por transferir o valor do ID da linha onde o checkbox está marcado */
		private void seatsDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == seatsDataGridView.Columns["seatSelection"].Index)
			{
				selectedCheckbox = ViewsHelper.GetSelectedId(seatsDataGridView, "seatSelection");
			}
		}
		#endregion
	}
}
