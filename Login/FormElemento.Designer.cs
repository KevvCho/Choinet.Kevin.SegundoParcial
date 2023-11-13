namespace Login
{
    partial class FormElemento
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
            label1 = new Label();
            txtNombre = new TextBox();
            boxPoder = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            txtNivelPoder = new TextBox();
            label4 = new Label();
            boxTipo = new ComboBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            velocLbl = new Label();
            boolBl = new Label();
            boolBx = new ComboBox();
            velTxt = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 18);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(25, 36);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(215, 23);
            txtNombre.TabIndex = 1;
            // 
            // boxPoder
            // 
            boxPoder.FormattingEnabled = true;
            boxPoder.Location = new Point(25, 92);
            boxPoder.Name = "boxPoder";
            boxPoder.Size = new Size(215, 23);
            boxPoder.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 74);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 3;
            label2.Text = "Poder";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 130);
            label3.Name = "label3";
            label3.Size = new Size(111, 15);
            label3.TabIndex = 4;
            label3.Text = "Nivel de poder base";
            // 
            // txtNivelPoder
            // 
            txtNivelPoder.Location = new Point(25, 148);
            txtNivelPoder.Name = "txtNivelPoder";
            txtNivelPoder.Size = new Size(214, 23);
            txtNivelPoder.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(318, 18);
            label4.Name = "label4";
            label4.Size = new Size(30, 15);
            label4.TabIndex = 6;
            label4.Text = "Tipo";
            // 
            // boxTipo
            // 
            boxTipo.FormattingEnabled = true;
            boxTipo.Location = new Point(318, 36);
            boxTipo.Name = "boxTipo";
            boxTipo.Size = new Size(214, 23);
            boxTipo.TabIndex = 7;
            boxTipo.SelectedIndexChanged += BoxTipo_SelectedIndexChanged;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(148, 194);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(103, 34);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(306, 194);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(103, 34);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // velocLbl
            // 
            velocLbl.AutoSize = true;
            velocLbl.Location = new Point(319, 74);
            velocLbl.Name = "velocLbl";
            velocLbl.Size = new Size(60, 15);
            velocLbl.TabIndex = 10;
            velocLbl.Text = "Atributo 1";
            // 
            // boolBl
            // 
            boolBl.AutoSize = true;
            boolBl.Location = new Point(318, 130);
            boolBl.Name = "boolBl";
            boolBl.Size = new Size(60, 15);
            boolBl.TabIndex = 11;
            boolBl.Text = "Atributo 2";
            // 
            // boolBx
            // 
            boolBx.FormattingEnabled = true;
            boolBx.Items.AddRange(new object[] { "Falso", "Verdadero" });
            boolBx.Location = new Point(319, 148);
            boolBx.Name = "boolBx";
            boolBx.Size = new Size(213, 23);
            boolBx.TabIndex = 12;
            // 
            // velTxt
            // 
            velTxt.Location = new Point(319, 92);
            velTxt.Name = "velTxt";
            velTxt.Size = new Size(214, 23);
            velTxt.TabIndex = 13;
            // 
            // FormElemento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(562, 240);
            Controls.Add(velTxt);
            Controls.Add(boolBx);
            Controls.Add(boolBl);
            Controls.Add(velocLbl);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(boxTipo);
            Controls.Add(label4);
            Controls.Add(txtNivelPoder);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(boxPoder);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormElemento";
            Text = "Elemento";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombre;
        private ComboBox boxPoder;
        private Label label2;
        private Label label3;
        private TextBox txtNivelPoder;
        private Label label4;
        private ComboBox boxTipo;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label velocLbl;
        private Label boolBl;
        private ComboBox boolBx;
        private TextBox velTxt;
    }
}