using FlyWithUs.Models;
using FlyWithUs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWithUs.Controllers
{
    internal class PlaneController
    {
        public static void updatePlanesListView(ListView planesListView)
        {
            planesListView.Items.Clear();

            PlaneRepository planeRepository = new PlaneRepository();
            CompanyRepository companyRepository = new CompanyRepository();
            string companyName = String.Empty;

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

                    foreach (var c in companyRepository.RetrieveCompanies())
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
    }
}
