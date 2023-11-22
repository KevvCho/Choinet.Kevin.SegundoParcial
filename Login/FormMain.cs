using Entidades;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.Json;
using System.Globalization;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Drawing.Text;

namespace Login
{
    public partial class FormMain : Form
    {
        private string nombreUsuario = "";
        private string apellidoUsuario = "";
        private string correoUsuario = "";
        private string perfilUsuario = "";

        private DateTime fechaActual = DateTime.Now;

        ColeccionHeroes<Heroe> coleccion = new ColeccionHeroes<Heroe>();

        AccesoDatos ado = new AccesoDatos();

        private bool ordenAscendente = false;

        /// <summary>
        /// Constructor recibiendo los datos del usuario ingresado para luego guardarse
        /// </summary>
        public FormMain(string nombre, string apellido, string correo, string perfil) : this()
        {
            this.nombreUsuario = nombre;
            this.apellidoUsuario = apellido;
            this.correoUsuario = correo;
            this.perfilUsuario = perfil;
            ActualizarBotones(this.perfilUsuario);
            LogConexion();
            ActualizarConexiones();
            ado.OperacionCompletada += OperacionCompletadaHandler;
            ado.OperacionFallo += OperacionFalloHandler;
            this.statusNombre.Text = this.nombreUsuario;
            this.statusFecha.Text = fechaActual.ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// Se recorre la lista de heroes y se agregan los nombres a la lista
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            this.FormClosing += MainForm_FormClosing;

            if (ConectarBaseDeDatos())
            {
                coleccion = ado.LeerDatosBD();
            }


            lstNombres.Items.Clear();

            foreach (Heroe heroe in coleccion)
            {
                string itemText = $"{heroe.Nombre}";
                lstNombres.Items.Add(itemText);
            }

            lstNombres.SelectedIndexChanged += LstNombres_SelectedIndexChanged;
        }

        private bool closingConfirmed = false;

        /// <summary>
        /// Mensaje de confirmacion a la hora de cerrar el programa
        /// </summary>
        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !closingConfirmed)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas cerrar el programa?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    closingConfirmed = true;
                    Application.Exit();
                }
            }
        }
        /// <summary>
        /// Realiza una actualizacion de los botones de agregar, editar y eliminar dependiendo del perfil
        /// </summary>
        /// <param name="perfil">Perfil asociado al correo</param>
        public void ActualizarBotones(string perfil)
        {

            if (perfil == "supervisor")
            {
                this.btnEliminar.Enabled = false;
            }
            else
            {
                if (perfil == "vendedor")
                {
                    this.btnAgregar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnGuardar.Enabled = false;
                    this.btnCargar.Enabled = false;
                }
                else
                {
                    this.eliminarListaBtn.Enabled = true;
                    this.btnAgregar.Enabled = true;
                    this.btnEditar.Enabled = true;
                    this.btnEliminar.Enabled = true;
                    this.btnGuardar.Enabled = true;
                    this.btnCargar.Enabled = true;
                }
            }

        }
        /// <summary>
        /// Realiza una conexion a la base de datos para comprobar su existencia
        /// </summary>
        /// <returns>Retorna la verificacion del mismo</returns>
        private bool ConectarBaseDeDatos()
        {
            bool rtn = false;

            if (ado.PruebaConexion())
            {
                this.conexionBDTxt.Text = "Conexion a base de datos: (Conectada)";
                rtn = true;
            }
            else
            {
                this.conexionBDTxt.Text = "Conexion a base de datos: (Sin conexion)";
            }

            return rtn;
        }

        /// <summary>
        /// Se escribe un log con los datos del usuario en modo append para guardar el historial
        /// </summary>
        private void LogConexion()
        {


            string nombreArchivo = "../../../../usuarios.log";

            using (StreamWriter writer = new StreamWriter(nombreArchivo, true))
            {
                string logTexto = $"Fecha: {this.fechaActual.ToString("dd/MM/yyyy HH:mm:ss")}" +
                                  $" - Nombre: {this.nombreUsuario}" +
                                  $" - Apellido: {this.apellidoUsuario}" +
                                  $" - Correo: {this.correoUsuario}" +
                                  $" - Perfil: {this.perfilUsuario}";

                writer.WriteLine(logTexto);
            }
        }
        /// <summary>
        /// Se hace referencia al mismo archivo de logs y se separan los datos para ser mostrados en una lista
        /// </summary>
        private void ActualizarConexiones()
        {
            string rutaArchivo = "../../../../usuarios.log";

            lstConexiones.Items.Clear();
            lstConexiones.Columns.Clear();
            lstConexiones.Columns.Add("Nombre");
            lstConexiones.Columns.Add("Perfil");
            lstConexiones.Columns.Add("Ultima vez");

            try
            {
                using (StreamReader reader = new StreamReader(rutaArchivo))
                {
                    string linea;
                    while ((linea = reader.ReadLine()) != null)
                    {
                        string[] campos = linea.Split("-");

                        if (campos.Length >= 4)
                        {
                            string nombre = campos[1].Substring(campos[1].IndexOf(':') + 1).Trim();
                            string perfil = campos[4].Substring(campos[4].IndexOf(':') + 1).Trim();
                            string fechaTexto = campos[0].Substring(campos[0].IndexOf(':') + 1).Trim();

                            DateTime fecha;
                            if (DateTime.TryParse(fechaTexto, out fecha))
                            {
                                ListViewItem item = new ListViewItem(nombre);
                                item.SubItems.Add(perfil);
                                item.SubItems.Add(fecha.ToString("dd/MM/yyyy HH:mm:ss"));

                                lstConexiones.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el archivo de registro: " + ex.Message);
            }
        }
        /// <summary>
        /// Se encarga de cambiar los nombres en el visor si hubo un cambio en la lista y cargar en base de datos
        /// </summary>
        private void ActualizarItems()
        {
            //ConectarABaseDeDatos();
            lstNombres.Items.Clear();
            foreach (Heroe heroe in coleccion)
            {
                lstNombres.Items.Add(heroe.Nombre);
            }
        }

        /// <summary>
        /// Encargado de mostrar la descripcion de cada heroe cuando se selecciona su nombre
        /// </summary>
        private void LstNombres_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (lstNombres.SelectedItem is string heroeSeleccionado)
            {

                if (coleccion.ContieneHeroe(heroeSeleccionado))
                {
                    Heroe heroe = null;
                    foreach (Heroe h in coleccion)
                    {
                        if (h.Nombre == heroeSeleccionado)
                        {
                            heroe = h;
                            break;
                        }
                    }

                    if (coleccion == heroe)
                    {
                        lstAtributos.Items.Clear();
                        lstAtributos.Items.Add($"Poder: {heroe.Poder}");
                        lstAtributos.Items.Add($"Nivel de poder base: {heroe.NivelDePoder}");
                        lstAtributos.Items.Add($"Nivel de poder maximo: {heroe.CalcularPoder()}");

                        if (heroe is Terrestre terrestre)
                        {
                            lstAtributos.Items.Add("Tipo: Terrestre");
                            lstAtributos.Items.Add($"Tiene super fuerza: {terrestre.BooleanoHeroe}");
                            lstAtributos.Items.Add($"Nivel de velocidad: {terrestre.Velocidad}");
                        }
                        else if (heroe is Aereo aereo)
                        {
                            lstAtributos.Items.Add("Tipo: Aereo");
                            lstAtributos.Items.Add($"Velocidad de vuelo: {aereo.Velocidad}");
                            lstAtributos.Items.Add($"Tiene alas: {aereo.BooleanoHeroe}");
                        }
                        else if (heroe is Acuatico acuatico)
                        {
                            lstAtributos.Items.Add("Tipo: Acuatico");
                            lstAtributos.Items.Add($"Velocidad de natacion: {acuatico.Velocidad}");
                            lstAtributos.Items.Add($"Tiene comunicacion marina: {acuatico.BooleanoHeroe}");
                        }

                        string descripcionHeroe = heroe.ToString();
                        descripcionBox.Text = descripcionHeroe;
                    }
                }
            }
        }
        /// <summary>
        /// Se llama a otro form para tomar los datos y luego de ser pasados se crea un nuevo heroe
        /// segun el tipo siempre y cuando no se encuentre ya en la lista.
        /// Se agrega a la coleccion y a la base de datos de forma paralela.
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormElemento elementoForm = new FormElemento();
            elementoForm.ShowDialog();

            if (!string.IsNullOrEmpty(elementoForm.Nombre) && elementoForm.NivelPoder != null)
            {
                string nombre = elementoForm.Nombre;
                EPoderes poderSeleccionado = elementoForm.PoderSeleccionado;
                int nivelPoder = int.Parse(elementoForm.NivelPoder);
                ETipoHeroe tipoSeleccionado = elementoForm.TipoSeleccionado;
                int velocidadSeleccionada = int.Parse(elementoForm.Velocidad);
                bool boleanoSeleccionado = elementoForm.BoolBox;

                Heroe nuevoHeroe = null;

                if (tipoSeleccionado == ETipoHeroe.Acuatico)
                {
                    nuevoHeroe = new Acuatico(velocidadSeleccionada, boleanoSeleccionado, nombre, poderSeleccionado, nivelPoder);
                }
                else if (tipoSeleccionado == ETipoHeroe.Terrestre)
                {
                    nuevoHeroe = new Terrestre(velocidadSeleccionada, boleanoSeleccionado, nombre, poderSeleccionado, nivelPoder);
                }
                else if (tipoSeleccionado == ETipoHeroe.Aereo)
                {
                    nuevoHeroe = new Aereo(velocidadSeleccionada, boleanoSeleccionado, nombre, poderSeleccionado, nivelPoder);
                }

                if (nuevoHeroe != null && coleccion != nuevoHeroe)
                {
                    bool agregadoBD = false;
                    bool agregadoColeccion = false;

                    Task agregarBDTask = Task.Run(() =>
                    {
                        agregadoBD = ado.AgregarHeroeBD(nuevoHeroe);
                    });

                    Task agregarColeccionTask = agregarBDTask.ContinueWith(_ =>
                    {
                        if (agregadoBD)
                        {
                            coleccion += nuevoHeroe;
                            agregadoColeccion = true;
                        }
                    });

                    agregarColeccionTask.ContinueWith(_ =>
                    {
                        if (agregadoColeccion)
                        {
                            ActualizarItems();
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error al agregar el héroe a la lista o a la base de datos", "Error");
                        }
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                }
                else
                {
                    MessageBox.Show("Ese héroe ya se encuentra en la lista", "Error");
                }
            }
        }
        /// <summary>
        /// Se llama al mismo form de agregado pero con los campos ya completos con los datos del heroe.
        /// A partir de la edicion se cambian los datos del heroe seleccionado en la lista.
        /// </summary>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (lstNombres.SelectedItem is string heroeSeleccionado)
            {

                if (coleccion.ContieneHeroe(heroeSeleccionado))
                {
                    Heroe heroe = coleccion.ObtenerHeroe(heroeSeleccionado);


                    FormElemento elementoForm = new FormElemento(heroe);

                    elementoForm.ShowDialog();


                    if (!string.IsNullOrEmpty(elementoForm.Nombre) && elementoForm.NivelPoder != null)
                    {
                        bool rtn = ado.EditarHeroeBD(heroe.Nombre, elementoForm.Nombre, elementoForm.PoderSeleccionado.ToString(), int.Parse(elementoForm.NivelPoder), int.Parse(elementoForm.Velocidad));
                        if (rtn)
                        {
                            MessageBox.Show("Editado!");
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                        heroe.Nombre = elementoForm.Nombre;
                        heroe.Poder = elementoForm.PoderSeleccionado;
                        heroe.NivelDePoder = int.Parse(elementoForm.NivelPoder);
                        int velocidadSeleccionada = int.Parse(elementoForm.Velocidad);


                        if (heroe is Acuatico acuatico)
                        {
                            acuatico.Velocidad = velocidadSeleccionada;
                            acuatico.BooleanoHeroe = elementoForm.BoolBox;
                        }
                        else if (heroe is Terrestre terrestre)
                        {
                            terrestre.Velocidad = velocidadSeleccionada;
                            terrestre.BooleanoHeroe = elementoForm.BoolBox;
                        }
                        else if (heroe is Aereo aereo)
                        {
                            aereo.Velocidad = velocidadSeleccionada;
                            aereo.BooleanoHeroe = elementoForm.BoolBox;
                        }

                        lstNombres.Items[lstNombres.SelectedIndex] = heroe.Nombre;
                        ActualizarItems();
                    }
                }
            }
        }
        /// <summary>
        /// Elimina el heroe seleccionado en la lista de nombres de la coleccion de heroes
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Heroe heroeSeleccionado = coleccion.ObtenerHeroe((string)lstNombres.SelectedItem);

            if (heroeSeleccionado != null)
            {
                if (coleccion.ContieneHeroe(heroeSeleccionado))
                {
                    if (ado.EliminarHeroeBD(heroeSeleccionado.Nombre, heroeSeleccionado.Poder.ToString(), heroeSeleccionado.NivelDePoder))
                    {
                        coleccion -= heroeSeleccionado;
                        ActualizarItems();
                        MessageBox.Show("Héroe eliminado");
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar de la base de datos");
                    }
                }
                else
                {
                    MessageBox.Show("Error al eliminar el héroe de la lista");
                }
            }
            else
            {
                MessageBox.Show("No hay elementos para eliminar.");
            }

        }
        /// <summary>
        /// Obtiene un .json con datos de heroe previamente serializados para deserializar y guardar
        /// en una nueva lista que se carga en el programa
        /// </summary>
        private void btnCargar_Click(object sender, EventArgs e)
        {
            ColeccionHeroes<Heroe> coleccion = new ColeccionHeroes<Heroe>();

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Archivos JSON (*.json)|*.json";
                dialog.Title = "Cargar archivo JSON";
                dialog.InitialDirectory = "../../../../";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string path = dialog.FileName;

                    try
                    {
                        string jsonString = Task.Run(() => File.ReadAllText(path)).Result;

                        List<Dictionary<string, object>> heroesData = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(jsonString);

                        foreach (var heroeData in heroesData)
                        {
                            string tipo = heroeData["Tipo"].ToString();
                            string nombre = heroeData["Nombre"].ToString();
                            string poder = heroeData["Poder"].ToString();
                            int nivelDePoder = int.Parse(heroeData["NivelDePoder"].ToString());
                            EPoderes poderEnum = (EPoderes)Enum.Parse(typeof(EPoderes), poder, ignoreCase: true);

                            Heroe nuevoHeroe = null;

                            if (tipo == "Acuatico")
                            {
                                int velocidadNatacion = 0;
                                bool comunicacionMarina = false;

                                if (heroeData.ContainsKey("VelocidadNatacion"))
                                {
                                    velocidadNatacion = int.Parse(heroeData["VelocidadNatacion"].ToString());
                                }

                                if (heroeData.ContainsKey("ComunicacionMarina"))
                                {
                                    comunicacionMarina = bool.Parse(heroeData["ComunicacionMarina"].ToString());
                                }

                                nuevoHeroe = new Acuatico(velocidadNatacion, comunicacionMarina, nombre, poderEnum, nivelDePoder);
                            }
                            else if (tipo == "Aereo")
                            {
                                int velocidadVuelo = 0;
                                bool alas = false;

                                if (heroeData.ContainsKey("VelocidadVuelo"))
                                {
                                    velocidadVuelo = int.Parse(heroeData["VelocidadVuelo"].ToString());
                                }

                                if (heroeData.ContainsKey("Alas"))
                                {
                                    alas = bool.Parse(heroeData["Alas"].ToString());
                                }

                                nuevoHeroe = new Aereo(velocidadVuelo, alas, nombre, poderEnum, nivelDePoder);
                            }
                            else if (tipo == "Terrestre")
                            {
                                int velocidad = 0;
                                bool superFuerza = false;

                                if (heroeData.ContainsKey("Velocidad"))
                                {
                                    velocidad = int.Parse(heroeData["Velocidad"].ToString());
                                }

                                if (heroeData.ContainsKey("SuperFuerza"))
                                {
                                    superFuerza = bool.Parse(heroeData["SuperFuerza"].ToString());
                                }

                                nuevoHeroe = new Terrestre(velocidad, superFuerza, nombre, poderEnum, nivelDePoder);
                            }

                            if (nuevoHeroe != null)
                            {
                                coleccion.AgregarHeroe(nuevoHeroe);
                            }
                        }
                        ado.BorrarDatosTabla();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar los datos desde el archivo JSON: " + ex.Message);
                    }
                }
            }

            ado.AgregarColeccion(coleccion);
            this.coleccion = coleccion;
            ActualizarItems();
        }

        private void OperacionCompletadaHandler(object sender, EventArgs e)
        {
            MessageBox.Show("La operación se ha completado.", "Exito");
        }

        private void OperacionFalloHandler(object sender, EventArgs e)
        {
            MessageBox.Show("Ocurrio un error en la operación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Se serializa un json con los datos de la lista actual de heroes
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            JsonSerializerOptions opciones = new JsonSerializerOptions();
            opciones.WriteIndented = true;

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "Archivos JSON (*.json)|*.json";
                dialog.Title = "Guardar archivo JSON";
                dialog.InitialDirectory = "../../../../";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string path = dialog.FileName;

                    try
                    {
                        using (StreamWriter sw = new StreamWriter(path))
                        {
                            List<Dictionary<string, object>> heroesData = new List<Dictionary<string, object>>();

                            foreach (var heroe in coleccion)
                            {
                                var heroeData = new Dictionary<string, object>
                                {

                                { "Tipo", heroe.GetType().Name }

                                };

                                var heroeProperties = heroe.GetType().GetProperties();
                                foreach (var property in heroeProperties)
                                {
                                    var value = property.GetValue(heroe);
                                    heroeData.Add(property.Name, value);
                                }

                                heroesData.Add(heroeData);
                            }

                            string json = JsonSerializer.Serialize(heroesData, opciones);
                            sw.WriteLine(json);
                        }

                        MessageBox.Show("Archivo guardado exitosamente.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar el archivo: " + ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Ordena los elementos de la lista por nombre alfabeticamente.
        /// Si se presiona una segunda vez cambia el orden por ascendente o descendente.
        /// </summary>
        private void nombreOrdenar_Click(object sender, EventArgs e)
        {
            this.coleccion = coleccion.OrdenarPorNombre(this.ordenAscendente);
            ActualizarItems();

            if (this.ordenAscendente)
            {
                this.ordenAscendente = false;
            }
            else
            {
                this.ordenAscendente = true;
            }
        }
        /// <summary>
        /// Ordena los elementos de la lista por nivel de poder base.
        /// Si se presiona una segunda vez cambia el orden por ascendente o descendente.
        /// </summary>
        private void nivelDePoderOrdenar_Click(object sender, EventArgs e)
        {
            this.coleccion = coleccion.OrdenarPorNivelDePoder(this.ordenAscendente);
            ActualizarItems();

            if (this.ordenAscendente)
            {
                this.ordenAscendente = false;
            }
            else
            {
                this.ordenAscendente = true;
            }
        }
        /// <summary>
        /// Boton para eliminar la coleccion y datos en la base de datos
        /// </summary>
        private void eliminarListaBtn_Click(object sender, EventArgs e)
        {
            ColeccionHeroes<Heroe> coleccion = new ColeccionHeroes<Heroe>();
            this.coleccion = coleccion;
            ActualizarItems();
            MessageBox.Show($"{ado.BorrarDatosTabla()}");
        }
    }
}
