using FlyWithUs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlyWithUs.Utils
{
	internal class ViewsHelper
	{

		/* Usamos o método a seguir para detectar qual é o ID relativo ao checkbox marcado */
		public static int GetSelectedId(DataGridView dgv, string checkboxHeaderName)
		{
			foreach (DataGridViewRow row in dgv.Rows)
			{
				bool isSelected = Convert.ToBoolean(row.Cells[checkboxHeaderName].Value);
				if (isSelected)
				{
					return Convert.ToInt32(row.Cells["ID"].Value);
				}
			}
			return -1;
		}

		/* Aqui definimos que somente um checkbox pode ser marcado por vez. */
		public static void SingleCheckbox(DataGridViewCellEventArgs dgvCellEventArgs, DataGridView dgv, string checkboxHeaderName)
		{
			foreach (DataGridViewRow row in dgv.Rows)
			{
				if (row.Index != dgvCellEventArgs.RowIndex)
				{
					DataGridViewCheckBoxCell checkBox = row.Cells[checkboxHeaderName] as DataGridViewCheckBoxCell;
					if (checkBox != null)
					{
						checkBox.Value = false;
					}
				}
			}
		}
	}
}