namespace Login
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            correoTxtBox = new TextBox();
            contraseñaTxtBox = new TextBox();
            btnIngresar = new Button();
            label3 = new Label();
            label4 = new Label();
            linkLabel1 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            linkLabel3 = new LinkLabel();
            contraseñaBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(212, 112);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Correo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(202, 196);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 1;
            label2.Text = "Contraseña";
            // 
            // correoTxtBox
            // 
            correoTxtBox.Location = new Point(91, 146);
            correoTxtBox.Name = "correoTxtBox";
            correoTxtBox.Size = new Size(288, 23);
            correoTxtBox.TabIndex = 2;
            // 
            // contraseñaTxtBox
            // 
            contraseñaTxtBox.Location = new Point(91, 234);
            contraseñaTxtBox.Name = "contraseñaTxtBox";
            contraseñaTxtBox.Size = new Size(288, 23);
            contraseñaTxtBox.TabIndex = 3;
            contraseñaTxtBox.UseSystemPasswordChar = true;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(157, 286);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(155, 47);
            btnIngresar.TabIndex = 4;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Tahoma", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(80, 9);
            label3.Name = "label3";
            label3.Size = new Size(314, 33);
            label3.TabIndex = 5;
            label3.Text = "Administracion de heroes";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(175, 75);
            label4.Name = "label4";
            label4.Size = new Size(122, 25);
            label4.TabIndex = 6;
            label4.Text = "Iniciar sesion";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.BackColor = Color.DimGray;
            linkLabel1.Enabled = false;
            linkLabel1.Location = new Point(2, 349);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(141, 15);
            linkLabel1.TabIndex = 7;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "¿Olvidaste tu contraseña?";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.BackColor = SystemColors.ControlDarkDark;
            linkLabel2.Enabled = false;
            linkLabel2.Location = new Point(2, 334);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(117, 15);
            linkLabel2.TabIndex = 8;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "¿Olvidaste tu correo?";
            // 
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.BackColor = Color.DimGray;
            linkLabel3.Enabled = false;
            linkLabel3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            linkLabel3.Location = new Point(322, 337);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(114, 30);
            linkLabel3.TabIndex = 9;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "Registrarse";
            // 
            // contraseñaBtn
            // 
            contraseñaBtn.BackgroundImage = Properties.Resources.showPass2;
            contraseñaBtn.BackgroundImageLayout = ImageLayout.Stretch;
            contraseñaBtn.Location = new Point(385, 234);
            contraseñaBtn.Name = "contraseñaBtn";
            contraseñaBtn.Size = new Size(25, 23);
            contraseñaBtn.TabIndex = 10;
            contraseñaBtn.UseVisualStyleBackColor = true;
            contraseñaBtn.Click += contraseñaBtn_Click;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            BackgroundImage = Properties.Resources.fondologin;
            ClientSize = new Size(448, 373);
            Controls.Add(contraseñaBtn);
            Controls.Add(linkLabel3);
            Controls.Add(linkLabel2);
            Controls.Add(linkLabel1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnIngresar);
            Controls.Add(contraseñaTxtBox);
            Controls.Add(correoTxtBox);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Location = new Point(200, 1200);
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox correoTxtBox;
        private TextBox contraseñaTxtBox;
        private Button btnIngresar;
        private Label label3;
        private Label label4;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel3;
        private Button contraseñaBtn;
    }
}