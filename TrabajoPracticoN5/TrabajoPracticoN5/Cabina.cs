using System;

namespace TrabajoPracticoN5
{
    class Cabina
    {
        private int nro_cabina;
        private int capacidad;
        private String estado;

        private double tiempo_inicio_oc;
        private double tiempo_fin_oc;
        private double tiempo_acu_oc;

        public Cabina(int nro_cabina)
        {
            this.Nro_cabina = nro_cabina;
            this.Capacidad = 1;
            this.Estado = Estado_Cabina.Oc.ToString();

            this.tiempo_inicio_oc = 0;
            this.tiempo_fin_oc = 0;
            this.tiempo_acu_oc = 0;
        }

        public int Nro_cabina { get => nro_cabina; set => nro_cabina = value; }
        public int Capacidad { get => capacidad; set => capacidad = value; }
        public string Estado { get => estado; set => estado = value; }
        public double Tiempo_inicio_oc { get => tiempo_inicio_oc; set => tiempo_inicio_oc = value; }
        public double Tiempo_fin_oc { get => tiempo_fin_oc; set => tiempo_fin_oc = value; }
        public double Tiempo_acu_oc { get => tiempo_acu_oc; set => tiempo_acu_oc = value; }
    }
}
