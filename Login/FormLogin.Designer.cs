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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(142, 34);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Correo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(132, 120);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 1;
            label2.Text = "Contraseña";
            // 
            // correoTxtBox
            // 
            correoTxtBox.Location = new Point(36, 67);
            correoTxtBox.Name = "correoTxtBox";
            correoTxtBox.Size = new Size(275, 23);
            correoTxtBox.TabIndex = 2;
            // 
            // contraseñaTxtBox
            // 
            contraseñaTxtBox.Location = new Point(36, 167);
            contraseñaTxtBox.Name = "contraseñaTxtBox";
            contraseñaTxtBox.PasswordChar = '*';
            contraseñaTxtBox.Size = new Size(275, 23);
            contraseñaTxtBox.TabIndex = 3;
            contraseñaTxtBox.UseSystemPasswordChar = true;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(111, 236);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(121, 47);
            btnIngresar.TabIndex = 4;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(352, 308);
            Controls.Add(btnIngresar);
            Controls.Add(contraseñaTxtBox);
            Controls.Add(correoTxtBox);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Location = new Point(200, 1200);
            Name = "FormLogin";
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
    }
}