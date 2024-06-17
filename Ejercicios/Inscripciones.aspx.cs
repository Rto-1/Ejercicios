using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ejercicios
{
    public partial class Inscripciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            // Acceder a los valores de los controles de entrada y realizar acciones

            string nombres = lbnombres.Text;
            string apellidoPaterno = lbPaterno.Text;
            string apellidoMaterno = lbMaterno.Text;
            string fechaNacimiento = lbNacimiento.Text;
            string rut = lbRut.Text;
            string direccion = lbDireccion.Text;

            // Procesar los archivos adjuntos si es necesario
            ProcesarArchivosAdjuntos();

            // Procesar la firma digital si es necesario
            ProcesarFirmaDigital();

            // Aquí puedes realizar acciones adicionales, como guardar los datos en la base de datos, enviar un correo electrónico, etc.
            GuardarDatosEnBaseDeDatos(nombres, apellidoPaterno, apellidoMaterno, fechaNacimiento, rut, direccion);

            // Redirigir a otra página o mostrar un mensaje de éxito
            Response.Redirect("PaginaDeExito.aspx");
        }

        private void ProcesarArchivosAdjuntos()
        {
            // Lógica para procesar los archivos adjuntos
            // Aquí puedes acceder a los archivos adjuntos utilizando Request.Files
            // Por ejemplo:
            // HttpPostedFile fileFrontal = Request.Files["frontal"];
            // HttpPostedFile fileTrasera = Request.Files["trasera"];
            // Guardar los archivos en el servidor o realizar cualquier otra acción necesaria
        }

        private void ProcesarFirmaDigital()
        {
            // Lógica para procesar la firma digital
            // Aquí puedes acceder a los datos de la firma digital desde el canvas
            // Por ejemplo:
            // string firmaBase64 = hiddenFieldFirma.Value; // Suponiendo que la firma se almacena en un campo oculto en la página
            // Guardar la firma en el servidor o realizar cualquier otra acción necesaria
        }

        private void GuardarDatosEnBaseDeDatos(string nombres, string apellidoPaterno, string apellidoMaterno, string fechaNacimiento, string rut, string direccion)
        {
            // Aquí puedes escribir código para guardar los datos en tu base de datos
            // Por ejemplo:
            SqlConnection conn = new SqlConnection("cadena de conexión a tu base de datos");
            SqlCommand cmd = new SqlCommand("INSERT INTO Tabla (Nombres, ApellidoPaterno, ApellidoMaterno, FechaNacimiento, Rut, Direccion) VALUES (@Nombres, @ApellidoPaterno, @ApellidoMaterno, @FechaNacimiento, @Rut, @Direccion)", conn);
            cmd.Parameters.AddWithValue("@Nombres", nombres);
            cmd.Parameters.AddWithValue("@ApellidoPaterno", apellidoPaterno);
            cmd.Parameters.AddWithValue("@ApellidoMaterno", apellidoMaterno);
            cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
            cmd.Parameters.AddWithValue("@Rut", rut);
            cmd.Parameters.AddWithValue("@Direccion", direccion);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}