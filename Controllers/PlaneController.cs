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

        #region CRUD
        public static bool Insert(int type, string model, ComboBox companyComboBox)
        {
            int companyId = ValidateCompany(companyComboBox.SelectedItem.ToString());
            if (companyId != 0 && companyId != -1)
                PlaneRepository.InsertPlane(type, model, companyId);
            else
            {
                MessageBox.Show("Erro na seleção de compania!");
                return false;
            }
            return true;
        }

        public static void Delete(int id)
        {
            PlaneRepository.DeletePlane(id);
        }
        #endregion

        #region VALIDATION METHODS
        public static bool ValidateModel(string model)
        {
            if (string.IsNullOrEmpty(model) || string.IsNullOrWhiteSpace(model))
                return false;
            return true;
        }

        public static int ValidateCompany(object comboBoxSelectedItem)
        {
            CompanyRepository companyRepository = new CompanyRepository();
            foreach (var c in companyRepository.RetrieveCompanies())
            {
                if (c.Name == comboBoxSelectedItem.ToString())
                    return c.Id;
            }
            return -1;
        }
        #endregion
    }
}
