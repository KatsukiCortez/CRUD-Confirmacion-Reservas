using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace reservaTour.conexion
{
    public class AgregarTour
    {
        private string connectionString;

        public AgregarTour(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AgregarNuevoTour(string nombre, string descripcion, decimal precio)
        {
            // Conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                connection.Open();

                // Insertar nuevo tour en la base de datos
                string insertQuery = "INSERT INTO Tours (nombre, descripcion, precio) VALUES (@nombre, @descripcion, @precio)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@descripcion", descripcion);
                    command.Parameters.AddWithValue("@precio", precio);
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine(rowsAffected + " tour agregado correctamente.");
                }
            }
        }
    }
}