using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ejercicios
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        string patron = "LoginMiramontes";

        protected void BtnIngresarClick (object sender, EventArgs e)
        {
            string conectar = ConfigurationManager.ConnectionStrings["ConnectionStringLogin"].ConnectionString;
            SqlConnection sqlConectar = new SqlConnection(conectar);
            SqlCommand cmd = new SqlCommand("PA_ValidarUsuario", sqlConectar)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Connection.Open();
            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = tbUsuario.Value;
            cmd.Parameters.Add("@Contraseña", SqlDbType.VarChar, 50).Value = tbPassword.Value;
            cmd.Parameters.Add("@Patron", SqlDbType.VarChar, 50).Value = patron;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Response.Redirect("Miembros.aspx");   
            }
            else
            {
                lblMensaje.Text = "Usuario o contraseña incorrectos";
            }
            cmd.Connection.Close();

        }
    }
}