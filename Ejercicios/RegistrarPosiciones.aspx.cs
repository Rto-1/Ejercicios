using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ejercicios
{
    public partial class RegistrarPosiciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e) /*Tercera infantil*/
        {
            // Variables para almacenar los valores convertidos
            int fecha, local, visita, serie, golLocal, golVisita;

            // Verificar y convertir el valor seleccionado del DropDownList ddlFecha a int
            if (!int.TryParse(ddlFecha1.SelectedValue, out fecha))
            {
                // Manejar el caso en que la conversión falle
                Response.Write("Error: El valor de la fecha no es válido.");
                return; // Salir del método
            }

            // Verificar y convertir el valor seleccionado del DropDownList ddlLocal a int
            if (!int.TryParse(ddlLocal1.SelectedValue, out local))
            {
                // Manejar el caso en que la conversión falle
                Response.Write("Error: El valor del equipo local no es válido.");
                return; // Salir del método
            }

            // Verificar y convertir el valor seleccionado del DropDownList ddlVisita a int
            if (!int.TryParse(ddlVisita1.SelectedValue, out visita))
            {
                // Manejar el caso en que la conversión falle
                Response.Write("Error: El valor del equipo de visita no es válido.");
                return; // Salir del método
            }

            // Verificar y convertir el valor seleccionado del DropDownList ddlSerie a int
            if (!int.TryParse(ddlSerie1.SelectedValue, out serie))
            {
                // Manejar el caso en que la conversión falle
                Response.Write("Error: El valor de la serie no es válido.");
                return; // Salir del método
            }

            // Convertir los valores de los TextBox tbGolLocal y tbGolVisita a int
            if (!int.TryParse(tbGolLocal1.Text, out golLocal) || !int.TryParse(tbGolVisita1.Text, out golVisita))
            {
                // Manejar el caso en que la conversión falle
                Response.Write("Error: Los valores de los goles no son válidos.");
                return; // Salir del método
            }

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringPosiciones"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spRegistrarResultado", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaID", fecha);
                    cmd.Parameters.AddWithValue("@EquipoLocalID", local);
                    cmd.Parameters.AddWithValue("@EquipoVisitanteID", visita);
                    cmd.Parameters.AddWithValue("@SerieID", serie);
                    cmd.Parameters.AddWithValue("@GolesLocal", golLocal);
                    cmd.Parameters.AddWithValue("@GolesVisitante", golVisita);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Response.Write("Resultado registrado y estadísticas actualizadas.");
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error: " + ex.Message);
                    }
                }
            }
        }

        protected void btnRegistra_Click(object sender, EventArgs e) /*Todas las series*/
        {
            // Variables para almacenar los valores convertidos
            int fecha, local, visita, serie, golLocal, golVisita;

            // Verificar y convertir el valor seleccionado del DropDownList ddlFecha a int
            if (!int.TryParse(ddlFecha.SelectedValue, out fecha))
            {
                // Manejar el caso en que la conversión falle
                Response.Write("Error: El valor de la fecha no es válido.");
                return; // Salir del método
            }

            // Verificar y convertir el valor seleccionado del DropDownList ddlLocal a int
            if (!int.TryParse(ddlLocal.SelectedValue, out local))
            {
                // Manejar el caso en que la conversión falle
                Response.Write("Error: El valor del equipo local no es válido.");
                return; // Salir del método
            }

            // Verificar y convertir el valor seleccionado del DropDownList ddlVisita a int
            if (!int.TryParse(ddlVisita.SelectedValue, out visita))
            {
                // Manejar el caso en que la conversión falle
                Response.Write("Error: El valor del equipo de visita no es válido.");
                return; // Salir del método
            }

            // Verificar y convertir el valor seleccionado del DropDownList ddlSerie a int
            if (!int.TryParse(ddlSerie.SelectedValue, out serie))
            {
                // Manejar el caso en que la conversión falle
                Response.Write("Error: El valor de la serie no es válido.");
                return; // Salir del método
            }

            // Convertir los valores de los TextBox tbGolLocal y tbGolVisita a int
            if (!int.TryParse(tbGolLocal.Text, out golLocal) || !int.TryParse(tbGolVisita.Text, out golVisita))
            {
                // Manejar el caso en que la conversión falle
                Response.Write("Error: Los valores de los goles no son válidos.");
                return; // Salir del método
            }

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringPosiciones"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spRegistrarResultadoAdultos", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaID", fecha);
                    cmd.Parameters.AddWithValue("@EquipoLocalID", local);
                    cmd.Parameters.AddWithValue("@EquipoVisitanteID", visita);
                    cmd.Parameters.AddWithValue("@SerieID", serie);
                    cmd.Parameters.AddWithValue("@GolesLocal", golLocal);
                    cmd.Parameters.AddWithValue("@GolesVisitante", golVisita);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Response.Write("Resultado registrado y estadísticas actualizadas.");
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}