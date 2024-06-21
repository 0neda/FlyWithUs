using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlyWithUs.Controllers;

using FlyWithUs.Repositories;
using FlyWithUs.Views;

namespace FlyWithUs
{
	public partial class MainView : Form
	{
		public MainView()
		{
			InitializeComponent();
		}

		private void companiesButton_Click(object sender, EventArgs e)
		{
			var companiesForm = new CompaniesView();
			companiesForm.Show();
		}

		private void planesButton_Click(Object sender, EventArgs e)
		{
			var planesForm = new PlanesView();
			planesForm.Show();
		}

		private void SeatsViewButton_Click(object sender, EventArgs e)
		{
			var seatsForm = new SeatsView();
			seatsForm.Show();
		}

		private void MainView_Load(object sender, EventArgs e)
		{

		}
	}
}
