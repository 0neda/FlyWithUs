using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FlyWithUs.Repositories;

namespace FlyWithUs.Models
{
    internal class Plane
    {
        public enum planeType
        {
            [Description("Helicóptero")]
            Helicopter = 1,
            [Description("Avião")]
            Plane = 2,
            [Description("Jato")]
            Jet = 3
        }

        public int? Id { get; set; }
        public planeType? Type { get; set; }
        public string? Model { get; set; }
        public int? CompanyId { get; set; }

        public Plane(int id, planeType type, string model, int company)
        {
            Id = id;
            Type = type;
            Model = model;
            CompanyId = company;
        }

        public Plane ()
        {

        }

        public static bool ValidateModel(string model)
        {
            if (string.IsNullOrEmpty(model) || string.IsNullOrWhiteSpace(model))
                return false;
            return true;
        }

        public static int ValidateCompany(object comboBoxSelectedItem)
        {
            CompanyRepository companyRepository = new CompanyRepository();
            if (comboBoxSelectedItem != null)
            {
                foreach (var c in companyRepository.RetrieveCompanies())
                {
                    if (c.Name == comboBoxSelectedItem.ToString())
                        return c.Id;
                }
            }
            else
            {
                MessageBox.Show("Não há nenhuma compania selecionada.");
                return -1;
            }
            return -1;
        }

        public static bool ValidateType(ComboBox planeTypeBox)
        {
            if (planeTypeBox.SelectedIndex != -1)
                return true;
            return false;
        }
    }
}
