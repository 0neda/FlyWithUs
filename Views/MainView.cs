using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaAviação.Controllers;
using SistemaAviação.Data;
using SistemaAviação.Repositories;
using SistemaAviação.Views;

namespace SistemaAviação
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
            CompanyController.Initialize();
            PlaneController.Initialize();
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
    }
}
