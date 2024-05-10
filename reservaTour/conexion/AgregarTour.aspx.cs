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
                CargarReservas();
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
            // Consulta SQL para obtener todos los tours de la base de datos
            string query = "SELECT nombre, descripcion, precio FROM Tours";

            // Crear una lista para almacenar los tours
            List<Tour> tours = new List<Tour>();

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

            // Asignar la lista de tours al DropDownList ddlTours
            ddlTours.DataSource = tours;
            ddlTours.DataTextField = "Nombre"; // Establecer el campo a mostrar en el DropDownList
            ddlTours.DataValueField = "Nombre"; // Establecer el campo como valor seleccionado
            ddlTours.DataBind();

            // Asignar la lista de tours al GridView
            GridViewTours.DataSource = tours;
            GridViewTours.DataBind();
        }
        private void CargarClientes()
        {
            // Consulta SQL para obtener todos los clientes de la base de datos
            string query = "SELECT id_cliente, nombre, email, telefono FROM Clientes";

            // Crear una lista para almacenar los clientes
            List<Cliente> clientes = new List<Cliente>();

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

            // Asignar la lista de clientes al DropDownList ddlClientes
            ddlClientes.DataSource = clientes;
            ddlClientes.DataTextField = "Nombre"; // Establecer el campo a mostrar en el DropDownList
            ddlClientes.DataValueField = "IdCliente"; // Establecer el campo como valor seleccionado
            ddlClientes.DataBind();

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
            int cantidadPersonas;

            if (!int.TryParse(txtCantidadPersonas.Text, out cantidadPersonas))
            {
                lblMensajeReserva.Text = "La cantidad de personas debe ser un número entero.";
                return;
            }

            // Crear la consulta SQL para insertar la nueva reserva
            string queryReserva = "INSERT INTO Reservas (tour, cliente, fecha_reserva, cantidad_personas) OUTPUT INSERTED.id_reserva VALUES (@Tour, @Cliente, @FechaReserva, @CantidadPersonas)";

            // Crear la consulta SQL para insertar el nuevo pago asociado a la reserva
            string queryPago = "INSERT INTO Pagos (reserva_id, monto, fecha_pago) VALUES (@ReservaId, @Monto, @FechaPago)";

            // Crear y abrir una nueva conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Iniciar una transacción para asegurar la integridad de los datos
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int reservaId;
                        // Insertar la reserva
                        using (SqlCommand commandReserva = new SqlCommand(queryReserva, connection, transaction))
                        {
                            commandReserva.Parameters.AddWithValue("@Tour", tourSeleccionado);
                            commandReserva.Parameters.AddWithValue("@Cliente", clienteSeleccionado);
                            commandReserva.Parameters.AddWithValue("@FechaReserva", DateTime.Now); // Fecha actual
                            commandReserva.Parameters.AddWithValue("@CantidadPersonas", cantidadPersonas);
                            reservaId = (int)commandReserva.ExecuteScalar(); // Obtener el ID de la reserva insertada
                        }

                        // Insertar el pago asociado a la reserva
                        using (SqlCommand commandPago = new SqlCommand(queryPago, connection, transaction))
                        {
                            commandPago.Parameters.AddWithValue("@ReservaId", reservaId); // Asociar el pago a la reserva
                                                                                          // Aquí debes proporcionar el monto del pago, por ejemplo:
                            commandPago.Parameters.AddWithValue("@Monto", 100); // Ejemplo: monto fijo de $100
                            commandPago.Parameters.AddWithValue("@FechaPago", DateTime.Now); // Fecha actual
                            commandPago.ExecuteNonQuery(); // Insertar el pago
                        }

                        // Si llegamos aquí sin lanzar una excepción, confirmamos la transacción
                        transaction.Commit();
                        lblMensajeReserva.Text = "La reserva y el pago se agregaron correctamente.";
                        txtCantidadPersonas.Text = ""; // Limpiar los campos del formulario
                    }
                    catch (Exception ex)
                    {
                        // Si se produce algún error durante la ejecución de la consulta, hacemos un rollback de la transacción
                        transaction.Rollback();

                        // Generar el script JavaScript para mostrar una alerta
                        string script = $@"<script>alert('Error: {ex.Message}');</script>";

                        // Registrar el script en el cliente
                        ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", script);
                    }

                }
            }
        }

        private void CargarReservas()
        {
            // Consulta SQL para obtener todas las reservas de la base de datos
            string query = "SELECT id_reserva, tour, cliente, fecha_reserva, cantidad_personas FROM Reservas";

            // Crear una lista para almacenar las reservas
            List<Reserva> reservas = new List<Reserva>();

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
                        // Recorrer los resultados y agregarlos a la lista de reservas
                        while (reader.Read())
                        {
                            int idReserva = reader.GetInt32(0);
                            int tourId = reader.GetInt32(1); // Suponiendo que el campo 'tour' es un ID de tour
                            string clienteId = reader.GetString(2); // Suponiendo que el campo 'cliente' es un ID de cliente
                            DateTime fechaReserva = reader.GetDateTime(3);
                            int cantidadPersonas = reader.GetInt32(4);
                            reservas.Add(new Reserva { IdReserva = idReserva, TourId = tourId, ClienteId = clienteId, FechaReserva = fechaReserva, CantidadPersonas = cantidadPersonas });
                        }
                    }
                }
            }

            // Asignar la lista de reservas al GridView
            GridViewReservas.DataSource = reservas;
            GridViewReservas.DataBind();
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
    public class Reserva
    {
        public int IdReserva { get; set; }
        public int TourId { get; set; } // Propiedad para almacenar el ID del tour
        public string ClienteId { get; set; } // Propiedad para almacenar el ID del cliente
        public DateTime FechaReserva { get; set; }
        public int CantidadPersonas { get; set; }
    }

    public class Pago
    {
        public int IdPago { get; set; }
        public int IdReserva { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
    }


}
