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

        int cont_vehiculo = 0; //Para controlar la cantidad de autos en el sistema

        //Para el desde y  hasta de filas para mostrar
        private double tiempo_desde;
        private double tiempo_hasta;

        private double lambda;

        //Tiempo de cada cuanto se debe visualizar el saldo
        private double metrica_cada_cien;

        private bool isRowsFinal = false;
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

            //if (desde != 1.00)
            //{
            //    MessageBox.Show("La suma de probabilidades de Categoria Vehiculos es distinta a 1");
            //    return;
            //}
        }

        public static void soloNumeros(KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '-') //permitir guion medi
            {
                e.Handled = false;
            }
            /*else if (e.KeyChar == ',') //Permitir punto decimal
            {
                e.Handled = false;
            }*/
            else if (e.KeyChar == '.') //Permitir punto decimal
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void Btn_simular_Click(object sender, EventArgs e)
        {
            //Para validar que la probabilidad de 1
            calcularIntervaloCategoria();

            //Limpiar grilla
            dgv_simulacion.Rows.Clear();
            dgv_automovil.Rows.Clear();
            dgv_automovil.Columns.Clear();
            dgv_automovil.Columns.Add("cNroFilaVehiculo", "Nro Fila");
            dgv_automovil.Rows.Add("0");
            dgv_cabina.Columns.Clear();
            dgv_cabina.Columns.Add("cNroFilaCabina", "Nro Fila");
            dgv_cabina.Rows.Add("0");
            txt_recaudacion_min.Text = "";
            txt_recaudacion_100.Text = "";

            if (String.IsNullOrWhiteSpace(txt_hs.Text))
            {
                MessageBox.Show("Debe ingresar un valor válido para la cantidad de horas");
                txt_hs.Focus();
                return;
            }

            if (String.IsNullOrWhiteSpace(txt_desde.Text))
            {
                MessageBox.Show("Debe ingresar un valor válido para el Tiempo Desde");
                txt_desde.Focus();
                return;
            }

            if (String.IsNullOrWhiteSpace(txt_hasta.Text))
            {
                MessageBox.Show("Debe ingresar un valor válido para el Tiempo Hasta");
                txt_hasta.Focus();
                return;
            }

            //Calculos de las primeras tablas
            int cat1 = int.Parse(dgv_categoria.Rows[0].Cells[0].Value.ToString());
            double prob1 = double.Parse(dgv_categoria.Rows[0].Cells[1].Value.ToString());
            int cat2 = int.Parse(dgv_categoria.Rows[1].Cells[0].Value.ToString());
            double prob2 = double.Parse(dgv_categoria.Rows[1].Cells[1].Value.ToString());
            int cat3 = int.Parse(dgv_categoria.Rows[2].Cells[0].Value.ToString());
            double prob3 = double.Parse(dgv_categoria.Rows[2].Cells[1].Value.ToString());
            int cat4 = int.Parse(dgv_categoria.Rows[3].Cells[0].Value.ToString());
            double prob4 = double.Parse(dgv_categoria.Rows[3].Cells[1].Value.ToString());
            int cat5 = int.Parse(dgv_categoria.Rows[4].Cells[0].Value.ToString());
            double prob5 = double.Parse(dgv_categoria.Rows[4].Cells[1].Value.ToString());
            double probCategoriVehiculo = prob1 + prob2 + prob3 + prob4 + prob5;
            if(probCategoriVehiculo != 1)
            {
                MessageBox.Show("Validar la suma de probabilidades para Vehiculo", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //-------------------------------

            this.tiempo_desde = Convert.ToDouble(txt_desde.Text);
            this.tiempo_hasta = Convert.ToDouble(txt_hasta.Text);

            this.cont_vehiculo = 0;

            //Para el manejo de las filas
            fila_anterior = new Vector_Estado();
            fila_nueva = new Vector_Estado();


            //Obtencion de valores
            double media = Convert.ToDouble(txt_media_llegada.Text.ToString());
            double desviacion = Convert.ToDouble(txt_desviacion_llegada.Text.ToString());
            //Para el rnd de exponencial
            this.lambda = 1 / Convert.ToDouble(txt_media_llegada.Text);


            //Tiempo completo de la simulacion
            //if (String.IsNullOrEmpty(txt_min.Text))
            //{
            //    MessageBox.Show("Ingrese la cantidad de horas y luego presione la tecla Enter");
            //    return;
            //}
            //double tiempoSimulacion = Convert.ToDouble(txt_min.Text);


            //Cuando recien comienza la simulacion, la fila anterior es la primera, por lo cual, inicializa todo
            fila_anterior.Evento = "Inicio";
            fila_anterior.Rnd_llegada = GeneradoresRND.RndLenguaje();
            fila_anterior.Tiempo_entre_llegada = GeneradoresRND.exponencial(this.lambda, fila_anterior.Rnd_llegada);
            fila_anterior.Proximo_vehiculo = fila_anterior.Reloj + fila_anterior.Tiempo_entre_llegada;
            fila_anterior.Color_proximo_vehiculo = Color.GreenYellow;
            agregarFila(fila_anterior);

            fila_nueva = fila_anterior;

            dgv_automovil.Rows[dgv_automovil.Rows.Count - 1].Visible = visualizarFila();
            dgv_cabina.Rows[dgv_cabina.Rows.Count - 1].Visible = visualizarFila();

            //Queda fijo el valor para visualizar el monto cada tanto tiempo
            metrica_cada_cien = 1 * 60;

            for (int i = 1; i < 200; i++)
            //for(double i = fila_anterior.Reloj; i < tiempoSimulacion;)
            {
                if (fila_anterior.Proximo_vehiculo < fila_anterior.Fin_atencion || fila_anterior.Fin_atencion == 0)
                {
                    evento_proximo_vehiculo(fila_nueva);
                }
                else 
                {
                    evento_fin_atencion(fila_nueva);
                }

                //Para la metrica de cada 100hs
                if ((fila_nueva.Reloj - this.metrica_cada_cien) >= 0)
                {
                    fila_nueva.Monto_cada_cien = fila_nueva.Monto_ac;
                    this.metrica_cada_cien = this.metrica_cada_cien + this.metrica_cada_cien;
                    
                }
                else
                {
                    fila_nueva.Monto_cada_cien = 0;
                }

                fila_anterior = fila_nueva;

                agregarFila(fila_nueva);
                actualizar_grilla_automoviles();
                actualizar_grilla_cabina();
            }

            this.isRowsFinal = true;
            agregarFila(fila_nueva);
            actualizar_grilla_automoviles();
            actualizar_grilla_cabina();

            double rec_ac = double.Parse(dgv_simulacion.Rows[dgv_simulacion.Rows.Count - 1].Cells[13].Value.ToString());
            double horas_ac = double.Parse(dgv_simulacion.Rows[dgv_simulacion.Rows.Count - 1].Cells[2].Value.ToString());
            txt_recaudacion_min.Text = (Utilidades.truncar(rec_ac / horas_ac)).ToString();
            
        }

        private void actualizar_grilla_cabina()
        {
            int nro_fila = dgv_simulacion.Rows.Count - 1;

            if (dgv_cabina.Columns.Count -1 < this.fila_nueva.Cabinas.Count)
            {
                dgv_cabina.Columns.Add("cCabina" + this.fila_nueva.Cabinas.Count, "Cabina " + this.fila_nueva.Cabinas.Count);
            }


            DataGridViewRow fila = (DataGridViewRow)dgv_cabina.Rows[dgv_cabina.Rows.Count - 1].Clone();
            fila.Cells[0].Value = nro_fila;

            foreach (Cabina cabina in this.fila_nueva.Cabinas)
            {
                fila.Cells[cabina.Nro_cabina].Value = cabina.Estado + "(" + cabina.Capacidad + ")";
            }

            dgv_cabina.Rows.Add(fila);
            dgv_cabina.Rows[dgv_cabina.Rows.Count - 1].Visible = visualizarFila();
        }

        private void actualizar_grilla_automoviles()
        {
            int nro_fila = dgv_simulacion.Rows.Count - 1;

            if (this.cont_vehiculo == 1 && this.fila_nueva.Vehiculos.Count >= 1)
            {
                dgv_automovil.Columns.Add("cAuto" + this.fila_nueva.Vehiculos[0].Nro, "Auto " + this.fila_nueva.Vehiculos[0].Nro);
                dgv_automovil.Columns[0].FillWeight = 1;

                dgv_automovil.Rows.Add(nro_fila, this.fila_nueva.Vehiculos[0].Estado + " (" + this.fila_nueva.Vehiculos[0].Cabina_actual + ")");
                dgv_automovil.Rows[dgv_automovil.Rows.Count - 1].Visible = visualizarFila();

                return;
            }
            if (dgv_automovil.Columns.Count-1 < this.cont_vehiculo)
            {
                dgv_automovil.Columns.Add("cAuto" + this.cont_vehiculo, "Auto " + this.cont_vehiculo);
                dgv_automovil.Columns[this.cont_vehiculo].FillWeight = 1;
            }

            DataGridViewRow fila = CloneWithValues(dgv_automovil.Rows[dgv_automovil.Rows.Count - 1]);
            fila.Cells[0].Value = nro_fila;

            for (int i = 1; i < dgv_automovil.Columns.Count; i++)
            {
                foreach (Vehiculo vehiculo in this.fila_nueva.Vehiculos)
                {
                    if (vehiculo.Nro == i)
                    {
                        fila.Cells[vehiculo.Nro].Value = vehiculo.Estado + " (" + vehiculo.Cabina_actual + ")";
                        break;
                    }
                    else
                    {
                        fila.Cells[i].Value = "";
                    }
                }
            }


            dgv_automovil.Rows.Add(fila);
            dgv_automovil.Rows[dgv_automovil.Rows.Count - 1].Visible = visualizarFila();
        }


        public DataGridViewRow CloneWithValues(DataGridViewRow row)
        {
            DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();
            for (Int32 index = 0; index < row.Cells.Count; index++)
            {
                clonedRow.Cells[index].Value = row.Cells[index].Value;
            }
            return clonedRow;
        }


        private void evento_fin_atencion(Vector_Estado fila_nueva)
        {
            Vehiculo v = fila_nueva.Vehiculos[0];

            fila_nueva.eliminar_vehiculo(0);

            fila_nueva.Nro_fila = fila_anterior.Nro_fila + 1;
            fila_nueva.Evento = "Fin Atencion " + v.Nro;
            fila_nueva.Reloj = fila_anterior.Fin_atencion;

            fila_nueva.Rnd_llegada = 0;
            fila_nueva.Tiempo_entre_llegada = 0;
            fila_nueva.Proximo_vehiculo = fila_anterior.Proximo_vehiculo;

            fila_nueva.Rnd_categoria = 0;
            fila_nueva.Categoria = 0;
            fila_nueva.Rnd_fin_atencion = 0;
            fila_nueva.Tiempo_entre_fin = 0;
            fila_nueva.Fin_atencion = 0;

            fila_nueva.Monto = -1;
            fila_nueva.Monto_ac = fila_anterior.Monto_ac;

            fila_nueva.Nro_cabina = -1;

            if (fila_nueva.Vehiculos.Count > 0)  //Hay vehiculos en estado EA
            {
                fila_nueva.Rnd_categoria = GeneradoresRND.RndLenguaje();
                fila_nueva.Categoria = buscarCategoria(fila_nueva.Rnd_categoria);

                fila_nueva.Rnd_fin_atencion = GeneradoresRND.RndLenguaje();
                fila_nueva.Tiempo_entre_fin = buscarTiempoEntreFin(fila_nueva.Categoria, fila_nueva.Rnd_fin_atencion);
                fila_nueva.Fin_atencion = fila_nueva.Tiempo_entre_fin + fila_nueva.Reloj;

                fila_nueva.Vehiculos[0].Categoria = fila_nueva.Categoria;
                fila_nueva.Vehiculos[0].Tiempo_fin = fila_nueva.Fin_atencion;
                fila_nueva.Vehiculos[0].Estado = Estado_Vehiculo.SA.ToString();

                fila_nueva.Monto = buscarMonto(fila_nueva.Categoria);
                fila_nueva.Monto_ac = fila_anterior.Monto_ac + fila_nueva.Monto;

                fila_nueva.Nro_cabina = fila_nueva.Vehiculos[0].Cabina_actual;
            }

            if (fila_nueva.Fin_atencion == 0)
            {
                fila_nueva.Color_fin_atencion = Color.White;
                fila_nueva.Color_proximo_vehiculo = Color.GreenYellow;
            }
            else
            {
                fila_nueva.Color_fin_atencion = Color.GreenYellow;
                fila_nueva.Color_proximo_vehiculo = Color.White;
            }
        }

        private double buscarMonto(int categoria)
        {
            return Convert.ToDouble(dgv_costo.Rows[categoria-1].Cells[1].Value.ToString());
        }

        private void evento_proximo_vehiculo(Vector_Estado fila_nueva)
        {
            Vehiculo V = new Vehiculo();

            this.cont_vehiculo = this.cont_vehiculo + 1;
            V.Nro = this.cont_vehiculo;

            //Propio de la grilla
            fila_nueva.Nro_fila = fila_anterior.Nro_fila + 1;
            fila_nueva.Evento = "Llegada Vehiculo " + cont_vehiculo;
            fila_nueva.Reloj = fila_anterior.Proximo_vehiculo;
            fila_nueva.Rnd_llegada = GeneradoresRND.RndLenguaje();
            fila_nueva.Tiempo_entre_llegada = GeneradoresRND.exponencial(this.lambda, fila_nueva.Rnd_llegada);
            fila_nueva.Proximo_vehiculo = fila_nueva.Reloj + fila_nueva.Tiempo_entre_llegada;

            V.Cabina_actual = fila_nueva.asignarCabina();

            if (fila_nueva.EsCapacidadUno(V.Cabina_actual)) //Si es asi, se calcula el tiempo fin
            {
                //Categoria de Vehiculo
                fila_nueva.Rnd_categoria = GeneradoresRND.RndLenguaje();
                fila_nueva.Categoria = buscarCategoria(fila_nueva.Rnd_categoria);
                //Fin de Atencion
                fila_nueva.Rnd_fin_atencion = GeneradoresRND.RndLenguaje();
                fila_nueva.Tiempo_entre_fin = buscarTiempoEntreFin(fila_nueva.Categoria, fila_nueva.Rnd_fin_atencion);
                fila_nueva.Fin_atencion = fila_nueva.Reloj + fila_nueva.Tiempo_entre_fin;

                V.Estado = Estado_Vehiculo.SA.ToString();

                fila_nueva.Monto = buscarMonto(fila_nueva.Categoria);
                fila_nueva.Monto_ac = fila_anterior.Monto_ac + fila_nueva.Monto;  
            }
            else
            {
                //Categoria de Vehiculo
                fila_nueva.Rnd_categoria = 0;
                fila_nueva.Categoria = 0;
                //Fin de Atencion
                fila_nueva.Rnd_fin_atencion = 0;
                fila_nueva.Tiempo_entre_fin = 0;
                fila_nueva.Fin_atencion = fila_anterior.Fin_atencion;

                fila_nueva.Monto = -1;
                fila_nueva.Monto_ac = fila_anterior.Monto_ac;

                fila_nueva.Nro_cabina = -1;
            }

            if (fila_nueva.Fin_atencion == 0)
            {
                fila_nueva.Color_fin_atencion = Color.White;
                fila_nueva.Color_proximo_vehiculo = Color.GreenYellow;
            }
            else
            {
                fila_nueva.Color_fin_atencion = Color.GreenYellow;
                fila_nueva.Color_proximo_vehiculo = Color.White;
            }


            fila_nueva.Nro_cabina = V.Cabina_actual;
            if (fila_nueva.Max_cabina < fila_nueva.Cabinas.Count) fila_nueva.Max_cabina = fila_nueva.Cabinas.Count;
            fila_nueva.Vehiculos.Add(V);
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

        private void agregarFila(Vector_Estado fila, bool visible = true)
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
                    (fila.Fin_atencion == 0) ? "" : fila.Fin_atencion.ToString(),
                    (fila.Nro_cabina <= 0) ? "" : fila.Nro_cabina.ToString(),
                    (fila.Monto <= 0) ? "" : fila.Monto.ToString(),
                    fila.Monto_ac.ToString(),
                    fila.Max_cabina.ToString(),
                    (fila.Monto_cada_cien == 0) ? "" : fila.Monto_cada_cien.ToString()
            );

            if(string.IsNullOrWhiteSpace(txt_recaudacion_100.Text))
            { 
                txt_recaudacion_100.Text = (fila.Monto_cada_cien == 0) ? "" : fila.Monto_cada_cien.ToString();
                if (txt_recaudacion_100.Text != "")
                    txt_recaudacion_100.Text = (Utilidades.truncar(double.Parse(txt_recaudacion_100.Text)/fila.Reloj)).ToString();
            }

            dgv_simulacion.Rows[dgv_simulacion.Rows.Count - 1].Visible = visualizarFila();           

            dgv_simulacion.Rows[dgv_simulacion.Rows.Count - 1].Cells["cProximoVehiculo"].Style.BackColor = fila.Color_proximo_vehiculo;
            dgv_simulacion.Rows[dgv_simulacion.Rows.Count - 1].Cells["cFinAtencion"].Style.BackColor = fila.Color_fin_atencion;
        }


        private void Txt_hs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int) e.KeyChar == (int) Keys.Enter)
            {
                txt_min.Text = (Convert.ToDouble(txt_hs.Text) * 60).ToString("N2");
            }
        }

        private bool visualizarFila()
        {
            if (isRowsFinal == true)
            {
                return true;
            }

            return this.fila_nueva.Reloj >= this.tiempo_desde && this.fila_nueva.Reloj <= this.tiempo_hasta;
        }

        private void dgv_categoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);

        }

        private void txt_desde_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void txt_hasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void txt_hs_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_hs_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void dgv_simulacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
