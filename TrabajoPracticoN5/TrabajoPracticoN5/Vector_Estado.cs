using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private List<Vehiculo> vehiculos;

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

            this.Vehiculos = new List<Vehiculo>();
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

        public void agregar_vehiculo(Vehiculo v)
        {
            Vehiculos.Add(v);

            ordenar();
        }

        private void ordenar()
        {
            List<Vehiculo> ordenado = Vehiculos.OrderBy(o => o.Tiempo_fin).ToList();

            Vehiculos = ordenado;
        }

        public void eliminar_vehiculo(int i)
        {
            Vehiculos.RemoveAt(i);

            ordenar();
        }
    }
}
