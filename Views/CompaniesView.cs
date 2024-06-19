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
            CompanyController.updateCompaniesListView(companiesListView);
        }

        #region BUTTONS
        private void updateCompaniesList_Click(object sender, EventArgs e)
        {
            CompanyController.updateCompaniesListView(companiesListView);
        }

        private void addCompany_Click(object sender, EventArgs e)
        {
            string name = newCompanyNameInput.Text;
            if (CompanyRepository.InsertCompany(name))
            {
                CompanyController.updateCompaniesListView(companiesListView);
                newCompanyNameInput.Clear();
                newCompanyNameInput.Focus();
            }
            else
                MessageBox.Show("Digite um nome para a compania!");
        }

        private void removeCompany_Click(object sender, EventArgs e)
        {
            if (companiesListView.SelectedItems.Count > 0)
            {
                CompanyRepository.DeleteCompany(Convert.ToInt16(companiesListView.SelectedItems[0].Text));
                CompanyController.updateCompaniesListView(companiesListView);
            }
            else
            {
                MessageBox.Show("Selecione o ID da compania que deseja deletar!");
            }
        }
        #endregion

        private void CompaniesView_Load(object sender, EventArgs e)
        {

        }
    }
}
