using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPracticoN5
{
    class Vehiculo
    {
        private long nro;
        private String estado; //EA: Esperando Atencion  --- SA: Siendo Atendido
        private int categoria;
        private double costo;
        private double tiempo_fin;

        public Vehiculo()
        {
            this.nro = 0;
            this.estado = "EA";
            this.categoria = 0;
            this.costo = -1;
            this.tiempo_fin = -1;
        }

        public long Nro { get => nro; set => nro = value; }
        public string Estado { get => estado; set => estado = value; }
        public int Categoria { get => categoria; set => categoria = value; }
        public double Costo { get => costo; set => costo = value; }
        public double Tiempo_fin { get => tiempo_fin; set => tiempo_fin = value; }
    }
}
