using SistemaAviação.Models;
using SistemaAviação.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAviação.Controllers
{
    internal class PlaneController
    {
        public static void Initialize()
        {
            PlaneRepository planeRepository = new PlaneRepository();
            planeRepository.RetrievePlanes();
        }

        public static void Insert(string model, int type, int company)
        {
            PlaneRepository.InsertPlane(type, model, company);
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
