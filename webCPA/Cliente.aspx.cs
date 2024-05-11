using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webCPA
{
    public partial class Cliente : System.Web.UI.Page
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
                // Cargar los clientes existentes en la tabla al cargar la página
                CargarClientes();
            }
        }

        protected void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            // Obtener los datos del formulario
            string nombre = txtNombre.Text.Trim();
            string email = txtEmail.Text.Trim();
            string telefono = txtTelefono.Text.Trim();

            // Crear la conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // Crear la consulta SQL para insertar un nuevo cliente sin especificar el ID de cliente
                string query = "INSERT INTO Clientes (nombre, email, telefono) VALUES (@nombre, @email, @telefono)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@telefono", telefono);

                // Abrir la conexión y ejecutar la consulta
                connection.Open();
                command.ExecuteNonQuery();
            }
            LimpiarFormulario();
            // Recargar la tabla de clientes después de agregar uno nuevo
            CargarClientes();
        }

        protected void btnActualizarCliente_Click(object sender, EventArgs e)
        {
            // Obtener los datos del formulario
            int idCliente = Convert.ToInt32(hfIdCliente.Value);
            string nombre = txtNombre.Text.Trim();
            string email = txtEmail.Text.Trim();
            string telefono = txtTelefono.Text.Trim();

            // Crear la conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // Crear la consulta SQL para actualizar el cliente existente
                string query = "UPDATE Clientes SET nombre = @nombre, email = @email, telefono = @telefono WHERE id_cliente = @idCliente";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idCliente", idCliente);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@telefono", telefono);

                // Abrir la conexión y ejecutar la consulta
                connection.Open();
                command.ExecuteNonQuery();
            }
            // Limpiar el campo de ID de cliente y cambiar visibilidad del botón
            hfIdCliente.Value = "";
            btnAgregarCliente.Visible = true;
            btnActualizarCliente.Visible = false;


            LimpiarFormulario();
            // Recargar la tabla de clientes después de actualizar
            CargarClientes();
        }

        protected void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            Button btnEliminarCliente = (Button)sender;
            int idCliente = Convert.ToInt32(btnEliminarCliente.CommandArgument); // Obtener el ID del cliente

            // Eliminar el registro con el ID de cliente especificado
            string query = "DELETE FROM Clientes WHERE id_cliente = @idCliente";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idCliente", idCliente);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            // Recargar la tabla de clientes después de eliminar
            CargarClientes();
        }

        protected void btnEditarCliente_Click(object sender, EventArgs e)
        {
            Button btnEditarCliente = (Button)sender;
            int idCliente = Convert.ToInt32(btnEditarCliente.CommandArgument); // Obtener el ID del cliente

            // Obtener los datos del cliente seleccionado y cargarlos en el formulario
            string query = "SELECT * FROM Clientes WHERE id_cliente = @idCliente";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idCliente", idCliente);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        hfIdCliente.Value = idCliente.ToString(); // Almacenar el ID del cliente en un campo oculto
                        txtNombre.Text = reader["nombre"].ToString();
                        txtEmail.Text = reader["email"].ToString();
                        txtTelefono.Text = reader["telefono"].ToString();
                    }
                    connection.Close();
                }
            }
            // Cambiar la visibilidad de los botones de agregar y actualizar
            btnAgregarCliente.Visible = false;
            btnActualizarCliente.Visible = true;

        }

        private void CargarClientes()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // Crear la consulta SQL para obtener todos los clientes
                string query = "SELECT * FROM Clientes";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();

                // Llenar el DataTable con los resultados de la consulta
                adapter.Fill(dt);

                // Enlazar el DataTable a la tabla GridView en la página
                GridViewClientes.DataSource = dt;
                GridViewClientes.DataBind();
            }
        }
        private void LimpiarFormulario()
        {
            txtNombre.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
        }
    }
}