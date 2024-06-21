using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWithUs.Models
{
    internal class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Company(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Company()
        {

        }

        // Faz a validação do nome da companhia.
        public static bool ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                return false;
            return true;
        }
    }
}
