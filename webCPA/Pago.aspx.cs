using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;


namespace webCPA
{
    public partial class Pago : System.Web.UI.Page
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
                CargarPagos();
                CargarReservas();
                txtFechaPago.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        protected void btnAgregarPago_Click(object sender, EventArgs e)
        {
            int idReserva = Convert.ToInt32(ddlReserva.SelectedValue);
            decimal monto = Convert.ToDecimal(txtMonto.Text.Trim());
            DateTime fechaPago = Convert.ToDateTime(txtFechaPago.Text.Trim());

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "INSERT INTO Pagos (reserva, monto, fecha_pago) VALUES (@reserva, @monto, @fechaPago)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@reserva", idReserva);
                command.Parameters.AddWithValue("@monto", monto);
                command.Parameters.AddWithValue("@fechaPago", fechaPago);

                connection.Open();
                command.ExecuteNonQuery();
            }

            CargarPagos();
            LimpiarCampos();
        }

        protected void btnActualizarPago_Click(object sender, EventArgs e)
        {
            int idPago = Convert.ToInt32(hfIdPago.Value);
            int idReserva = Convert.ToInt32(ddlReserva.SelectedValue);
            decimal monto = Convert.ToDecimal(txtMonto.Text.Trim());
            DateTime fechaPago = Convert.ToDateTime(txtFechaPago.Text.Trim());

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "UPDATE Pagos SET reserva = @reserva, monto = @monto, fecha_pago = @fechaPago WHERE id_pago = @idPago";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@reserva", idReserva);
                command.Parameters.AddWithValue("@monto", monto);
                command.Parameters.AddWithValue("@fechaPago", fechaPago);
                command.Parameters.AddWithValue("@idPago", idPago);

                connection.Open();
                command.ExecuteNonQuery();
            }

            CargarPagos();
            LimpiarCampos();
            btnAgregarPago.Visible = true;
            btnActualizarPago.Visible = false;
        }

        protected void btnEliminarPago_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            int idPago = Convert.ToInt32(btnEliminar.CommandArgument);

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "DELETE FROM Pagos WHERE id_pago = @idPago";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idPago", idPago);

                connection.Open();
                command.ExecuteNonQuery();
            }

            CargarPagos();
        }

        protected void btnEditarPago_Click(object sender, EventArgs e)
        {
            Button btnEditar = (Button)sender;
            int idPago = Convert.ToInt32(btnEditar.CommandArgument);

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM Pagos WHERE id_pago = @idPago";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idPago", idPago);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    hfIdPago.Value = idPago.ToString();
                    ddlReserva.SelectedValue = reader["reserva"].ToString();
                    txtMonto.Text = reader["monto"].ToString();
                    txtFechaPago.Text = Convert.ToDateTime(reader["fecha_pago"]).ToString("yyyy-MM-dd");
                }
            }

            btnAgregarPago.Visible = false;
            btnActualizarPago.Visible = true;
        }

        private void CargarPagos()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM Pagos";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();

                adapter.Fill(dt);

                GridViewPagos.DataSource = dt;
                GridViewPagos.DataBind();
            }
        }

        private void LimpiarCampos()
        {
            ddlReserva.SelectedIndex = 0;
            txtMonto.Text = string.Empty;
            txtFechaPago.Text = string.Empty;
        }

        private void CargarReservas()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT r.id_reserva, CONCAT(t.nombre, ' - ', c.nombre) AS nombre_reserva FROM Reservas r INNER JOIN Tours t ON r.tour = t.id_tour INNER JOIN Clientes c ON r.cliente = c.id_cliente";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();

                adapter.Fill(dt);

                ddlReserva.DataSource = dt;
                ddlReserva.DataTextField = "nombre_reserva";
                ddlReserva.DataValueField = "id_reserva";
                ddlReserva.DataBind();

                // Agregar un elemento por defecto
                ddlReserva.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
            }
        }
    }
}
