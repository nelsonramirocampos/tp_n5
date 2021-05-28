using System;
using System.Linq;

namespace TrabajoPracticoN5
{
    class GeneradoresRND
    {
        public static Double RndLenguaje()
        {
            return Utilidades.truncar(random());
        }

        private static double random()
        {
            Guid guid = Guid.NewGuid();
            String justNumber = new String(guid.ToString().Where(Char.IsDigit).ToArray());
            int seed = int.Parse(justNumber.Substring(0, 4));

            return Utilidades.truncar(new Random(seed).NextDouble());
        }

        public static Double uniforme(double A, double B, double rnd)
        {
            Double x = A + (rnd * (B - A));

            return Utilidades.truncar(x);
        }

        public static Double exponencial(double lambda, double nro_rnd)
        {
            Double x = (-1 / lambda) * Math.Log(1 - nro_rnd);

            return Utilidades.truncar(x);
        }
    }
}
