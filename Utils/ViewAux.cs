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
    }
}
