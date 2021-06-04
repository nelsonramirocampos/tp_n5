using System;

namespace TrabajoPracticoN5
{
    class Vehiculo
    {
        private int nro;
        private String estado; //EA: Esperando Atencion  --- SA: Siendo Atendido
        private int categoria;
        private double costo;
        private double tiempo_fin;
        private int cabina_actual;


        public Vehiculo()
        {
            this.nro = 0;
            this.estado = "EA";
            this.categoria = 0;
            this.costo = -1;
            this.tiempo_fin = -1;
        }
        public Vehiculo(int nro)
        {
            this.nro = nro;
            this.estado = Estado_Vehiculo.EA.ToString();
            this.categoria = 0;
            this.costo = -1;
            this.tiempo_fin = -1;
            this.Cabina_actual = -1;
        }

        public int Nro { get => nro; set => nro = value; }
        public string Estado { get => estado; set => estado = value; }
        public int Categoria { get => categoria; set => categoria = value; }
        public double Costo { get => costo; set => costo = value; }
        public double Tiempo_fin { get => tiempo_fin; set => tiempo_fin = value; }
        public int Cabina_actual { get => cabina_actual; set => cabina_actual = value; }
    }
}
