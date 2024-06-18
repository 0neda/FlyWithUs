using FlyWithUs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWithUs.Controllers
{
    internal class CompanyController
    {
        // Validar nome e executar método de inserção da compania do repositório
        public static bool Insert(string name)
        {
            if (ValidateName(name))
            {
                CompanyRepository.InsertCompany(name);
                return true;
            }
            else
            {
                MessageBox.Show("Nome inválido!");
                return false;
            }
        }

        // Executar método de remoção do repositório
        public static void Delete(int id)
        {
            CompanyRepository.DeleteCompany(id);
        }

        // Validação do nome da compania, checamos se não é uma string nula ou vazia.
        public static bool ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                return false;
            return true;
        }
    }
}
