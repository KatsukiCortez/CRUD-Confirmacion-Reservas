using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace reservaTour.conexion
{
    public partial class AgregarTour1 : Page
    {
        // Cadena de conexión a tu base de datos SQL Server
        string connectionString = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTours();
                CargarClientes();

             
            }
        }

        protected void btnAgregarTour_Click(object sender, EventArgs e)
        {
            // Obtener los valores ingresados por el usuario
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            decimal precio = decimal.Parse(txtPrecio.Text);

            // Crear la consulta SQL para insertar el nuevo tour
            string query = "INSERT INTO Tours (nombre, descripcion, precio) VALUES (@Nombre, @Descripcion, @Precio)";

            // Crear y abrir una nueva conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear un comando SQL para ejecutar la consulta
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agregar parámetros a la consulta SQL
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Descripcion", descripcion);
                    command.Parameters.AddWithValue("@Precio", precio);

                    try
                    {
                        // Abrir la conexión a la base de datos
                        connection.Open();
                        // Ejecutar la consulta SQL para insertar el nuevo tour
                        int rowsAffected = command.ExecuteNonQuery();
                        // Comprobar si se insertó correctamente
                        if (rowsAffected > 0)
                        {
                            // Si se insertó correctamente, mostrar un mensaje de éxito
                            lblMensaje.Text = "El tour se agregó correctamente.";
                            // Limpiar los campos del formulario
                            LimpiarCampos();
                            // Actualizar el GridView con los nuevos datos
                            CargarTours(); // Aquí llamamos al método para cargar los tours en el GridView
                        }
                        else
                        {
                            // Si no se insertó correctamente, mostrar un mensaje de error
                            lblMensaje.Text = "Error al agregar el tour.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Si se produce algún error durante la ejecución de la consulta, mostrar un mensaje de error
                        lblMensaje.Text = "Error: " + ex.Message;
                    }
                }
            }
        }

        // Método para limpiar los campos del formulario después de agregar un nuevo tour
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
        }

        // Método para cargar los tours en el GridView
        private void CargarTours()
        {
            // Crear una lista para almacenar los tours
            List<Tour> tours = new List<Tour>();

            // Consulta SQL para obtener todos los tours de la base de datos
            string query = "SELECT nombre, descripcion, precio FROM Tours";

            // Crear y abrir una nueva conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear un comando SQL para ejecutar la consulta
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Abrir la conexión a la base de datos
                    connection.Open();
                    // Ejecutar la consulta SQL y obtener los datos
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Recorrer los resultados y agregarlos a la lista de tours
                        while (reader.Read())
                        {
                            string nombreTour = reader.GetString(0);
                            string descripcionTour = reader.GetString(1);
                            decimal precioTour = reader.GetDecimal(2);
                            tours.Add(new Tour { Nombre = nombreTour, Descripcion = descripcionTour, Precio = precioTour });
                        }
                    }
                }
            }

            // Asignar la lista de tours al GridView
            GridViewTours.DataSource = tours;
            GridViewTours.DataBind();
        }
        private void CargarClientes()
        {
            // Crear una lista para almacenar los clientes
            List<Cliente> clientes = new List<Cliente>();

            // Consulta SQL para obtener todos los clientes de la base de datos
            string query = "SELECT id_cliente, nombre, email, telefono FROM Clientes";

            // Crear y abrir una nueva conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear un comando SQL para ejecutar la consulta
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Abrir la conexión a la base de datos
                    connection.Open();
                    // Ejecutar la consulta SQL y obtener los datos
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Recorrer los resultados y agregarlos a la lista de clientes
                        while (reader.Read())
                        {
                            string idCliente = reader.GetString(0);
                            string nombre = reader.GetString(1);
                            string email = reader.GetString(2);
                            string telefono = reader.GetString(3);
                            clientes.Add(new Cliente { IdCliente = idCliente, Nombre = nombre, Email = email, Telefono = telefono });
                        }
                    }
                }
            }

            // Asignar la lista de clientes al GridView
            GridViewClientes.DataSource = clientes;
            GridViewClientes.DataBind();
        }

        protected void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            // Obtener los valores ingresados por el usuario
            string idCliente = txtIdCliente.Text;
            string nombreCliente = txtNombreCliente.Text;
            string email = txtEmail.Text;
            string telefono = txtTelefono.Text;

            // Crear la consulta SQL para insertar el nuevo cliente
            string query = "INSERT INTO Clientes (id_cliente, nombre, email, telefono) VALUES (@IdCliente, @NombreCliente, @Email, @Telefono)";

            // Crear y abrir una nueva conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear un comando SQL para ejecutar la consulta
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agregar parámetros a la consulta SQL
                    command.Parameters.AddWithValue("@IdCliente", idCliente);
                    command.Parameters.AddWithValue("@NombreCliente", nombreCliente);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Telefono", telefono);

                    try
                    {
                        // Abrir la conexión a la base de datos
                        connection.Open();
                        // Ejecutar la consulta SQL para insertar el nuevo cliente
                        int rowsAffected = command.ExecuteNonQuery();
                        // Comprobar si se insertó correctamente
                        if (rowsAffected > 0)
                        {
                            // Si se insertó correctamente, mostrar un mensaje de éxito
                            lblMensajeCliente.Text = "El cliente se agregó correctamente.";
                            // Limpiar los campos del formulario
                            // Actualizar el GridView con los nuevos datos
                            CargarClientes();
                        }
                        else
                        {
                            // Si no se insertó correctamente, mostrar un mensaje de error
                            lblMensajeCliente.Text = "Error al agregar el cliente.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Si se produce algún error durante la ejecución de la consulta, mostrar un mensaje de error
                        lblMensajeCliente.Text = "Error: " + ex.Message;
                    }
                }
            }
        }


        protected void btnAgregarReserva_Click1(object sender, EventArgs e)
        {
            // Obtener los valores ingresados por el usuario
            string tourSeleccionado = ddlTours.SelectedValue;
            string clienteSeleccionado = ddlClientes.SelectedValue;
            int cantidadPersonas = int.Parse(txtCantidadPersonas.Text);

            // Crear la consulta SQL para insertar la nueva reserva
            string query = "INSERT INTO Reservas (tour, cliente, fecha_reserva, cantidad_personas) VALUES (@Tour, @Cliente, @FechaReserva, @CantidadPersonas)";

            // Crear y abrir una nueva conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear un comando SQL para ejecutar la consulta
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agregar parámetros a la consulta SQL
                    command.Parameters.AddWithValue("@Tour", tourSeleccionado);
                    command.Parameters.AddWithValue("@Cliente", clienteSeleccionado);
                    command.Parameters.AddWithValue("@FechaReserva", DateTime.Now); // Fecha actual
                    command.Parameters.AddWithValue("@CantidadPersonas", cantidadPersonas);

                    try
                    {
                        // Abrir la conexión a la base de datos
                        connection.Open();
                        // Ejecutar la consulta SQL para insertar la nueva reserva
                        int rowsAffected = command.ExecuteNonQuery();
                        // Comprobar si se insertó correctamente
                        if (rowsAffected > 0)
                        {
                            // Si se insertó correctamente, mostrar un mensaje de éxito
                            lblMensajeReserva.Text = "La reserva se agregó correctamente.";
                            // Limpiar los campos del formulario
                            txtCantidadPersonas.Text = "";
                        }
                        else
                        {
                            // Si no se insertó correctamente, mostrar un mensaje de error
                            lblMensajeReserva.Text = "Error al agregar la reserva.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Si se produce algún error durante la ejecución de la consulta, mostrar un mensaje de error
                        lblMensajeReserva.Text = "Error: " + ex.Message;
                    }
                }
            }
        }
    }

    // Clase para representar un tour
    public class Tour
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
    }
    public class Cliente
    {
        public string IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }
}
