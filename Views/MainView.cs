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
using FlyWithUs.Data;
using FlyWithUs.Repositories;
using FlyWithUs.Views;

namespace FlyWithUs
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
