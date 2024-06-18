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
        // Usando um arquivo separado para salvar nossa string de conexão, atualmente é a única coisa salva no arquivo em questão,
        // mas futuramente terão outras adições auxiliares ao BD.
        public static string connectionString = "server=127.0.0.1;port=3306;uid=progbd;pwd=A12o#ek%asn!@#;database=sistema_aviacao";
    }
}
