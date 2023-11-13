using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Login
{
    public partial class FormElemento : Form
    {
        /// <summary>
        /// Constructor del form con datos de cada textbox completo para editar
        /// </summary>
        /// <param name="heroeEditar">Recibe todos los datos del heroe a editar</param>
        public FormElemento(Heroe heroeEditar) : this()
        {
            this.txtNombre.Text = heroeEditar.Nombre;
            this.boxPoder.SelectedItem = heroeEditar.Poder;
            this.txtNivelPoder.Text = heroeEditar.NivelDePoder.ToString();
            this.boxTipo.Enabled = false;

            if (heroeEditar is Terrestre terrestre)
            {
                this.boxTipo.SelectedItem = ETipoHeroe.Terrestre.ToString();
                this.velTxt.Text = terrestre.Velocidad.ToString();
                this.boolBx.SelectedIndex = terrestre.SuperFuerza ? 1 : 0;
            }
            else if (heroeEditar is Aereo aereo)
            {
                this.boxTipo.SelectedItem = ETipoHeroe.Aereo.ToString();
                this.velTxt.Text = aereo.VelocidadVuelo.ToString();
                this.boolBx.SelectedIndex = aereo.Alas ? 1 : 0;
            }
            else if (heroeEditar is Acuatico acuatico)
            {
                this.boxTipo.SelectedItem = ETipoHeroe.Acuatico.ToString();
                this.velTxt.Text = acuatico.VelocidadNatacion.ToString();
                this.boolBx.SelectedIndex = acuatico.ComunicacionMarina ? 1 : 0;
            }
        }
        /// <summary>
        /// Inicializa los comboBox de tipo y poderes con sus respectivos items
        /// </summary>
        public FormElemento()
        {
            InitializeComponent();
            foreach (EPoderes poder in Enum.GetValues(typeof(EPoderes)))
            {
                boxPoder.Items.Add(poder);
            }
            boxPoder.SelectedIndex = 0;

            foreach (ETipoHeroe tipo in Enum.GetValues(typeof(ETipoHeroe)))
            {
                boxTipo.Items.Add(tipo);
            }
            boxTipo.Items.Insert(0, "Seleccione");
            boxTipo.SelectedIndex = 0;
        }

        private string nombre;
        private EPoderes poderSeleccionado;
        private string nivelPoder;
        private ETipoHeroe tipoSeleccionado;
        private string velocidad;
        private bool boolBox;


        public string Nombre => nombre;
        public EPoderes PoderSeleccionado => poderSeleccionado;
        public string NivelPoder => nivelPoder;
        public ETipoHeroe TipoSeleccionado => tipoSeleccionado;
        public string Velocidad => velocidad;
        public bool BoolBox => boolBox;

        /// <summary>
        /// Luego de hacer comprobaciones para saber si se completaron los campos
        /// se asignan los datos a variables para luego ser usadas en el form principal
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNivelPoder.Text))
            {
                MessageBox.Show("Debes completar todos los campos.");
            }
            else if (!int.TryParse(txtNivelPoder.Text, out _) || !int.TryParse(velTxt.Text, out _))
            {
                MessageBox.Show("No se admite texto en campos de numeros.");
            }
            else
            {
                this.nombre = txtNombre.Text;
                try
                {
                    this.poderSeleccionado = (EPoderes)boxPoder.SelectedItem;
                }
                catch
                {
                    this.poderSeleccionado = EPoderes.Telepatia;
                }

                this.nivelPoder = txtNivelPoder.Text;
                try
                {
                    string tipoSeleccionadoStr = boxTipo.SelectedItem.ToString();
                    if (Enum.TryParse(tipoSeleccionadoStr, out ETipoHeroe tipoSeleccionado))
                    {
                        this.tipoSeleccionado = tipoSeleccionado;
                    }
                }
                catch
                {
                    this.tipoSeleccionado = ETipoHeroe.Acuatico;
                }

                this.velocidad = velTxt.Text;

                if (velTxt.Text == "")
                {
                    this.velocidad = "0";
                }

                if (boolBx.SelectedItem != null)
                {
                    if (boolBx.SelectedItem.ToString() == "Verdadero")
                    {
                        this.boolBox = true;
                    }
                    else if (boolBx.SelectedItem.ToString() == "Falso")
                    {
                        this.boolBox = false;
                    }
                }
                else
                {
                    this.boolBox = false;
                }

                this.Close();
            }



        }
        /// <summary>
        /// Realiza un cambio de texto dependiendo del tipo de heroe elegido
        /// En caso de no haber ningun tipo elegido oculta los campos.
        /// </summary>
        private void BoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoSeleccionado = boxTipo.SelectedItem.ToString();

            if (tipoSeleccionado == "Acuatico")
            {
                velocLbl.Text = "Velocidad de natacion";
                boolBl.Text = "Tiene comunicacion marina";
            }
            else if (tipoSeleccionado == "Terrestre")
            {
                velocLbl.Text = "Velocidad";
                boolBl.Text = "Tiene super fuerza";
            }
            else if (tipoSeleccionado == "Aereo")
            {
                velocLbl.Text = "Velocidad de vuelo";
                boolBl.Text = "Tiene alas";
            }


            if (tipoSeleccionado != "Aereo" && tipoSeleccionado != "Terrestre" && tipoSeleccionado != "Acuatico")
            {
                velocLbl.Visible = false;
                velTxt.Visible = false;
                boolBl.Visible = false;
                boolBx.Visible = false;
            }
            else
            {
                velocLbl.Visible = true;
                velTxt.Visible = true;
                boolBl.Visible = true;
                boolBx.Visible = true;
                boolBx.SelectedIndex = 0;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
