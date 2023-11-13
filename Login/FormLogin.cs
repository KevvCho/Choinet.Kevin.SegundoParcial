using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Login
{

    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Obtiene un .json con datos de usuario y clave los cuales deserializa en una lista
        /// luego y comprueba si los datos ingresados coinciden con el archivo iterando por los usuarios
        /// </summary>
        private void btnIngresar_Click(object sender, EventArgs e)
        {

            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../../MOCK_DATA.json");

            try
            {
                string jsonContent = File.ReadAllText(jsonFilePath);

                List<Usuario> usuarios = new List<Usuario>();

                usuarios = JsonSerializer.Deserialize<List<Usuario>>(jsonContent);

                string correoIngresado = correoTxtBox.Text;
                string contraseñaIngresada = contraseñaTxtBox.Text;

                bool loginCorrecto = false;

                foreach (Usuario usuario in usuarios)
                {
                    if (usuario.Correo == correoIngresado && usuario.Clave == contraseñaIngresada)
                    {
                        loginCorrecto = true;
                        MessageBox.Show("Bienvenido!");
                        FormMain mainForm = new FormMain(usuario.Nombre, usuario.Apellido, usuario.Correo, usuario.Perfil);
                        mainForm.Show();
                        this.Hide();
                        break;
                    }

                }
                    if (!loginCorrecto)
                    {
                        MessageBox.Show("Login incorrecto");
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el archivo JSON: " + ex.Message);
            }



        }
    }


}