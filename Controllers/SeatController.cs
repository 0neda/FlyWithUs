using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyWithUs.Models;
using FlyWithUs.Repositories;

namespace FlyWithUs.Controllers
{
    internal class SeatController
    {
        public static void updateSeatsListView(ListView seatsListView)
        {
            seatsListView.Items.Clear();

            PlaneRepository planeRepository = new PlaneRepository();
            string seatPlaneName = String.Empty;

            if (SeatRepository.RetrieveSeats() != null && SeatRepository.RetrieveSeats().Count > 0)
            {
                foreach (var s in SeatRepository.RetrieveSeats())
                {
                    ListViewItem item = new ListViewItem(s.Id.ToString());

                    switch (s.Class.ToString().ToUpperInvariant())
                    {
                        case "ECO":
                            item.SubItems.Add("Econômica");
                            break;
                        case "FIRST":
                            item.SubItems.Add("Primeira Classe");
                            break;
                        case "DELUXE":
                            item.SubItems.Add("Luxo");
                            break;
                    }

                    item.SubItems.Add(s.IsVacant ? "Sim" : "Não");

                    switch (s.Localization.ToString().ToUpperInvariant())
                    {
                        case "WINDOW":
                            item.SubItems.Add("Janela");
                            break;
                        case "CORRIDOR":
                            item.SubItems.Add("Corredor");
                            break;
                        case "RIGHT":
                            item.SubItems.Add("Direita");
                            break;
                        case "LEFT":
                            item.SubItems.Add("Esquerda");
                            break;
                        case "CENTER":
                            item.SubItems.Add("Centro");
                            break;
                    }

                    foreach (var p in planeRepository.RetrievePlanes())
                    {
                        if (p.Id == s.Plane.Id)
                        {
                            seatPlaneName = p.Model;
                        }
                    }

                    item.SubItems.Add(seatPlaneName);
                    seatsListView.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Ainda não adicionamos nenhuma aeronave.");
            }
        }
    }
}
