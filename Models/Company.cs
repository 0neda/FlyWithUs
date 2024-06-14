using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAviação.Models
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
    }
}
