using FlyWithUs.Data;
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
        public static void Initialize()
        {
            PlaneRepository planeRepository = new PlaneRepository();
            planeRepository.RetrievePlanes();
        }

        public static bool Insert(int type, string model, object companyComboBoxSelectedItem)
        {
            int companyId = 0;
            if (companyComboBoxSelectedItem != null)
            {
                foreach (var c in Dataset.Companies)
                {
                    if (c.Name == companyComboBoxSelectedItem.ToString())
                    {
                        companyId = c.Id;
                        if (companyId != 0)
                        {
                            PlaneRepository.InsertPlane(type, model, companyId);
                            return true;
                        }
                    }
                }
                return false;
            }
            else
            {
                MessageBox.Show("Selecione uma compania.");
                return false;
            }
        }

        public static void Delete(int id)
        {
            PlaneRepository.DeletePlane(id);
        }

        public static bool ValidateModel(string model)
        {
            if (string.IsNullOrEmpty(model) || string.IsNullOrWhiteSpace(model))
                return false;
            return true;
        }
    }
}
