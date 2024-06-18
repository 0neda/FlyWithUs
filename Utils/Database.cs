using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using FlyWithUs.Models;
using static FlyWithUs.Models.Plane;

namespace FlyWithUs.Utils
{
    internal class Database
    {
        public static string connectionString = "server=127.0.0.1;port=3306;uid=root;pwd=root;database=sistema_aviacao";
    }
}
