using System;

namespace TrabajoPracticoN5
{
    class Cabina
    {
        private int nro_cabina;
        private int capacidad;
        private String estado;

        public Cabina(int nro_cabina)
        {
            this.Nro_cabina = nro_cabina;
            this.Capacidad = 1;
            this.Estado = Estado_Cabina.Oc.ToString();
        }

        public int Nro_cabina { get => nro_cabina; set => nro_cabina = value; }
        public int Capacidad { get => capacidad; set => capacidad = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
