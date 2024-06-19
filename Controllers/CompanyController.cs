using FlyWithUs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWithUs.Controllers
{
    internal class CompanyController
    {
        public static void updateCompaniesListView(ListView companiesListView)
        {
            companiesListView.Items.Clear();

            CompanyRepository companyRepository = new CompanyRepository();

            if (companyRepository.RetrieveCompanies() != null && companyRepository.RetrieveCompanies().Count > 0)
            {
                foreach (var c in companyRepository.RetrieveCompanies())
                {
                    companiesListView.Items.Add(c.Id.ToString()).SubItems.Add(c.Name);
                }
            }
            else
            {
                MessageBox.Show("Ainda não adicionamos nenhuma compania.");
            }
        }
    }
}
