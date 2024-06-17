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
    public partial class TTInfantil : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGV();
            }
        }


        public void cargarGV()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringPosiciones"].ConnectionString;

            using (SqlConnection sqlConectar = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[spTerceraInfantil]", sqlConectar))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("id", "rut"); 

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        gvDatos.DataSource = dt;
                        gvDatos.DataBind();
                    }
                }
            }
        }

        protected void GvDatos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvDatos.EditIndex = e.NewEditIndex;
            cargarGV();
        }

        protected void GvDatos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                // Obtén los valores de las filas editables
                GridViewRow row = gvDatos.Rows[e.RowIndex];

                int puntos = Convert.ToInt32(((TextBox)row.FindControl("tbPuntos")).Text);
                int pj = Convert.ToInt32(((TextBox)row.FindControl("tbJugado")).Text);
                int pg = Convert.ToInt32(((TextBox)row.FindControl("tbGanado")).Text);
                int pe = Convert.ToInt32(((TextBox)row.FindControl("tbEmpatado")).Text);
                int pp = Convert.ToInt32(((TextBox)row.FindControl("tbPerdidos")).Text);

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringPosiciones"].ConnectionString))
                {
                    con.Open();
                    string procAlm = "sp_Actualiza_Puntos";
                    SqlCommand cmd = new SqlCommand(procAlm, con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Puntos", puntos);
                    cmd.Parameters.AddWithValue("@PartidosJugados", pj);
                    cmd.Parameters.AddWithValue("@PartidosGanados", pg);
                    cmd.Parameters.AddWithValue("@PartidosEmpatados", pe);
                    cmd.Parameters.AddWithValue("@PartidosPerdidos", pp);
                 

                    cmd.ExecuteNonQuery();

                    gvDatos.EditIndex = -1;
                    cargarGV();
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                // Puedes mostrar un mensaje de error en la interfaz de usuario o registrar el error en algún lugar
                // Ejemplo: lblError.Text = "Ocurrió un error al actualizar los datos: " + ex.Message;
                // O registrar el error en un archivo de log
            }
        }

        protected void GvDatos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDatos.EditIndex = -1;
            cargarGV();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            foreach (GridViewRow row in gvDatos.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    ClientScript.RegisterForEventValidation(gvDatos.UniqueID, "Edit$" + row.RowIndex);
                }
            }
            base.Render(writer);
        }

    }
}
