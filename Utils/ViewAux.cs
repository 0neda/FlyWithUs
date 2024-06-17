using FlyWithUs.Repositories;
using FlyWithUs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWithUs.Utils
{
    internal class ViewAux
    {
        #region PLANES VIEW AUXILIARIES
        public static void updatePlanesListView(ListView planesListView)
        {
            planesListView.Items.Clear();

            PlaneRepository planeRepository = new PlaneRepository();
            CompanyRepository companyRepository = new CompanyRepository();
            string companyName = String.Empty;
            planeRepository.RetrievePlanes();

            if (planeRepository.RetrievePlanes() != null && planeRepository.RetrievePlanes().Count > 0)
            {
                foreach (var p in planeRepository.RetrievePlanes())
                {
                    ListViewItem item = new ListViewItem(p.Id.ToString());
                    item.SubItems.Add(p.Model);
                    switch (p.Type.ToString())
                    {
                        case "Helicopter":
                            item.SubItems.Add("Helicóptero");
                            break;
                        case "Plane":
                            item.SubItems.Add("Avião");
                            break;
                        case "Jet":
                            item.SubItems.Add("Jato");
                            break;
                    }

                    foreach ( var c in companyRepository.RetrieveCompanies())
                    {
                        if (c.Id == p.CompanyId)
                        {
                            companyName = c.Name;
                        }
                    }

                    item.SubItems.Add(companyName);
                    planesListView.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Ainda não adicionamos nenhuma aeronave.");
            }
        }
        #endregion

        #region COMPANIES VIEW AUXILIARIES
        public static void updateCompaniesListView(ListView companiesListView)
        {
            companiesListView.Items.Clear();

            CompanyRepository companyRepository = new CompanyRepository();
            companyRepository.RetrieveCompanies();

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
        #endregion
    }
}
