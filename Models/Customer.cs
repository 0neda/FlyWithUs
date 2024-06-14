using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAviação.Models
{
    internal class Customer
    {
        public enum CustomerType
        {
            Normal = 1,
            Corporate = 2
        }

        public int Id { get; set; }
        public CustomerType Type { get; set; }
        public string Phone { get; set; }
        public bool IsPreferential { get; set; }
    }
}
