using FlyWithUs.Controllers;
using FlyWithUs.Data;
using FlyWithUs.Repositories;
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
            updateCompaniesListView();
        }

        private void updateCompaniesList_Click(object sender, EventArgs e)
        {
            updateCompaniesListView();
        }

        public void updateCompaniesListView()
        {
            companiesListView.Items.Clear();

            CompanyRepository companyRepository = new CompanyRepository();
            Dataset.Companies.Clear();
            companyRepository.RetrieveCompanies();

            if (Dataset.Companies.Count > 0)
            {
                foreach (var c in Dataset.Companies)
                {
                    companiesListView.Items.Add(c.Id.ToString()).SubItems.Add(c.Name);
                }
            }
            else
            {
                MessageBox.Show("Ainda não adicionamos nenhuma compania.");
            }
        }

        private void addCompany_Click(object sender, EventArgs e)
        {
            string name = newCompanyNameInput.Text;
            if (CompanyController.ValidateName(name))
            {
                CompanyController.Insert(name);
                updateCompaniesListView();
                newCompanyNameInput.Clear();
                newCompanyNameInput.Focus();
            } else
            {
                MessageBox.Show("Nome inválido!");
            }
        }

        private void removeCompany_Click(object sender, EventArgs e)
        {
            if (companiesListView.SelectedItems.Count > 0)
            {
                CompanyController.Delete(Convert.ToInt16(companiesListView.SelectedItems[0].Text));
                updateCompaniesListView();
            } else
            {
                MessageBox.Show("Selecione o ID da compania que deseja deletar!");
            }
        }
    }
}
