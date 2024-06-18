using FlyWithUs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyWithUs.Models;

namespace FlyWithUs.Utils
{
    internal class ViewAux
    {
        #region MÉTODOS AUXILIARES PARA AS AERONAVES
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
        #endregion

        #region MÉTODOS AUXILIARES PARA AS COMPANIAS
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
        #endregion

        #region MÉTODOS AUXILIARES PARA AS POLTRONAS
        public static void updateSeatsListView(ListView seatsListView)
        {
            seatsListView.Items.Clear();

            PlaneRepository planeRepository = new PlaneRepository();
            SeatRepository seatRepository = new SeatRepository();
            string seatPlaneName = String.Empty;

            if (seatRepository.RetrieveSeats() != null && seatRepository.RetrieveSeats().Count > 0)
            {
                foreach (var s in seatRepository.RetrieveSeats())
                {
                    ListViewItem item = new ListViewItem(s.Id.ToString());

                    switch(s.Class.ToString().ToUpperInvariant())
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
        #endregion
    }
}
