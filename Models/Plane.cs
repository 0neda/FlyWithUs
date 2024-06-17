using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

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

        public int Id { get; set; }
        public planeType Type { get; set; }
        public string Model { get; set; }
        public int CompanyId { get; set; }

        public Plane(int id, planeType type, string model, int company)
        {
            Id = id;
            Type = type;
            Model = model;
            CompanyId = company;
        }
    }
}
