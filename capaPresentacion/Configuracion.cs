using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaPresentacion
{
    public static class Configuracion
    {

        public static string getConnectiongString
        {
            get
            {
                return Properties.Settings.Default.ConnectionString;
            }
        }
    }
}
