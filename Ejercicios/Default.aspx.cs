using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ejercicios
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RecordarCumpleaños();
            }
        }

        private void RecordarCumpleaños()
        {
            // Obtener la cadena de conexión desde el archivo de configuración
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;

            // Crear una lista para almacenar los próximos cumpleaños
            List<string> cumpleañosProximos = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("PA_Miramontes", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string nombre = reader["nombres"].ToString();
                    string paterno = reader["paterno"].ToString();
                    string materno = reader["materno"].ToString();
                    DateTime fechaNacimiento = Convert.ToDateTime(reader["nacimiento"]);

                    // Calcular el próximo cumpleaños
                    DateTime proximoCumpleaños = ProximoCumpleaños(fechaNacimiento);

                    // Si el próximo cumpleaños es hoy, agregar a la lista
                    if (proximoCumpleaños == DateTime.Today)
                    {
                        cumpleañosProximos.Add(nombre + " " + paterno + " " + materno );
                    }
                }

                reader.Close();
            }

            // Mostrar los cumpleaños solo si hay alguien que cumple años hoy
            if (cumpleañosProximos.Count > 0)
            {
                string mensaje =  string.Join("<br />", cumpleañosProximos);
                MostrarMensaje(mensaje);
            }
            else
            {
                lblMensaje.Visible = false; // Ocultar el Label si no hay cumpleaños
            }
        }

        private DateTime ProximoCumpleaños(DateTime fechaNacimiento)
        {
            DateTime ahora = DateTime.Today;
            DateTime proximoCumpleaños = fechaNacimiento.AddYears(ahora.Year - fechaNacimiento.Year);

            if (proximoCumpleaños < ahora)
            {
                proximoCumpleaños = proximoCumpleaños.AddYears(1);
            }

            return proximoCumpleaños;
        }

        private void MostrarMensaje(string mensaje)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.Visible = true; // Mostrar el Label
            lbUno.Visible = true;
            imgEquipo.Visible = true;
            Image1.Visible = true;
            Image2.Visible = true;
            Image3.Visible = true;
            Image4.Visible = true;
            Label1.Visible = true;
            Image5.Visible = true;
        }
    }
}