namespace Login
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            descripcionBox = new RichTextBox();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            statusNombre = new ToolStripStatusLabel();
            statusFecha = new ToolStripStatusLabel();
            statusStrip1 = new StatusStrip();
            statusConectado = new ToolStripStatusLabel();
            conexionBDTxt = new ToolStripStatusLabel();
            label1 = new Label();
            toolStrip1 = new ToolStrip();
            btnCargar = new ToolStripButton();
            btnGuardar = new ToolStripButton();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            nombreOrdenar = new ToolStripMenuItem();
            nivelDePoderOrdenar = new ToolStripMenuItem();
            eliminarListaBtn = new ToolStripButton();
            lstConexiones = new ListView();
            label2 = new Label();
            lstNombres = new ListBox();
            label3 = new Label();
            lstAtributos = new ListBox();
            label4 = new Label();
            statusStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // descripcionBox
            // 
            descripcionBox.BackColor = SystemColors.ControlLight;
            descripcionBox.Location = new Point(512, 51);
            descripcionBox.Name = "descripcionBox";
            descripcionBox.ReadOnly = true;
            descripcionBox.Size = new Size(276, 116);
            descripcionBox.TabIndex = 1;
            descripcionBox.Text = "";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(357, 51);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(129, 46);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(357, 121);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(129, 46);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(357, 194);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(129, 46);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // statusNombre
            // 
            statusNombre.Name = "statusNombre";
            statusNombre.Size = new Size(51, 17);
            statusNombre.Text = "Nombre";
            // 
            // statusFecha
            // 
            statusFecha.Name = "statusFecha";
            statusFecha.Size = new Size(38, 17);
            statusFecha.Text = "Fecha";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusNombre, statusConectado, statusFecha, conexionBDTxt });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusConectado
            // 
            statusConectado.Name = "statusConectado";
            statusConectado.Size = new Size(73, 17);
            statusConectado.Text = "(Conectado)";
            // 
            // conexionBDTxt
            // 
            conexionBDTxt.Margin = new Padding(350, 3, 0, 2);
            conexionBDTxt.Name = "conexionBDTxt";
            conexionBDTxt.Size = new Size(73, 17);
            conexionBDTxt.Text = "ConexionBD";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(512, 33);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 6;
            label1.Text = "Descripcion";
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnCargar, btnGuardar, toolStripDropDownButton1, eliminarListaBtn });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 7;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnCargar
            // 
            btnCargar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnCargar.Image = (Image)resources.GetObject("btnCargar.Image");
            btnCargar.ImageTransparentColor = Color.Magenta;
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(46, 22);
            btnCargar.Text = "Cargar";
            btnCargar.Click += btnCargar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnGuardar.Image = (Image)resources.GetObject("btnGuardar.Image");
            btnGuardar.ImageTransparentColor = Color.Magenta;
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(96, 22);
            btnGuardar.Text = "Guardar como...";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { nombreOrdenar, nivelDePoderOrdenar });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(84, 22);
            toolStripDropDownButton1.Text = "Ordenar por";
            // 
            // nombreOrdenar
            // 
            nombreOrdenar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            nombreOrdenar.Name = "nombreOrdenar";
            nombreOrdenar.Size = new Size(178, 22);
            nombreOrdenar.Text = "Nombre";
            nombreOrdenar.Click += nombreOrdenar_Click;
            // 
            // nivelDePoderOrdenar
            // 
            nivelDePoderOrdenar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            nivelDePoderOrdenar.Name = "nivelDePoderOrdenar";
            nivelDePoderOrdenar.Size = new Size(178, 22);
            nivelDePoderOrdenar.Text = "Nivel de poder base";
            nivelDePoderOrdenar.Click += nivelDePoderOrdenar_Click;
            // 
            // eliminarListaBtn
            // 
            eliminarListaBtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            eliminarListaBtn.Enabled = false;
            eliminarListaBtn.Image = (Image)resources.GetObject("eliminarListaBtn.Image");
            eliminarListaBtn.ImageTransparentColor = Color.Magenta;
            eliminarListaBtn.Name = "eliminarListaBtn";
            eliminarListaBtn.Size = new Size(78, 22);
            eliminarListaBtn.Text = "Eliminar lista";
            eliminarListaBtn.Click += eliminarListaBtn_Click;
            // 
            // lstConexiones
            // 
            lstConexiones.BackColor = Color.LightGray;
            lstConexiones.Location = new Point(357, 326);
            lstConexiones.Name = "lstConexiones";
            lstConexiones.Size = new Size(430, 89);
            lstConexiones.TabIndex = 8;
            lstConexiones.UseCompatibleStateImageBehavior = false;
            lstConexiones.View = View.Details;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(357, 308);
            label2.Name = "label2";
            label2.Size = new Size(110, 15);
            label2.TabIndex = 9;
            label2.Text = "Ultimas conexiones";
            // 
            // lstNombres
            // 
            lstNombres.BackColor = Color.Silver;
            lstNombres.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lstNombres.FormattingEnabled = true;
            lstNombres.ItemHeight = 30;
            lstNombres.Location = new Point(23, 51);
            lstNombres.Name = "lstNombres";
            lstNombres.Size = new Size(297, 364);
            lstNombres.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(512, 194);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 11;
            label3.Text = "Atributos";
            // 
            // lstAtributos
            // 
            lstAtributos.BackColor = Color.LightGray;
            lstAtributos.FormattingEnabled = true;
            lstAtributos.ItemHeight = 15;
            lstAtributos.Location = new Point(512, 212);
            lstAtributos.Name = "lstAtributos";
            lstAtributos.SelectionMode = SelectionMode.None;
            lstAtributos.Size = new Size(275, 94);
            lstAtributos.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(23, 33);
            label4.Name = "label4";
            label4.Size = new Size(85, 15);
            label4.TabIndex = 13;
            label4.Text = "Lista de heroes";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.mainbg1;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(lstAtributos);
            Controls.Add(label3);
            Controls.Add(lstNombres);
            Controls.Add(label2);
            Controls.Add(lstConexiones);
            Controls.Add(toolStrip1);
            Controls.Add(label1);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(descripcionBox);
            Controls.Add(statusStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Location = new Point(200, 1200);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administracion de heroes";
            FormClosing += MainForm_FormClosing;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RichTextBox descripcionBox;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private ToolStripStatusLabel statusNombre;
        private ToolStripStatusLabel statusFecha;
        private StatusStrip statusStrip1;
        private Label label1;
        private ToolStrip toolStrip1;
        private ToolStripButton btnGuardar;
        private ToolStripButton btnCargar;
        private ListView lstConexiones;
        private Label label2;
        private ListBox lstNombres;
        private Label label3;
        private ListBox lstAtributos;
        private ToolStripStatusLabel statusConectado;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem nombreOrdenar;
        private ToolStripMenuItem nivelDePoderOrdenar;
        private ToolStripStatusLabel conexionBDTxt;
        private ToolStripButton eliminarListaBtn;
        private Label label4;
    }
}