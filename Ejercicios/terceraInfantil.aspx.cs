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
    public partial class terceraInfantil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarGV();

            }
        }

        public void cargarGV()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;

            using (SqlConnection sqlConectar = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[pa_TerceraInfantil]", sqlConectar))
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

        protected void btGuardar_Click(object sender, EventArgs e)
        {
            //string nombre = tbAgregaArticulo.Text;
            //int clasificacion = Convert.ToInt32(ddlAgreCla.SelectedValue);
            //string unidad = ddlAgregarUnidad.Text;
            //int minimo = Convert.ToInt32(tbAgregaMinimo.Text);
            //int habilitado = Convert.ToInt32(DropDownList3.SelectedValue);
            //int bodega = Convert.ToInt32(ddlAgreBodega.SelectedValue);

            //string usuario = Session["usuario"].ToString();
            //string contrasena = Session["Pass"].ToString();
            //string nomBD = Session["NomBD"].ToString();

            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings[nomBD].ConnectionString + ";User ID=" + usuario + ";Password=" + contrasena);
            //string procAlm = "pa_Inserta_Articulo_Art_Bodega";
            //SqlCommand cmd = new SqlCommand(procAlm, con);
            //cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@nombre", nombre);
            //cmd.Parameters.AddWithValue("@clasificacion", clasificacion);
            //cmd.Parameters.AddWithValue("@unidad", unidad);
            //cmd.Parameters.AddWithValue("@minimo", minimo);
            //cmd.Parameters.AddWithValue("@habilitado", habilitado);
            //cmd.Parameters.AddWithValue("@bodega", bodega);
            //cmd.Parameters.AddWithValue("@articulo", 0);
            //cmd.Parameters.AddWithValue("@ultimo_precio", 0);
            //cmd.Parameters.AddWithValue("@tipo_codigo", 1);

            //try
            //{
            //    con.Open();
            //    int filasAfectadas = cmd.ExecuteNonQuery();
            //    if (filasAfectadas > 0)
            //    {
            //        divMensaje.Visible = true;
            //        divError.Visible = false;
            //        lbMensaje.Text = "Se ha hecho el registro con éxito";
            //    }
            //    else
            //    {
            //        divMensaje.Visible = false;
            //        divError.Visible = true;
            //        lbMensaje.Text = "Hubo un error al insertar los datos.";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    divMensaje.Visible = false;
            //    divError.Visible = true;
            //    lbMensaje.Text = "Hubo un error al insertar los datos. Detalles: " + ex.Message;
            //}
            //finally
            //{
            //    con.Close();
            //}
        }
    }
}