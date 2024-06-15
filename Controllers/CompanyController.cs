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
        public static void Insert(string name)
        {
            CompanyRepository.InsertCompany(name);
        }

        public static void Delete(int id)
        {
            CompanyRepository.DeleteCompany(id);
        }

        public static void Initialize()
        {
            CompanyRepository companyRepository = new CompanyRepository();
            companyRepository.RetrieveCompanies();
        }

        public static bool ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                return false;
            return true;
        }
    }
}
