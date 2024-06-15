using FlyWithUs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWithUs.Data
{
    internal class Dataset
    {
        public static List<Company> Companies { get; set; } = new List<Company>();
        public static List<Plane> Planes { get; set; } = new List<Plane>();
    }
}
