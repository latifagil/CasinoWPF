using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoWPF.DBModel
{
    internal class ConnectionClass
    {
        public static CasinoDBEntities casino = new CasinoDBEntities();
        public static Users users;
        public static Login login;

    }
}
