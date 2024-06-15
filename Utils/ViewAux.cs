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
            Dataset.Planes.Clear();
            planeRepository.RetrievePlanes();

            if (Dataset.Planes.Count > 0)
            {
                foreach (var p in Dataset.Planes)
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
                    item.SubItems.Add(p.Company.Name.ToString());
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
        #endregion
    }
}
