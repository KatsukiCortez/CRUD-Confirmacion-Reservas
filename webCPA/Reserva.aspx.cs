using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace webCPA
{
    public partial class Reserva : System.Web.UI.Page
    {
        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargar las reservas existentes en la tabla al cargar la página
                CargarReservas();
                // Cargar los tours en el DropDownList de tours
                CargarTours();
                // Cargar los clientes en el DropDownList de clientes
                CargarClientes();
            }
        }

        protected void btnAgregarReserva_Click(object sender, EventArgs e)
        {
            // Obtener los datos del formulario
            DateTime fechaReserva = calFecha.SelectedDate;
            int idTour = Convert.ToInt32(ddlTour.SelectedValue);
            int idCliente = Convert.ToInt32(ddlCliente.SelectedValue);
            int cantidadPersonas = Convert.ToInt32(txtCantidadPersonas.Text);

            // Crear la conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // Crear la consulta SQL para insertar una nueva reserva
                string query = "INSERT INTO Reservas (tour, cliente, fecha_reserva, cantidad_personas) VALUES (@idTour, @idCliente, @fechaReserva, @cantidadPersonas)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idTour", idTour);
                command.Parameters.AddWithValue("@idCliente", idCliente);
                command.Parameters.AddWithValue("@fechaReserva", fechaReserva);
                command.Parameters.AddWithValue("@cantidadPersonas", cantidadPersonas);

                // Abrir la conexión y ejecutar la consulta
                connection.Open();
                command.ExecuteNonQuery();
            }
            // Recargar la tabla de reservas después de agregar una nueva
            CargarReservas();
        }

        protected void btnActualizarReserva_Click(object sender, EventArgs e)
        {
            // Obtener los datos del formulario
            int idReserva = Convert.ToInt32(hfIdReserva.Value);
            DateTime fechaReserva = Convert.ToDateTime(calFecha.SelectedDate);
            int idTour = Convert.ToInt32(ddlTour.SelectedValue);
            int idCliente = Convert.ToInt32(ddlCliente.SelectedValue);
            int cantidadPersonas = Convert.ToInt32(txtCantidadPersonas.Text);

            // Crear la conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // Crear la consulta SQL para actualizar la reserva existente
                string query = "UPDATE Reservas SET tour = @idTour, cliente = @idCliente, fecha_reserva = @fechaReserva, cantidad_personas = @cantidadPersonas WHERE id_reserva = @idReserva";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idReserva", idReserva);
                command.Parameters.AddWithValue("@idTour", idTour);
                command.Parameters.AddWithValue("@idCliente", idCliente);
                command.Parameters.AddWithValue("@fechaReserva", fechaReserva);
                command.Parameters.AddWithValue("@cantidadPersonas", cantidadPersonas);

                // Abrir la conexión y ejecutar la consulta
                connection.Open();
                command.ExecuteNonQuery();
            }
            // Limpiar el campo de ID de reserva y cambiar visibilidad del botón
            hfIdReserva.Value = "";
            btnAgregarReserva.Visible = true;
            btnActualizarReserva.Visible = false;

            // Recargar la tabla de reservas después de actualizar
            CargarReservas();
        }

        protected void btnEliminarReserva_Click(object sender, EventArgs e)
        {
            Button btnEliminarReserva = (Button)sender;
            int idReserva = Convert.ToInt32(btnEliminarReserva.CommandArgument); // Obtener el ID de la reserva

            // Eliminar el registro con el ID de reserva especificado
            string query = "DELETE FROM Reservas WHERE id_reserva = @idReserva";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idReserva", idReserva);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            // Recargar la tabla de reservas después de eliminar
            CargarReservas();
        }

        protected void btnEditarReserva_Click(object sender, EventArgs e)
        {
            Button btnEditarReserva = (Button)sender;
            int idReserva = Convert.ToInt32(btnEditarReserva.CommandArgument); // Obtener el ID de la reserva

            // Obtener los datos de la reserva seleccionada y cargarlos en el formulario
            string query = "SELECT * FROM Reservas WHERE id_reserva = @idReserva";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idReserva", idReserva);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        hfIdReserva.Value = idReserva.ToString(); // Almacenar el ID de la reserva en un campo oculto
                        calFecha.SelectedDate = Convert.ToDateTime(reader["fecha_reserva"]); // Modificado para usar Calendar
                        // Otros campos del formulario
                    }
                    connection.Close();
                }
            }
            // Cambiar la visibilidad de los botones de agregar y actualizar
            btnAgregarReserva.Visible = false;
            btnActualizarReserva.Visible = true;
        }

        private void CargarReservas()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // Crear la consulta SQL para obtener todas las reservas
                string query = "SELECT * FROM Reservas";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();

                // Llenar el DataTable con los resultados de la consulta
                adapter.Fill(dt);

                // Enlazar el DataTable a la tabla GridView en la página
                GridViewReservas.DataSource = dt;
                GridViewReservas.DataBind();
            }
        }

        private void CargarTours()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // Crear la consulta SQL para obtener todos los tours
                string query = "SELECT id_tour, nombre FROM Tours";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();

                // Llenar el DataTable con los resultados de la consulta
                adapter.Fill(dt);

                // Enlazar el DataTable al DropDownList de tours en la página
                ddlTour.DataSource = dt;
                ddlTour.DataTextField = "nombre";
                ddlTour.DataValueField = "id_tour";
                ddlTour.DataBind();
            }
        }

        private void CargarClientes()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // Crear la consulta SQL para obtener todos los clientes
                string query = "SELECT id_cliente, nombre FROM Clientes";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();

                // Llenar el DataTable con los resultados de la consulta
                adapter.Fill(dt);

                // Enlazar el DataTable al DropDownList de clientes en la página
                ddlCliente.DataSource = dt;
                ddlCliente.DataTextField = "nombre";
                ddlCliente.DataValueField = "id_cliente";
                ddlCliente.DataBind();
            }
        }
    }
}
