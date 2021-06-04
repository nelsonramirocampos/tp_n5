using System;
using System.Collections.Generic;
using System.Drawing;

namespace TrabajoPracticoN5
{
    class Vector_Estado
    {
        private int nro_fila;
        private String evento;
        private double reloj;
        
        private double rnd_llegada;
        private double tiempo_entre_llegada;
        private double proximo_vehiculo;
        private Color color_proximo_vehiculo;

        private double rnd_categoria;
        private int categoria;

        private double rnd_fin_atencion;
        private double tiempo_entre_fin;
        private double fin_atencion;
        private Color color_fin_atencion;

        private int nro_cabina;

        private double monto;
        private double monto_ac;
        private int max_cabina;

        private double promedio_cab_oc_fila = 0;
        private double max_prom_cabina_oc = 0;

        private double monto_cada_cien;

        private List<Vehiculo> vehiculos;

        private List<Cabina> cabinas;


        public Vector_Estado()
        {
            this.Nro_fila = 0;
            this.Evento = "";
            this.Reloj = 0;

            this.Rnd_llegada = 0;
            this.Tiempo_entre_llegada = 0;
            this.Proximo_vehiculo = 0;
            this.Color_proximo_vehiculo = Color.White;

            this.Rnd_categoria = 0;
            this.Categoria = 0;

            this.Rnd_fin_atencion = 0;
            this.Tiempo_entre_fin = 0;
            this.Fin_atencion = 0;
            this.Color_fin_atencion = Color.White;

            this.Nro_cabina = 0;
            this.Monto = 0;
            this.Monto_ac = 0;
            this.Max_cabina = 0;

            this.Vehiculos = new List<Vehiculo>();

            this.Cabinas = new List<Cabina>();

            this.monto_cada_cien = 0;
        }

        public int Nro_fila { get => nro_fila; set => nro_fila = value; }
        public string Evento { get => evento; set => evento = value; }
        public double Reloj { get => reloj; set => reloj = value; }
        public double Rnd_llegada { get => rnd_llegada; set => rnd_llegada = value; }
        public double Tiempo_entre_llegada { get => tiempo_entre_llegada; set => tiempo_entre_llegada = value; }
        public double Proximo_vehiculo { get => proximo_vehiculo; set => proximo_vehiculo = value; }
        public double Rnd_categoria { get => rnd_categoria; set => rnd_categoria = value; }
        public int Categoria { get => categoria; set => categoria = value; }
        public double Tiempo_entre_fin { get => tiempo_entre_fin; set => tiempo_entre_fin = value; }
        public double Fin_atencion { get => fin_atencion; set => fin_atencion = value; }
        public double Rnd_fin_atencion { get => rnd_fin_atencion; set => rnd_fin_atencion = value; }
        public Color Color_proximo_vehiculo { get => color_proximo_vehiculo; set => color_proximo_vehiculo = value; }
        public Color Color_fin_atencion { get => color_fin_atencion; set => color_fin_atencion = value; }
        public List<Vehiculo> Vehiculos { get => vehiculos; set => vehiculos = value; }
        internal List<Cabina> Cabinas { get => cabinas; set => cabinas = value; }
        public int Nro_cabina { get => nro_cabina; set => nro_cabina = value; }
        public double Monto { get => monto; set => monto = value; }
        public double Monto_ac { get => monto_ac; set => monto_ac = value; }
        public int Max_cabina { get => max_cabina; set => max_cabina = value; }
        public double Monto_cada_cien { get => monto_cada_cien; set => monto_cada_cien = value; }
        public double Max_prom_cabina_oc { get => max_prom_cabina_oc; set => max_prom_cabina_oc = value; }
        public double Promedio_cab_oc_fila { get => promedio_cab_oc_fila; set => promedio_cab_oc_fila = value; }

        public void eliminar_vehiculo(int i)
        {
            int nro_cabina = Vehiculos[i].Cabina_actual - 1;

            Cabinas[nro_cabina].Capacidad = Cabinas[nro_cabina].Capacidad - 1;
            if (Cabinas[nro_cabina].Capacidad == 0)
            {
                Cabinas[nro_cabina].Estado = Estado_Cabina.L.ToString();
            }
            Vehiculos.RemoveAt(i);
        }


        public int asignarCabina()
        {
            foreach (Cabina cabina in this.Cabinas)
            {
                if (cabina.Capacidad < 4)
                {
                    cabina.Capacidad++;
                    cabina.Estado = Estado_Cabina.Oc.ToString();

                    return cabina.Nro_cabina;
                }
            }


            Cabina x = new Cabina(this.Cabinas.Count + 1);
            x.Estado = Estado_Cabina.Oc.ToString();

            this.Cabinas.Add(x);

            return x.Nro_cabina;
        }

        internal bool EsCapacidadUno(int cabina_actual)
        {
            return this.Cabinas[cabina_actual - 1].Capacidad == 1;
        }

        internal double porcentajeCabinaOcupada()
        {
            int cantidad = 0;
            foreach (Cabina cabina in this.Cabinas)
            {
                if (cabina.Estado == Estado_Cabina.Oc.ToString()) cantidad++;
            }

            return (this.Cabinas.Count == 0) ? 0 : Utilidades.truncar((Convert.ToDouble(cantidad)/ Convert.ToDouble(this.Cabinas.Count)) * 100);
        }

        internal int cantidadCabinasOcupadas()
        {
            int cantidad = 0;
            foreach (Cabina cabina in this.Cabinas)
            {
                if (cabina.Estado == Estado_Cabina.Oc.ToString()) cantidad++;
            }

            return cantidad;
        }
    }
}
