namespace TrabajoPracticoN5
{
    partial class Simulacion
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_hs = new System.Windows.Forms.TextBox();
            this.txt_min = new System.Windows.Forms.TextBox();
            this.dgv_categoria = new System.Windows.Forms.DataGridView();
            this.cCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDesde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgv_costo = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_fin_atencion = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_desviacion_llegada = new System.Windows.Forms.TextBox();
            this.txt_media_llegada = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_simulacion = new System.Windows.Forms.DataGridView();
            this.cNroFila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEvento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cReloj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRnd_llegada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTiempoEntreLlegada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProximoVehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRndCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCategoriaSim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRnd_Fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTiempoEntreFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFinAtencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNroCabina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMontoAc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_automovil = new System.Windows.Forms.DataGridView();
            this.cNroFilaVehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv_cabina = new System.Windows.Forms.DataGridView();
            this.btn_simular = new System.Windows.Forms.Button();
            this.cMaxCabina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_categoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_costo)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_fin_atencion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_simulacion)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_automovil)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cabina)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cantidad Hs.:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cantidad Min.:";
            // 
            // txt_hs
            // 
            this.txt_hs.Location = new System.Drawing.Point(89, 55);
            this.txt_hs.Name = "txt_hs";
            this.txt_hs.Size = new System.Drawing.Size(100, 20);
            this.txt_hs.TabIndex = 2;
            this.txt_hs.Text = "0";
            this.txt_hs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_hs_KeyPress);
            // 
            // txt_min
            // 
            this.txt_min.Enabled = false;
            this.txt_min.Location = new System.Drawing.Point(89, 82);
            this.txt_min.Name = "txt_min";
            this.txt_min.Size = new System.Drawing.Size(100, 20);
            this.txt_min.TabIndex = 3;
            // 
            // dgv_categoria
            // 
            this.dgv_categoria.AllowUserToAddRows = false;
            this.dgv_categoria.AllowUserToDeleteRows = false;
            this.dgv_categoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_categoria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cCategoria,
            this.cPr,
            this.cDesde,
            this.cHasta});
            this.dgv_categoria.Location = new System.Drawing.Point(16, 143);
            this.dgv_categoria.MultiSelect = false;
            this.dgv_categoria.Name = "dgv_categoria";
            this.dgv_categoria.RowHeadersVisible = false;
            this.dgv_categoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_categoria.Size = new System.Drawing.Size(360, 148);
            this.dgv_categoria.TabIndex = 4;
            this.dgv_categoria.SelectionChanged += new System.EventHandler(this.Dgv_categoria_SelectionChanged);
            // 
            // cCategoria
            // 
            this.cCategoria.HeaderText = "Categoria";
            this.cCategoria.Name = "cCategoria";
            this.cCategoria.ReadOnly = true;
            // 
            // cPr
            // 
            this.cPr.HeaderText = "Pr";
            this.cPr.Name = "cPr";
            this.cPr.ReadOnly = true;
            // 
            // cDesde
            // 
            this.cDesde.HeaderText = "Desde";
            this.cDesde.Name = "cDesde";
            this.cDesde.ReadOnly = true;
            // 
            // cHasta
            // 
            this.cHasta.HeaderText = "Hasta";
            this.cHasta.Name = "cHasta";
            this.cHasta.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Categoria Vehiculo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(526, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Categoria Costo";
            // 
            // dgv_costo
            // 
            this.dgv_costo.AllowUserToAddRows = false;
            this.dgv_costo.AllowUserToDeleteRows = false;
            this.dgv_costo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_costo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.cCosto});
            this.dgv_costo.Location = new System.Drawing.Point(415, 143);
            this.dgv_costo.Name = "dgv_costo";
            this.dgv_costo.ReadOnly = true;
            this.dgv_costo.RowHeadersVisible = false;
            this.dgv_costo.Size = new System.Drawing.Size(360, 148);
            this.dgv_costo.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Categoria";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // cCosto
            // 
            this.cCosto.HeaderText = "Costo";
            this.cCosto.Name = "cCosto";
            this.cCosto.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_fin_atencion);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_desviacion_llegada);
            this.groupBox1.Controls.Add(this.txt_media_llegada);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(805, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 252);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parametros evento";
            // 
            // dgv_fin_atencion
            // 
            this.dgv_fin_atencion.AllowUserToAddRows = false;
            this.dgv_fin_atencion.AllowUserToDeleteRows = false;
            this.dgv_fin_atencion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_fin_atencion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.cA,
            this.cB});
            this.dgv_fin_atencion.Location = new System.Drawing.Point(49, 127);
            this.dgv_fin_atencion.Name = "dgv_fin_atencion";
            this.dgv_fin_atencion.ReadOnly = true;
            this.dgv_fin_atencion.RowHeadersVisible = false;
            this.dgv_fin_atencion.Size = new System.Drawing.Size(304, 112);
            this.dgv_fin_atencion.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Categoria";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // cA
            // 
            this.cA.HeaderText = "A";
            this.cA.Name = "cA";
            this.cA.ReadOnly = true;
            // 
            // cB
            // 
            this.cB.HeaderText = "B";
            this.cB.Name = "cB";
            this.cB.ReadOnly = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Fin Atencion";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(87, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Desviacion:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(83, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Media:";
            // 
            // txt_desviacion_llegada
            // 
            this.txt_desviacion_llegada.Location = new System.Drawing.Point(156, 68);
            this.txt_desviacion_llegada.Name = "txt_desviacion_llegada";
            this.txt_desviacion_llegada.Size = new System.Drawing.Size(72, 20);
            this.txt_desviacion_llegada.TabIndex = 2;
            this.txt_desviacion_llegada.Text = "1";
            // 
            // txt_media_llegada
            // 
            this.txt_media_llegada.Location = new System.Drawing.Point(128, 42);
            this.txt_media_llegada.Name = "txt_media_llegada";
            this.txt_media_llegada.Size = new System.Drawing.Size(65, 20);
            this.txt_media_llegada.TabIndex = 1;
            this.txt_media_llegada.Text = "2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Llegada Vehiculo";
            // 
            // dgv_simulacion
            // 
            this.dgv_simulacion.AllowUserToAddRows = false;
            this.dgv_simulacion.AllowUserToDeleteRows = false;
            this.dgv_simulacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_simulacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cNroFila,
            this.cEvento,
            this.cReloj,
            this.cRnd_llegada,
            this.cTiempoEntreLlegada,
            this.cProximoVehiculo,
            this.cRndCategoria,
            this.cCategoriaSim,
            this.cRnd_Fin,
            this.cTiempoEntreFin,
            this.cFinAtencion,
            this.cNroCabina,
            this.cMonto,
            this.cMontoAc,
            this.cMaxCabina});
            this.dgv_simulacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_simulacion.Location = new System.Drawing.Point(0, 0);
            this.dgv_simulacion.Name = "dgv_simulacion";
            this.dgv_simulacion.ReadOnly = true;
            this.dgv_simulacion.RowHeadersVisible = false;
            this.dgv_simulacion.Size = new System.Drawing.Size(1198, 239);
            this.dgv_simulacion.TabIndex = 9;
            // 
            // cNroFila
            // 
            this.cNroFila.HeaderText = "Nro Fila";
            this.cNroFila.Name = "cNroFila";
            this.cNroFila.ReadOnly = true;
            // 
            // cEvento
            // 
            this.cEvento.HeaderText = "Evento";
            this.cEvento.Name = "cEvento";
            this.cEvento.ReadOnly = true;
            // 
            // cReloj
            // 
            this.cReloj.HeaderText = "Reloj (min)";
            this.cReloj.Name = "cReloj";
            this.cReloj.ReadOnly = true;
            // 
            // cRnd_llegada
            // 
            this.cRnd_llegada.HeaderText = "RND_Llegada";
            this.cRnd_llegada.Name = "cRnd_llegada";
            this.cRnd_llegada.ReadOnly = true;
            // 
            // cTiempoEntreLlegada
            // 
            this.cTiempoEntreLlegada.HeaderText = "Tiempo_Entre_Llegada";
            this.cTiempoEntreLlegada.Name = "cTiempoEntreLlegada";
            this.cTiempoEntreLlegada.ReadOnly = true;
            // 
            // cProximoVehiculo
            // 
            this.cProximoVehiculo.HeaderText = "Proximo_Vehiculo";
            this.cProximoVehiculo.Name = "cProximoVehiculo";
            this.cProximoVehiculo.ReadOnly = true;
            // 
            // cRndCategoria
            // 
            this.cRndCategoria.HeaderText = "RND_Categoria";
            this.cRndCategoria.Name = "cRndCategoria";
            this.cRndCategoria.ReadOnly = true;
            // 
            // cCategoriaSim
            // 
            this.cCategoriaSim.HeaderText = "Categoria";
            this.cCategoriaSim.Name = "cCategoriaSim";
            this.cCategoriaSim.ReadOnly = true;
            // 
            // cRnd_Fin
            // 
            this.cRnd_Fin.HeaderText = "RND_Fin";
            this.cRnd_Fin.Name = "cRnd_Fin";
            this.cRnd_Fin.ReadOnly = true;
            // 
            // cTiempoEntreFin
            // 
            this.cTiempoEntreFin.HeaderText = "Tiempo_Entre_Fin";
            this.cTiempoEntreFin.Name = "cTiempoEntreFin";
            this.cTiempoEntreFin.ReadOnly = true;
            // 
            // cFinAtencion
            // 
            this.cFinAtencion.HeaderText = "Fin_Atencion";
            this.cFinAtencion.Name = "cFinAtencion";
            this.cFinAtencion.ReadOnly = true;
            // 
            // cNroCabina
            // 
            this.cNroCabina.HeaderText = "Nro Cabina";
            this.cNroCabina.Name = "cNroCabina";
            this.cNroCabina.ReadOnly = true;
            // 
            // cMonto
            // 
            this.cMonto.HeaderText = "Monto";
            this.cMonto.Name = "cMonto";
            this.cMonto.ReadOnly = true;
            // 
            // cMontoAc
            // 
            this.cMontoAc.HeaderText = "Monto Ac";
            this.cMontoAc.Name = "cMontoAc";
            this.cMontoAc.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_simulacion);
            this.panel1.Location = new System.Drawing.Point(16, 319);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1198, 239);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_automovil);
            this.panel2.Location = new System.Drawing.Point(16, 579);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(606, 208);
            this.panel2.TabIndex = 0;
            // 
            // dgv_automovil
            // 
            this.dgv_automovil.AllowUserToAddRows = false;
            this.dgv_automovil.AllowUserToDeleteRows = false;
            this.dgv_automovil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_automovil.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cNroFilaVehiculo});
            this.dgv_automovil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_automovil.Location = new System.Drawing.Point(0, 0);
            this.dgv_automovil.Name = "dgv_automovil";
            this.dgv_automovil.ReadOnly = true;
            this.dgv_automovil.RowHeadersVisible = false;
            this.dgv_automovil.Size = new System.Drawing.Size(606, 208);
            this.dgv_automovil.TabIndex = 10;
            // 
            // cNroFilaVehiculo
            // 
            this.cNroFilaVehiculo.HeaderText = "Nro Fila";
            this.cNroFilaVehiculo.Name = "cNroFilaVehiculo";
            this.cNroFilaVehiculo.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv_cabina);
            this.panel3.Location = new System.Drawing.Point(628, 579);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(586, 208);
            this.panel3.TabIndex = 1;
            // 
            // dgv_cabina
            // 
            this.dgv_cabina.AllowUserToAddRows = false;
            this.dgv_cabina.AllowUserToDeleteRows = false;
            this.dgv_cabina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_cabina.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_cabina.Location = new System.Drawing.Point(0, 0);
            this.dgv_cabina.Name = "dgv_cabina";
            this.dgv_cabina.ReadOnly = true;
            this.dgv_cabina.RowHeadersVisible = false;
            this.dgv_cabina.Size = new System.Drawing.Size(586, 208);
            this.dgv_cabina.TabIndex = 11;
            // 
            // btn_simular
            // 
            this.btn_simular.Location = new System.Drawing.Point(262, 52);
            this.btn_simular.Name = "btn_simular";
            this.btn_simular.Size = new System.Drawing.Size(240, 50);
            this.btn_simular.TabIndex = 11;
            this.btn_simular.Text = "Simular";
            this.btn_simular.UseVisualStyleBackColor = true;
            this.btn_simular.Click += new System.EventHandler(this.Btn_simular_Click);
            // 
            // cMaxCabina
            // 
            this.cMaxCabina.HeaderText = "Max. Cabina";
            this.cMaxCabina.Name = "cMaxCabina";
            this.cMaxCabina.ReadOnly = true;
            // 
            // Simulacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 799);
            this.Controls.Add(this.btn_simular);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgv_costo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgv_categoria);
            this.Controls.Add(this.txt_min);
            this.Controls.Add(this.txt_hs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Simulacion";
            this.Text = "Ejercicio 51 - Cabinas Peajes";
            this.Load += new System.EventHandler(this.Simulacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_categoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_costo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_fin_atencion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_simulacion)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_automovil)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cabina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_hs;
        private System.Windows.Forms.TextBox txt_min;
        private System.Windows.Forms.DataGridView dgv_categoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgv_costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCosto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_fin_atencion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cA;
        private System.Windows.Forms.DataGridViewTextBoxColumn cB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_desviacion_llegada;
        private System.Windows.Forms.TextBox txt_media_llegada;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_simulacion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv_automovil;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgv_cabina;
        private System.Windows.Forms.Button btn_simular;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPr;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDesde;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHasta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNroFilaVehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNroFila;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEvento;
        private System.Windows.Forms.DataGridViewTextBoxColumn cReloj;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRnd_llegada;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTiempoEntreLlegada;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProximoVehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRndCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCategoriaSim;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRnd_Fin;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTiempoEntreFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFinAtencion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNroCabina;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMontoAc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMaxCabina;
    }
}

