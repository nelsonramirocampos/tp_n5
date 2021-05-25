using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPracticoN5
{
    class GeneradoresRND
    {
        /**
 * Genera un numero random propio del lenguaje C#
 */
        public static Double RndLenguaje()
        {
            //Random rnd = new Random();

            return Utilidades.truncar(random());
        }

        private static double random()
        {
            Guid guid = Guid.NewGuid();
            String justNumber = new String(guid.ToString().Where(Char.IsDigit).ToArray());
            int seed = int.Parse(justNumber.Substring(0, 4));

            return Utilidades.truncar(new Random(seed).NextDouble());
        }

        /**
         * Genera un listado de numeros random propio del lenguaje C#
         */
        public static List<Double> RndLenguaje(int cantidad)
        {
            Random rnd = new Random();

            List<Double> numeros = new List<double>();

            for (int i = 0; i < cantidad; i++)
            {
                numeros.Add(Utilidades.truncar(rnd.NextDouble()));
            }

            return numeros;
        }

        public static Double uniforme(double A, double B, double rnd)
        {
            Double x = A + (rnd * (B - A));

            return Utilidades.truncar(x);
        }

        public static List<double> normal(double media, double desviacion, double rnd_1, double rnd_2)
        {
            List<double> nros = new List<double>();
            nros.Add(box_muller(rnd_1, rnd_2, media, desviacion, false));
            nros.Add(box_muller(rnd_1, rnd_2, media, desviacion, true));

            return nros;
        }

        private static double box_muller(double RND1, double RND2, double media, double desviacion, bool esN2)
        {
            double N;
            if (esN2 == false)
            {
                N = Utilidades.truncar(
                        (Math.Sqrt(-2 * Math.Log(RND1)) * Math.Cos(2 * Math.PI * RND2)) * desviacion + media
                        );
            }
            else //esN2 == true
            {
                N = Utilidades.truncar(
                    (Math.Sqrt(-2 * Math.Log(RND1)) * Math.Sin(2 * Math.PI * RND2)) * desviacion + media
                    );
            }

            return Utilidades.truncar(N);
        }
        public static Double exponencial(double lambda, double nro_rnd)
        {
            Double x = (-1 / lambda) * Math.Log(1 - nro_rnd);

            return Utilidades.truncar(x);
        }

    }
}
