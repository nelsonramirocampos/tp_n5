using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoPracticoN5
{
    public partial class Simulacion : Form
    {
        private Vector_Estado fila_anterior; //Fila anterior
        private Vector_Estado fila_nueva; //Fila nueva

        private List<double> rnd_normal;
        private List<double> tiempo_normal;
        public Simulacion()
        {
            InitializeComponent();
        }

        private void Simulacion_Load(object sender, EventArgs e)
        {
            cargarCategoria();
            cargarCosto();
            cargarFinAtencion();
        }

        private void cargarFinAtencion()
        {
            dgv_fin_atencion.Rows.Add("1", "0,3", "0,3");
            dgv_fin_atencion.Rows.Add("2", "0,45", "0,55");
            dgv_fin_atencion.Rows.Add("3", "0,55", "1,42");
            dgv_fin_atencion.Rows.Add("4", "1,55", "2,17");
            dgv_fin_atencion.Rows.Add("5", "2,55", "3,5");
        }

        private void cargarCosto()
        {
            dgv_costo.Rows.Add("1", "0");
            dgv_costo.Rows.Add("2", "3");
            dgv_costo.Rows.Add("3", "6");
            dgv_costo.Rows.Add("4", "9");
            dgv_costo.Rows.Add("5", "12");
        }

        private void cargarCategoria()
        {
            dgv_categoria.Rows.Add("1", "0,1");
            dgv_categoria.Rows.Add("2", "0,5");
            dgv_categoria.Rows.Add("3", "0,15");
            dgv_categoria.Rows.Add("4", "0,15");
            dgv_categoria.Rows.Add("5", "0,1");

            calcularIntervaloCategoria();
        }

        private void calcularIntervaloCategoria()
        {
            double desde = 0;
            double hasta = 0;

            foreach (DataGridViewRow row in dgv_categoria.Rows)
            {
                hasta = desde + Convert.ToDouble(row.Cells[1].Value.ToString());

                //Columna Desde
                row.Cells[2].Value = desde;
                //Columna Hasta
                row.Cells[3].Value = hasta;

                desde = hasta;
            }

            if (desde != 1.00)
            {
                MessageBox.Show("La suma de probabilidades de Categoria Vehiculos es distinta a 1");
                return;
            }
        }

        private void Btn_simular_Click(object sender, EventArgs e)
        {
            //Para validar que la probabilidad de 1
            calcularIntervaloCategoria();

            //Limpiar grilla
            dgv_simulacion.Rows.Clear();


            //Para el manejo de las filas
            fila_anterior = new Vector_Estado();
            fila_nueva = new Vector_Estado();


            //Obtencion de valores
            double media = Convert.ToDouble(txt_media_llegada.Text.ToString());
            double desviacion = Convert.ToDouble(txt_desviacion_llegada.Text.ToString());


            //Para los rnd de normal
            rnd_normal = new List<double>();
            rnd_normal.Add(GeneradoresRND.RndLenguaje());
            rnd_normal.Add(GeneradoresRND.RndLenguaje());
            tiempo_normal = GeneradoresRND.normal(media, desviacion, rnd_normal[0], rnd_normal[1]);


            //Tiempo completo de la simulacion
            if (String.IsNullOrEmpty(txt_min.Text))
            {
                MessageBox.Show("Ingrese la cantidad de horas y luego presione la tecla Enter");
                return;
            }
            double tiempo_simulacion = Convert.ToDouble(txt_min.Text);


            //Cuando recien comienza la simulacion, la fila anterior es la primera, por lo cual, inicializa todo
            fila_anterior.Evento = "Inicio";
            fila_anterior.Rnd_llegada = rnd_normal[0]; rnd_normal.RemoveAt(0);
            fila_anterior.Tiempo_entre_llegada = tiempo_normal[0]; tiempo_normal.RemoveAt(0);
            fila_anterior.Proximo_vehiculo = fila_anterior.Reloj + fila_anterior.Tiempo_entre_llegada;
            fila_anterior.Color_proximo_vehiculo = Color.GreenYellow;
            agregarFila(fila_anterior);


            for (int i = 1; i < 5; i++)
            {
                if (fila_anterior.Proximo_vehiculo < fila_anterior.Fin_atencion || fila_anterior.Fin_atencion == 0)
                {
                    evento_proximo_vehiculo(fila_nueva);
                }
                else if (fila_anterior.Proximo_vehiculo > fila_anterior.Fin_atencion)
                {
                    evento_fin_atencion(fila_nueva);
                }

                agregarFila(fila_nueva);

                
                fila_anterior = fila_nueva;

                if (this.rnd_normal.Count == 0)
                {
                    rnd_normal = new List<double>();
                    rnd_normal.Add(GeneradoresRND.RndLenguaje());
                    rnd_normal.Add(GeneradoresRND.RndLenguaje());
                    tiempo_normal = GeneradoresRND.normal(media, desviacion, rnd_normal[0], rnd_normal[1]);
                }
            }

            
        }

        private void evento_fin_atencion(Vector_Estado fila_nueva)
        {
            //POR HACER
            //  COBRAR
            //  GENERAR PROXIMO FIN DE ATENCION SI HAY VEHICULOS EN LOS PEAJES

            fila_nueva.eliminar_vehiculo(fila_nueva.Vehiculos.Count - 1);

            fila_nueva.Nro_fila = fila_anterior.Nro_fila + 1;
            fila_nueva.Evento = "Fin Atencion";
            fila_nueva.Reloj = fila_anterior.Fin_atencion;

            //No se calcula nuevamente una proxima de llegada, ya que es un evento de fin atencion
            fila_nueva.Proximo_vehiculo = fila_anterior.Proximo_vehiculo;

            //Categoria de Vehiculo
            //No se calcula ya que es un fin de atencion
            //fila_nueva.Rnd_categoria = GeneradoresRND.RndLenguaje();
            //fila_nueva.Categoria = buscarCategoria(fila_nueva.Rnd_categoria);

            //Fin de Atencion
            //OJO, YA QUE SI NO HAY VEHICULOS POR ATENDER, NO SE CALCULO OTRO FIN DE ATENCION
            if (fila_nueva.Vehiculos.Count > 0)
            {
                fila_nueva.Rnd_fin_atencion = GeneradoresRND.RndLenguaje();
                fila_nueva.Tiempo_entre_fin = buscarTiempoEntreFin(fila_nueva.Categoria, fila_nueva.Rnd_fin_atencion);
                fila_nueva.Fin_atencion = fila_nueva.Tiempo_entre_fin + fila_nueva.Reloj;
            }
            else
            {
                fila_nueva.Rnd_fin_atencion = 0;
                fila_nueva.Tiempo_entre_fin = 0;
                fila_nueva.Fin_atencion = 0;
            }

            //fila_nueva.Color_fin_atencion = Color.GreenYellow;
            //fila_nueva.Color_proximo_vehiculo = Color.White;
        }

        private void evento_proximo_vehiculo(Vector_Estado fila_nueva)
        {
            fila_nueva.Nro_fila = fila_anterior.Nro_fila + 1;
            fila_nueva.Evento = "Llegada Vehiculo";
            fila_nueva.Reloj = fila_anterior.Proximo_vehiculo;
            fila_nueva.Rnd_llegada = rnd_normal[0]; rnd_normal.RemoveAt(0);
            fila_nueva.Tiempo_entre_llegada = tiempo_normal[0]; tiempo_normal.RemoveAt(0);
            fila_nueva.Proximo_vehiculo = fila_nueva.Reloj + fila_nueva.Tiempo_entre_llegada;

            if (fila_anterior.Fin_atencion == 0)
            {
                //Categoria de Vehiculo
                fila_nueva.Rnd_categoria = GeneradoresRND.RndLenguaje();
                fila_nueva.Categoria = buscarCategoria(fila_nueva.Rnd_categoria);
                //Fin de Atencion
                fila_nueva.Rnd_fin_atencion = GeneradoresRND.RndLenguaje();
                fila_nueva.Tiempo_entre_fin = buscarTiempoEntreFin(fila_nueva.Categoria, fila_nueva.Rnd_fin_atencion);
                fila_nueva.Fin_atencion = fila_nueva.Reloj + fila_nueva.Tiempo_entre_fin;
            }
            else //Hay vehiculos para salir
            {
                //Categoria de Vehiculo
                //fila_nueva.Rnd_categoria = 0;
                fila_nueva.Categoria = 0;
                //Fin de Atencion
                fila_nueva.Rnd_fin_atencion = 0;
                fila_nueva.Tiempo_entre_fin = 0;

                fila_nueva.Fin_atencion = fila_anterior.Fin_atencion;
            }

            //fila_nueva.Color_proximo_vehiculo = Color.GreenYellow;
            //fila_nueva.Color_fin_atencion = Color.White;

            //BORRAR CUANDO SE TERMINE DE ARMAR TODO
            fila_nueva.Vehiculos.Add(new Vehiculo());
        }

        private double buscarTiempoEntreFin(int categoria, double rnd_fin)
        {
            //Obtener A y B segun la categoria
            double A = Convert.ToDouble(dgv_fin_atencion.Rows[categoria - 1].Cells[1].Value.ToString());
            double B = Convert.ToDouble(dgv_fin_atencion.Rows[categoria - 1].Cells[2].Value.ToString());

            return GeneradoresRND.uniforme(A, B, rnd_fin);
        }

        private int buscarCategoria(double rnd_categoria)
        {
            foreach (DataGridViewRow row in dgv_categoria.Rows)
            {
                double desde = Convert.ToDouble(row.Cells[2].Value.ToString());
                double hasta = Convert.ToDouble(row.Cells[3].Value.ToString());

                int categoria = Convert.ToInt16(row.Cells[0].Value.ToString());

                if (desde <= rnd_categoria && hasta > rnd_categoria)
                {
                    return categoria;
                }
                else if(rnd_categoria == 1)
                {
                    return categoria;
                }
            }

            return 404;
        }

        private void agregarFila(Vector_Estado fila)
        {
            dgv_simulacion.Rows.Add(
                    fila.Nro_fila,
                    fila.Evento,
                    fila.Reloj,
                    (fila.Rnd_llegada == 0) ? "" : fila.Rnd_llegada.ToString(),
                    (fila.Tiempo_entre_llegada == 0) ? "" : fila.Tiempo_entre_llegada.ToString(),
                    (fila.Proximo_vehiculo == 0) ? "" : fila.Proximo_vehiculo.ToString(),
                    (fila.Rnd_categoria == 0) ? "" : fila.Rnd_categoria.ToString(),
                    (fila.Categoria == 0) ? "" : fila.Categoria.ToString(),
                    (fila.Rnd_fin_atencion == 0) ? "" : fila.Rnd_fin_atencion.ToString(),
                    (fila.Tiempo_entre_fin == 0) ? "" : fila.Tiempo_entre_fin.ToString(),
                    (fila.Fin_atencion == 0) ? "" : fila.Fin_atencion.ToString()
            );

            dgv_simulacion.Rows[dgv_simulacion.Rows.Count - 1].Cells["cProximoVehiculo"].Style.BackColor = fila.Color_proximo_vehiculo;
            dgv_simulacion.Rows[dgv_simulacion.Rows.Count - 1].Cells["cFinAtencion"].Style.BackColor = fila.Color_fin_atencion;
        }

        private void Dgv_categoria_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void Txt_hs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int) e.KeyChar == (int) Keys.Enter)
            {
                txt_min.Text = (Convert.ToDouble(txt_hs.Text) * 60).ToString("N2");
            }
        }
    }
}
