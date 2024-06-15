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
        public static bool dbConnected = false;
        public static string connectionString = "server=127.0.0.1;port=3306;uid=progbd;pwd=A12o#ek%asn!@#;database=sistema_aviacao";
        private static MySqlConnection connection;

        public Models.Plane.planeType MapDatabaseValueToEnum(string dbValue)
        {
            switch (dbValue)
            {
                case "HELICÓPTERO":
                    return planeType.Helicopter;
                case "AVIÃO":
                    return planeType.Plane;
                case "JATO":
                    return planeType.Jet;
                default:
                    throw new ArgumentException($"Valor desconhecido: {dbValue}");
            }
        }
    }
}
