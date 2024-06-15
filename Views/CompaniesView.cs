using FlyWithUs.Controllers;
using FlyWithUs.Data;
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
            ViewAux.updateCompaniesListView(companiesListView);
        }

        #region BUTTONS
        private void updateCompaniesList_Click(object sender, EventArgs e)
        {
            ViewAux.updateCompaniesListView(companiesListView);
        }

        private void addCompany_Click(object sender, EventArgs e)
        {
            string name = newCompanyNameInput.Text;
            if (CompanyController.Insert(name))
            {
                ViewAux.updateCompaniesListView(companiesListView);
                newCompanyNameInput.Clear();
                newCompanyNameInput.Focus();
            }
        }

        private void removeCompany_Click(object sender, EventArgs e)
        {
            if (companiesListView.SelectedItems.Count > 0)
            {
                CompanyController.Delete(Convert.ToInt16(companiesListView.SelectedItems[0].Text));
                ViewAux.updateCompaniesListView(companiesListView);
            }
            else
            {
                MessageBox.Show("Selecione o ID da compania que deseja deletar!");
            }
        }
        #endregion
    }
}
