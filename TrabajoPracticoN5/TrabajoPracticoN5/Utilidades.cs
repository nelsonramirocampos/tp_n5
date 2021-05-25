using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPracticoN5
{
    class Utilidades
    {
        public static double truncar(double nro)
        {
            int decimales = int.Parse(Math.Pow(10, 3).ToString());
            return Math.Truncate(nro * decimales) / decimales;
        }
    }
}
