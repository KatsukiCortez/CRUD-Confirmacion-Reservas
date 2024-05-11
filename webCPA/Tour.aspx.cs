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
    public partial class Tour : System.Web.UI.Page
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
                // Cargar los tours existentes en la tabla al cargar la página
                CargarTours();
            }
        }

        protected void btnAgregarTour_Click(object sender, EventArgs e)
        {
            // Obtener los datos del formulario
            string nombre = txtnombre.Text.Trim();
            string descripcion = txtdescripcion.Text.Trim();
            decimal precio = Convert.ToDecimal(txtprecio.Text.Trim());

            // Crear la conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // Crear la consulta SQL para insertar un nuevo tour con el id_tour manual
                string query = "INSERT INTO Tours ( nombre, descripcion, precio) VALUES ( @nombre, @descripcion, @precio)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@descripcion", descripcion);
                command.Parameters.AddWithValue("@precio", precio);

                // Abrir la conexión y ejecutar la consulta
                connection.Open();
                command.ExecuteNonQuery();
            }
            // Recargar la tabla de tours después de agregar uno nuevo
            LimpiarControles();
            CargarTours();
        }


        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Button btnActualizar = (Button)sender;
            string idTour = btnActualizar.CommandArgument; // Obtener el id_tour del botón

            // Aquí puedes cargar los datos del tour en los controles de edición
            CargarDatosTour(idTour);

            // Puedes ocultar el botón de agregar y mostrar el botón de actualizar
            btnAgregarTour.Visible = false;
            btnActualizarTour.Visible = true;
            hfIdTour.Value = idTour; // Almacena el id_tour en el campo oculto para usarlo más tarde
        }

        protected void btnActualizarTour_Click(object sender, EventArgs e)
        {
            // Obtener los datos del formulario de edición
            string idTour = hfIdTour.Value; // Obtener el id_tour almacenado en el campo oculto
            string nombre = txtnombre.Text.Trim();
            string descripcion = txtdescripcion.Text.Trim();
            decimal precio = Convert.ToDecimal(txtprecio.Text.Trim());

            // Aquí debes actualizar los datos del tour en la base de datos
            ActualizarTour(idTour, nombre, descripcion, precio);

            // Puedes limpiar los controles o redirigir a otra página después de la actualización
            LimpiarControles();
            Response.Redirect(Request.RawUrl); // Redirigir para recargar la página y mostrar los cambios
        }

        private void ActualizarTour(string idTour, string nombre, string descripcion, decimal precio)
        {
            // Crear la conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // Crear la consulta SQL para actualizar el tour
                string query = "UPDATE Tours SET nombre = @nombre, descripcion = @descripcion, precio = @precio WHERE id_tour = @idTour";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idTour", idTour);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@descripcion", descripcion);
                command.Parameters.AddWithValue("@precio", precio);

                // Abrir la conexión y ejecutar la consulta
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void CargarDatosTour(string idTour)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // Crear la consulta SQL para obtener los datos del tour
                string query = "SELECT nombre, descripcion, precio FROM Tours WHERE id_tour = @idTour";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idTour", idTour);

                // Abrir la conexión y ejecutar la consulta
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Asignar los valores del tour a los controles de edición
                    txtnombre.Text = reader["nombre"].ToString();
                    txtdescripcion.Text = reader["descripcion"].ToString();
                    txtprecio.Text = reader["precio"].ToString();
                }

                reader.Close();
            }
        }

        private void LimpiarControles()
        {
            // Limpiar los controles de edición
            txtnombre.Text = "";
            txtdescripcion.Text = "";
            txtprecio.Text = "";
        }



        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            string idTour = btnEliminar.CommandArgument; // Obtener el id_tour del botón

            // Eliminar el registro con el id_tour especificado
            string connectionString = ConnectionString; // Utilizar la cadena de conexión obtenida en la propiedad
            string query = "DELETE FROM Tours WHERE id_tour = @idTour";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idTour", idTour);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    // Actualizar el GridView después de eliminar el registro
                    CargarTours();
                }
            }
        }

        private void CargarTours()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // Crear la consulta SQL para obtener todos los tours
                string query = "SELECT * FROM Tours";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();

                // Llenar el DataTable con los resultados de la consulta
                adapter.Fill(dt);

                // Enlazar el DataTable a la tabla GridView en la página
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
}