using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Text;

namespace Ejercicios
{
    public partial class Miembros : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("[PA_Miramontes]", sqlConectar))
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
            string nombre = tbANombres.Text;
            string paterno = tbAPaterno.Text;
            string materno = tbAMaterno.Text;
            string nacimiento = tbANacimiento.Text;
            string rut = tbARut.Text;
            string direccion = tbADireccion.Text;

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString))
            {
                string procAlm = "PA_Insertar_Actualiza_Socios";
                SqlCommand cmd = new SqlCommand(procAlm, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombres", nombre);
                cmd.Parameters.AddWithValue("@paterno", paterno);
                cmd.Parameters.AddWithValue("@materno", materno);
                cmd.Parameters.AddWithValue("@nacimiento", nacimiento);
                cmd.Parameters.AddWithValue("@rut", rut);
                cmd.Parameters.AddWithValue("@direccion", direccion);
                cmd.Parameters.AddWithValue("@federacion", ""); // Verifica el nombre del parámetro
                cmd.Parameters.AddWithValue("@oficio", 0.0f); // Especifica el tipo de dato float
                cmd.Parameters.AddWithValue("@sancion", "");
                cmd.Parameters.AddWithValue("@email", "");
                cmd.Parameters.AddWithValue("@telefono", "");
                cmd.Parameters.AddWithValue("@id", 0);
                cmd.Parameters.AddWithValue("@nombresJugador", "");
                cmd.Parameters.AddWithValue("@nacto", "");

                try
                {
                    con.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        divMensaje.Visible = true;
                        divError.Visible = false;
                        lbMensaje.Text = "Se ha hecho el registro con éxito";
                    }
                    else
                    {
                        divMensaje.Visible = false;
                        divError.Visible = true;
                        lbMensaje.Text = "Hubo un error al insertar los datos.";
                    }
                }
                catch (Exception ex)
                {
                    divMensaje.Visible = false;
                    divError.Visible = true;
                    lbMensaje.Text = "Hubo un error al insertar los datos. Detalles: " + ex.Message;
                }
                finally
                {
                    con.Close();
                }
            }

        }

        protected void gvDatos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow fila = gvDatos.Rows[e.RowIndex];

            string id = gvDatos.DataKeys[e.RowIndex].Values["ID"].ToString();
            //int ids = Int32.Parse(((TextBox)(fila.FindControl("lbID"))).Text);
            string nombre = ((TextBox)(fila.FindControl("tbNombre"))).Text;
            string paterno = ((TextBox)(fila.FindControl("tbPaterno"))).Text;
            string materno = ((TextBox)(fila.FindControl("tbMaterno"))).Text;
            DateTime nacimiento;
            if (!DateTime.TryParse(((TextBox)(fila.FindControl("tbNacimiento"))).Text, out nacimiento))
            {
                // Manejo del error si la fecha no es válida
                // Puedes mostrar un mensaje de error o tomar otra acción adecuada
                return;
            }
            string rut = ((TextBox)(fila.FindControl("tbRut"))).Text;
            string direccion = ((TextBox)(fila.FindControl("tbDireccion"))).Text;
            string msg = "";

            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString))
                {
                    con.Open();
                    string procAlm = "pa_Actualiza_Socios";
                    SqlCommand cmd = new SqlCommand(procAlm, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nombres", nombre);
                    cmd.Parameters.AddWithValue("@paterno", paterno);
                    cmd.Parameters.AddWithValue("@materno", materno);
                    cmd.Parameters.AddWithValue("@nacimiento", nacimiento);
                    cmd.Parameters.AddWithValue("@rut", rut);
                    cmd.Parameters.AddWithValue("@direccion", direccion);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                msg = ex.Message;
                // Manejo del error si ocurre una excepción al ejecutar el comando SQL
            }

            gvDatos.EditIndex = -1;
            cargarGV(); //carga nuevamente los datos en el GridView
        }


        protected void gvDatos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvDatos.EditIndex = e.NewEditIndex;
            cargarGV(); // carga nuevamente los datos en el GridView
        }

        protected void gvDatos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDatos.EditIndex = -1;
            cargarGV();
        }

        private string nombres;
        private string paterno;
        private string materno;
        private string nacimiento;
        private string rut;
        private string direccion;
        private string telefono;
        private string email;

        public void btnBuscar_Click(object sender, EventArgs e)
        {
            string nomArti = btnBuscar.Text;
            DataTable dt = new DataTable();
            int num_reg;

            string connectionString = "Data Source=RTO;Initial Catalog=Mira;User ID=sa;Password=123456;Encrypt=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string procAlm = "pa_ConsultaID";
                SqlCommand cmd = new SqlCommand(procAlm, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@buscar", nomArti);

                try
                {
                    connection.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    num_reg = sda.Fill(dt);

                    if (num_reg > 0)
                    {
                        nombres = dt.Rows[0]["nombres"].ToString();
                        paterno = dt.Rows[0]["paterno"].ToString();
                        materno = dt.Rows[0]["materno"].ToString();
                        nacimiento = dt.Rows[0]["nacimiento"].ToString();
                        rut = dt.Rows[0]["rut"].ToString();
                        direccion = dt.Rows[0]["direccion"].ToString();
                        tbNombre.Text = nombres;
                        tbPaterno.Text = paterno;
                        tbMaterno.Text = materno;
                        lbNacimiento.Text = nacimiento;
                        lbRut.Text = rut;
                        lbDireccion.Text = direccion;

                        // Llamar al método para generar el PDF
                        //btnGenerarPDF_Click(sender, e);
                    }
                    else
                    {
                        lblNombre.Text = "No se encontraron resultados";
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                }
            }
        }

        protected void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            // Establecer la conexión con la base de datos
            //string connectionString = "Data Source=RTO;Initial Catalog=Miramontes;User ID=sa;Password=123456;Encrypt=False";
            //using (SqlConnection connection = new SqlConnection(connectionString))

            Font Font3 = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 1, iTextSharp.text.Font.NORMAL));
            Font Font7 = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 7, iTextSharp.text.Font.NORMAL));
            Font Font8 = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.NORMAL));
            Font FontB8 = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.BOLD));
            Font FontB9 = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.BOLD));
            Font Font9 = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
            Font FontB10 = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.BOLD));
            Font Font12 = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.Font.BOLD));
            Font Font6_pie = new Font(FontFactory.GetFont(FontFactory.TIMES, 6, iTextSharp.text.Font.NORMAL));
            Font FontB14_VERDE = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.BOLD, new BaseColor(6, 117, 19)));
            Font Font32 = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 32, iTextSharp.text.Font.BOLD));
            Font FontB8_text = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.BOLD, new BaseColor(255, 255, 255)));
            Font FontB7_text = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 6, iTextSharp.text.Font.BOLD, new BaseColor(255, 255, 255)));
            Font FontB5_text = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 5, iTextSharp.text.Font.BOLD, new BaseColor(255, 255, 255)));

            //string rut = lbRut.Text;
            //string nacimiento = lbNacimiento.Text;
            //string nombres = lblNombre.Text;
            //string paterno = lbPaterno.Text;
            //string materno = lbMaterno.Text;
            //string direccion = lbDireccion.Text;
            //string telefono = "";
            //string email = "";

            string directorio_pdf = "~/carnetPDF/";
            string nombre_archivo_pdf = directorio_pdf + "Reporte_Prod_Ped_Entreg.pdf";
            string FicheroPDF = Server.MapPath(nombre_archivo_pdf);

            // Nombre del procedimiento almacenado
            //string procedureName = nombres + paterno + materno + rut + nacimiento + direccion + telefono + email;


            //// Crear el comando para ejecutar el procedimiento almacenado
            //SqlCommand command = new SqlCommand(procedureName, connection);
            //command.CommandType = System.Data.CommandType.StoredProcedure;

            // Abre la conexión
            //connection.Open();

            // Ejecutar el comando y obtener un SqlDataReader
            //SqlDataReader reader = command.ExecuteReader();

            // Crear un documento PDF
            Document documentoPDF = new Document();
            PdfWriter pdfWrite = PdfWriter.GetInstance(documentoPDF, new FileStream(FicheroPDF, FileMode.Create));
            documentoPDF.Open();
            //Document documentoPDF = new Document();
            //PdfWriter.GetInstance(documentoPDF, Response.OutputStream);
            //documentoPDF.Open();

            // Crear una tabla para mostrar los datos
            //PdfPTable table = new PdfPTable(2); // 2 columnas
            //table.WidthPercentage = 100; // ancho de la tabla al 100% de la página

            //string imagenURL = "./images/miramontes.png";
            //iTextSharp.text.Image imagenJPG;
            //imagenJPG = iTextSharp.text.Image.GetInstance(Server.MapPath(imagenURL));
            //imagenJPG.ScaleToFit(60.0F, 60.0F);
            //imagenJPG.SpacingBefore = 10.0F;
            //imagenJPG.SpacingAfter = 5.0F;
            //imagenJPG.SetAbsolutePosition(50, 735);
            //documentoPDF.Add(imagenJPG);

            //string categoria = "Carnet Jugador";
            //string titulo = "Club Deportivo Miramontes";

            //PdfPTable Tabla1 = new PdfPTable(2);
            //Tabla1.WidthPercentage = 100;

            //Tabla1.AddCell(new PdfPCell(new Phrase(" ", Font12)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP, Rowspan = 3});
            //Tabla1.AddCell(new PdfPCell(new Phrase(titulo, Font12)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
            //Tabla1.AddCell(new PdfPCell(new Phrase(categoria, Font8)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT});
            //Tabla1.AddCell(new PdfPCell(new Phrase(" ", Font12)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP, Rowspan = 3});

            //documentoPDF.Add(new Paragraph(" "));

            PdfPTable Tabla2 = new PdfPTable(10);
            float[] ancho2 = new float[] { 20.0F, 10.0F, 20.0F, 9.0F, 16.0F, 5.0F, 5.0F, 5.0F, 5.0F, 5.0F };
            Tabla2.WidthPercentage = 100;
            Tabla2.SetWidths(ancho2);


            //while (reader.Read())
            //{
            //    rut = reader["rut"].ToString();
            //    nacimiento = reader["nacimiento"].ToString();
            //    nombres = reader["nombres"].ToString();
            //    paterno = reader["paterno"].ToString();
            //    materno = reader["materno"].ToString();

            //}
            Tabla2.AddCell(new PdfPCell(new Phrase("CARNET JUGADOR 2024 ", FontB14_VERDE)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Colspan = 14 });

            Tabla2.AddCell(new PdfPCell(new Phrase("COMPROBANTE TRÁMITE JUGADOR – ADFLC\"", FontB8_text)) { BackgroundColor = new BaseColor(120, 120, 120), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 3 });
            Tabla2.AddCell(new PdfPCell(new Phrase("-VALIDO POR 4 AÑOS DESDE FECHA TIMBRADA-", FontB8_text)) { BackgroundColor = new BaseColor(120, 120, 120), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 7 });

            Tabla2.AddCell(new PdfPCell(new Phrase(tbNombre.Text + " " + tbPaterno.Text + " " + tbMaterno.Text, FontB9)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Colspan = 3 });
            Tabla2.AddCell(new PdfPCell(new Phrase("-SOLO COMPRUEBA QUE EL TRAMITE SE ESTÁ CURSANDO -", Font7)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 7 });

            Tabla2.AddCell(new PdfPCell(new Phrase(" ", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 7 });
            Tabla2.AddCell(new PdfPCell(new Phrase("AMATEUR ADULTO – INFANTIL", Font8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });
            Tabla2.AddCell(new PdfPCell(new Phrase("TRÁMITE", FontB8_text)) { BackgroundColor = new BaseColor(120, 120, 120), HorizontalAlignment = Element.ALIGN_CENTER });
            Tabla2.AddCell(new PdfPCell(new Phrase("INSCRIPCIÓN", Font7)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER });
            Tabla2.AddCell(new PdfPCell(new Phrase(" ", Font7)) { HorizontalAlignment = Element.ALIGN_CENTER });
            Tabla2.AddCell(new PdfPCell(new Phrase("PASE", Font7)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER });
            Tabla2.AddCell(new PdfPCell(new Phrase(" ", Font7)) { HorizontalAlignment = Element.ALIGN_CENTER });
            Tabla2.AddCell(new PdfPCell(new Phrase("OTRO", Font7)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER });
            Tabla2.AddCell(new PdfPCell(new Phrase(" ", Font7)) { HorizontalAlignment = Element.ALIGN_CENTER });

            Tabla2.AddCell(new PdfPCell(new Phrase("RUT:", Font8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER });
            Tabla2.AddCell(new PdfPCell(new Phrase(lbRut.Text, Font8)) { HorizontalAlignment = Element.ALIGN_CENTER });
            Tabla2.AddCell(new PdfPCell(new Phrase("CLUB ACTUAL", Font8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });
            Tabla2.AddCell(new PdfPCell(new Phrase("MIRAMONTES", FontB9)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 5 });

            Tabla2.AddCell(new PdfPCell(new Phrase("NACIMIENTO", Font7)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER });
            Tabla2.AddCell(new PdfPCell(new Phrase(lbNacimiento.Text, Font9)) { HorizontalAlignment = Element.ALIGN_CENTER });
            Tabla2.AddCell(new PdfPCell(new Phrase("DE LA ASOCIACIÓN", Font8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });
            Tabla2.AddCell(new PdfPCell(new Phrase("LAS CONDES", Font9)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 5 });

            Tabla2.AddCell(new PdfPCell(new Phrase("CLUB", Font7)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER });
            Tabla2.AddCell(new PdfPCell(new Phrase("MIRAMONTES", FontB9)) { HorizontalAlignment = Element.ALIGN_CENTER });
            Tabla2.AddCell(new PdfPCell(new Phrase("COBERTURA ARFAMED EN CLUB ACTUAL", FontB7_text)) { BackgroundColor = new BaseColor(120, 120, 120), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER, Colspan = 3 });
            Tabla2.AddCell(new PdfPCell(new Phrase("SI", Font8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER });
            Tabla2.AddCell(new PdfPCell(new Phrase(" ", FontB10)) { HorizontalAlignment = Element.ALIGN_CENTER });
            Tabla2.AddCell(new PdfPCell(new Phrase("NO", Font8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER });
            Tabla2.AddCell(new PdfPCell(new Phrase(" ", FontB9)) { HorizontalAlignment = Element.ALIGN_CENTER });

            Tabla2.AddCell(new PdfPCell(new Phrase("FIRMA", Font8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            Tabla2.AddCell(new PdfPCell(new Phrase(" ", Font32)) { HorizontalAlignment = Element.ALIGN_CENTER });
            Tabla2.AddCell(new PdfPCell(new Phrase("FIRMA SECRETARIO", Font8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Colspan = 2 });
            Tabla2.AddCell(new PdfPCell(new Phrase(" ", Font32)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 5 });

            Tabla2.AddCell(new PdfPCell(new Phrase("FOLIO INT:", Font8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER });
            Tabla2.AddCell(new PdfPCell(new Phrase(" ", Font8)) { HorizontalAlignment = Element.ALIGN_CENTER });
            Tabla2.AddCell(new PdfPCell(new Phrase("CON FECHA:", Font8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });
            Tabla2.AddCell(new PdfPCell(new Phrase("____ - ____- 2024", Font8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 5 });

            Tabla2.AddCell(new PdfPCell(new Phrase("(13) R. METRO – LAS CONDES (103)", FontB8_text)) { BackgroundColor = new BaseColor(120, 120, 120), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });
            Tabla2.AddCell(new PdfPCell(new Phrase("-VALIDO POR 4 AÑOS DESDE FECHA TIMBRADA-", FontB8_text)) { BackgroundColor = new BaseColor(120, 120, 120), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 7 });

            documentoPDF.Add(new Paragraph(" "));




            PdfPTable Tabla3 = new PdfPTable(14);
            float[] ancho3 = new float[] { 10.0F, 5.0F, 5.0F, 10.0F, 5.0F, 5.0F, 5.0F, 5.0F, 15.0F, 5.0F, 15.0F, 5.0F, 5.0F, 5.0F };
            Tabla3.WidthPercentage = 100;
            Tabla3.SetWidths(ancho3);

            //while (reader.Read())
            //{
            //    rut = reader["rut"].ToString();
            //    nacimiento = reader["nacimiento"].ToString();
            //    nombres = reader["nombres"].ToString();
            //    paterno = reader["paterno"].ToString();
            //    materno = reader["materno"].ToString();
            //    direccion = reader["direccion"].ToString();
            //    telefono = reader["telefono"].ToString();
            //    email = reader["email"].ToString();

            //}
            Tabla3.AddCell(new PdfPCell(new Phrase("FICHA JUGADOR 2024 ", FontB14_VERDE)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Colspan = 14 });

            Tabla3.AddCell(new PdfPCell(new Phrase("APELLIDO PATERNO", FontB8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 3 });
            Tabla3.AddCell(new PdfPCell(new Phrase("APELLIDO MATERNO", FontB8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 3 });
            Tabla3.AddCell(new PdfPCell(new Phrase("NOMBRES", FontB8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 4 });
            Tabla3.AddCell(new PdfPCell(new Phrase("RUT", Font6_pie)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });
            Tabla3.AddCell(new PdfPCell(new Phrase("F. DE NACIMINETO", Font6_pie)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });

            Tabla3.AddCell(new PdfPCell(new Phrase(tbPaterno.Text, FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 3 });
            Tabla3.AddCell(new PdfPCell(new Phrase(tbMaterno.Text, FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 3 });
            Tabla3.AddCell(new PdfPCell(new Phrase(tbNombre.Text, FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 4 });
            Tabla3.AddCell(new PdfPCell(new Phrase(lbRut.Text, Font7)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });
            Tabla3.AddCell(new PdfPCell(new Phrase(lbNacimiento.Text, Font6_pie)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });

            Tabla3.AddCell(new PdfPCell(new Phrase("DIRECCION", FontB8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 8 });
            Tabla3.AddCell(new PdfPCell(new Phrase("TELEFONO", FontB8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });
            Tabla3.AddCell(new PdfPCell(new Phrase("E-MAIL", FontB8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 4 });

            Tabla3.AddCell(new PdfPCell(new Phrase(lbDireccion.Text, FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 8 });
            Tabla3.AddCell(new PdfPCell(new Phrase(telefono, FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });
            Tabla3.AddCell(new PdfPCell(new Phrase(email, FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 4 });

            Tabla3.AddCell(new PdfPCell(new Phrase(" ", Font3)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 14 });

            Tabla3.AddCell(new PdfPCell(new Phrase("TRAMITE", FontB8_text)) { BackgroundColor = new BaseColor(120, 120, 120), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 8 });
            Tabla3.AddCell(new PdfPCell(new Phrase("SEGMENTO", FontB8_text)) { BackgroundColor = new BaseColor(120, 120, 120), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 4 });
            Tabla3.AddCell(new PdfPCell(new Phrase("CODIGO", FontB5_text)) { BackgroundColor = new BaseColor(120, 120, 120), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 1 });
            Tabla3.AddCell(new PdfPCell(new Phrase("MONTO", FontB5_text)) { BackgroundColor = new BaseColor(120, 120, 120), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 1 });

            Tabla3.AddCell(new PdfPCell(new Phrase("Inscripcion", FontB8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 1 });
            Tabla3.AddCell(new PdfPCell(new Phrase("Pase", FontB8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 1 });
            Tabla3.AddCell(new PdfPCell(new Phrase("Otro", FontB8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 1 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 1 });
            Tabla3.AddCell(new PdfPCell(new Phrase("Adulto", FontB8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 1 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 1 });
            Tabla3.AddCell(new PdfPCell(new Phrase("Infantil", FontB8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 1 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 1 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 1 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 1 });

            Tabla3.AddCell(new PdfPCell(new Phrase(" ", Font3)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 14 });

            Tabla3.AddCell(new PdfPCell(new Phrase("PARA INCORPORARSE AL CLUB DEPORTIVO", FontB7_text)) { BackgroundColor = new BaseColor(120, 120, 120), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 6 });
            Tabla3.AddCell(new PdfPCell(new Phrase("MIRAMONTES", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 3 });
            Tabla3.AddCell(new PdfPCell(new Phrase("ASOCIACION DE FUTBOL LAS CONDES", FontB7_text)) { BackgroundColor = new BaseColor(120, 120, 120), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 5 });

            Tabla3.AddCell(new PdfPCell(new Phrase("PROCEDE DEL CLUB DEPORTIVO", Font6_pie)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 3 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 6 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 7 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 3, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 9 });

            Tabla3.AddCell(new PdfPCell(new Phrase("DE LA ASOCIACION", Font6_pie)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 3 });
            Tabla3.AddCell(new PdfPCell(new Phrase("LAS CONDES", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 6 });

            Tabla3.AddCell(new PdfPCell(new Phrase("CONCEDE PASE", FontB8_text)) { BackgroundColor = new BaseColor(120, 120, 120), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 9 });

            Tabla3.AddCell(new PdfPCell(new Phrase("(SOLO SI ES NECESARIO – PARA TRÁMITE DE PASE DE JUGADOR INFANTIL/JUVENIL)", FontB7_text)) { BackgroundColor = new BaseColor(120, 120, 120), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 9 });

            Tabla3.AddCell(new PdfPCell(new Phrase(" ", Font12)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 9 });
            Tabla3.AddCell(new PdfPCell(new Phrase("El club de procedencia  ACEPTA la renuncia indeclinable que el jugador de la referencia del trámite formula. La renuncia se formula como socio y jugador del club de procedencia. A la vez, el club de procedencia, CONCEDE PASEal jugador del trámite para ingresar al club del trámite.", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 9 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", Font12)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 9 });

            Tabla3.AddCell(new PdfPCell(new Phrase("FIRMA Y RUT SECRETARIO CLUB", Font6_pie)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 4 });
            Tabla3.AddCell(new PdfPCell(new Phrase("TIMBRE CLUB", Font6_pie)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 3 });
            Tabla3.AddCell(new PdfPCell(new Phrase("FIRMA Y RUT PRESIDENTE DEL CLUB", Font6_pie)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });
            Tabla3.AddCell(new PdfPCell(new Phrase("FIRMA JUGADOR", Font6_pie)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });

            Tabla3.AddCell(new PdfPCell(new Phrase(" ", Font32)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 4 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", Font32)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 3 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", Font32)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", Font32)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });

            Tabla3.AddCell(new PdfPCell(new Phrase(" ", Font3)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 14 });

            Tabla3.AddCell(new PdfPCell(new Phrase("FECHA DE RECEPCION", FontB8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 4 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 4 });
            Tabla3.AddCell(new PdfPCell(new Phrase("V° B° ASOCIACION", FontB8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 3 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 3 });

            Tabla3.AddCell(new PdfPCell(new Phrase(" ", Font3)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 14 });

            Tabla3.AddCell(new PdfPCell(new Phrase("APELLIDO PATERNO", FontB8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 3 });
            Tabla3.AddCell(new PdfPCell(new Phrase("APELLIDO MATERNO", FontB8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 3 });
            Tabla3.AddCell(new PdfPCell(new Phrase("NOMBRES", FontB8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 4 });
            Tabla3.AddCell(new PdfPCell(new Phrase("CEDULA IDENTIDAD", Font6_pie)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });
            Tabla3.AddCell(new PdfPCell(new Phrase("F. NACIMIENTO", Font6_pie)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });

            Tabla3.AddCell(new PdfPCell(new Phrase(tbPaterno.Text, FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 3 });
            Tabla3.AddCell(new PdfPCell(new Phrase(tbMaterno.Text, FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 3 });
            Tabla3.AddCell(new PdfPCell(new Phrase(tbNombre.Text, FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 4 });
            Tabla3.AddCell(new PdfPCell(new Phrase(lbRut.Text, Font7)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });
            Tabla3.AddCell(new PdfPCell(new Phrase(lbNacimiento.Text, Font6_pie)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });

            Tabla3.AddCell(new PdfPCell(new Phrase("DIRECCION", FontB8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 8 });
            Tabla3.AddCell(new PdfPCell(new Phrase("TELEFONO", FontB8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });
            Tabla3.AddCell(new PdfPCell(new Phrase("E-MAIL", FontB8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 4 });

            Tabla3.AddCell(new PdfPCell(new Phrase(lbDireccion.Text, FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 8 });
            Tabla3.AddCell(new PdfPCell(new Phrase(telefono, FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });
            Tabla3.AddCell(new PdfPCell(new Phrase(email, FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 4 });

            Tabla3.AddCell(new PdfPCell(new Phrase(" ", Font3)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 14 });

            Tabla3.AddCell(new PdfPCell(new Phrase("TRAMITE", FontB8_text)) { BackgroundColor = new BaseColor(120, 120, 120), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 8 });
            Tabla3.AddCell(new PdfPCell(new Phrase("SEGMENTO", FontB8_text)) { BackgroundColor = new BaseColor(120, 120, 120), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 4 });
            Tabla3.AddCell(new PdfPCell(new Phrase("CODIGO", FontB5_text)) { BackgroundColor = new BaseColor(120, 120, 120), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 1 });
            Tabla3.AddCell(new PdfPCell(new Phrase("MONTO", FontB5_text)) { BackgroundColor = new BaseColor(120, 120, 120), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 1 });

            Tabla3.AddCell(new PdfPCell(new Phrase("Inscripcion", FontB8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 1 });
            Tabla3.AddCell(new PdfPCell(new Phrase("Pase", FontB8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 1 });
            Tabla3.AddCell(new PdfPCell(new Phrase("Otro", FontB8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 1 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 1 });
            Tabla3.AddCell(new PdfPCell(new Phrase("Adulto", FontB8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 1 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 1 });
            Tabla3.AddCell(new PdfPCell(new Phrase("Infantil", FontB8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 1 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 1 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 1 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 1 });

            Tabla3.AddCell(new PdfPCell(new Phrase(" ", Font3)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 14 });

            Tabla3.AddCell(new PdfPCell(new Phrase("PARA INCORPORARSE AL CLUB DEPORTIVO", FontB7_text)) { BackgroundColor = new BaseColor(120, 120, 120), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 6 });
            Tabla3.AddCell(new PdfPCell(new Phrase("MIRAMONTES", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 3 });
            Tabla3.AddCell(new PdfPCell(new Phrase("ASOCIACION DE FUTBOL LAS CONDES", FontB7_text)) { BackgroundColor = new BaseColor(120, 120, 120), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 5 });

            Tabla3.AddCell(new PdfPCell(new Phrase("PROCEDE DEL CLUB DEPORTIVO", Font6_pie)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 3 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 6 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 7 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 3, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 9 });

            Tabla3.AddCell(new PdfPCell(new Phrase("DE LA ASOCIACION", Font6_pie)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 3 });
            Tabla3.AddCell(new PdfPCell(new Phrase("LAS CONDES", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 6 });

            Tabla3.AddCell(new PdfPCell(new Phrase("CONCEDE PASE", FontB8_text)) { BackgroundColor = new BaseColor(120, 120, 120), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 9 });

            Tabla3.AddCell(new PdfPCell(new Phrase("(SOLO SI ES NECESARIO – PARA TRÁMITE DE PASE DE JUGADOR INFANTIL/JUVENIL)", FontB7_text)) { BackgroundColor = new BaseColor(120, 120, 120), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 9 });

            Tabla3.AddCell(new PdfPCell(new Phrase(" ", Font12)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 9 });
            Tabla3.AddCell(new PdfPCell(new Phrase("El club de procedencia  ACEPTA la renuncia indeclinable que el jugador de la referencia del trámite formula. La renuncia se formula como socio y jugador del club de procedencia. A la vez, el club de procedencia, CONCEDE PASEal jugador del trámite para ingresar al club del trámite.", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 9 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", Font12)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 9 });

            Tabla3.AddCell(new PdfPCell(new Phrase("FIRMA Y RUT SECRETARIO CLUB", Font6_pie)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 4 });
            Tabla3.AddCell(new PdfPCell(new Phrase("TIMBRE CLUB", Font6_pie)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 3 });
            Tabla3.AddCell(new PdfPCell(new Phrase("FIRMA Y RUT PRESIDENTE DEL CLUB", Font6_pie)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });
            Tabla3.AddCell(new PdfPCell(new Phrase("FIRMA JUGADOR", Font6_pie)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });

            Tabla3.AddCell(new PdfPCell(new Phrase(" ", Font32)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 4 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", Font32)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 3 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", Font32)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", Font32)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });

            Tabla3.AddCell(new PdfPCell(new Phrase(" ", Font3)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 14 });

            Tabla3.AddCell(new PdfPCell(new Phrase("FECHA DE RECEPCION", FontB8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 4 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 4 });
            Tabla3.AddCell(new PdfPCell(new Phrase("V° B° ASOCIACION", FontB8)) { BackgroundColor = new BaseColor(220, 220, 220), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 3 });
            Tabla3.AddCell(new PdfPCell(new Phrase(" ", FontB8)) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 3 });


            // Agregar la tabla al documento
            //documentoPDF.Add(Tabla1);
            documentoPDF.Add(Tabla2);
            documentoPDF.Add(Tabla3);

            // Cerrar el documento y liberar los recursos
            documentoPDF.Close();
            //reader.Close();
            //connection.Close();


            var pathCorto = "carnetPDF/Reporte_Prod_Ped_Entreg.pdf";
            StringBuilder cstext2 = new StringBuilder();
            cstext2.Append("<script language=javascript>");
            cstext2.Append("window.open('" + pathCorto + "','_blank','scrollbars=yes,width=800px,height=600px,top=50px, left=10px,toolbar=yes,menubar=yes,location=no,location=0')");
            cstext2.Append("</script>");
            ClientScript.RegisterStartupScript(Page.GetType(), "BlahBlah", cstext2.ToString());

            // Configurar la respuesta HTTP para que el navegador pueda descargar el PDF
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", "attachment;filename=nombre_del_archivo.pdf");
            //Response.End();
        }


        //protected void gvDatos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    gvDatos.EditIndex = -1;
        //    cargarGV();
        //}




        //protected void gvDatos_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    if (gvDatos.Rows.Count > 0 && e.NewEditIndex >= 0 && e.NewEditIndex < gvDatos.Rows.Count)
        //    {
        //        // Obtener el ID del artículo de la fila seleccionada
        //        int idArticulo = Convert.ToInt32(gvDatos.DataKeys[e.NewEditIndex].Value);

        //        // Almacenar el ID del artículo en una variable de sesión
        //        Session["Button1"] = idArticulo; Session["Button1"] = idArticulo;
        //    }

        //    {
        //        gvDatos.EditIndex = e.NewEditIndex;
        //        cargarGV();
        //        int fila = e.NewEditIndex;

        //        Label lbID = (Label)gvDatos.Rows[fila].FindControl("lbID");

        //        string usuario = Session["usuario"].ToString();
        //        string contrasena = Session["Pass"].ToString();
        //        string nomBD = Session["NomBD"].ToString();

        //        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["strBodega"].ConnectionString);
        //        con = new SqlConnection(ConfigurationManager.ConnectionStrings[nomBD].ConnectionString + ";User ID=" + usuario + ";Password=" + contrasena);

        //        DropDownList clasificacion = new DropDownList();
        //        clasificacion = (DropDownList)gvDatos.Rows[fila].Cells[3].FindControl("ddlClasificacion");
        //        string labelClasifica = ((Label)(gvDatos.Rows[fila].Cells[3].FindControl("lbClasifica"))).Text;
        //        //string label = ((Label)gvDatos.Rows[fila].Cells[3].FindControl("lbRut")).Text;
        //        //string labelCla = label.ToString();

        //        DataTable dt = new DataTable();
        //        int num_reg;
        //        string procAlm = "PA_Obtiene_Descripcion_Clasificacion";
        //        SqlCommand cmd = new SqlCommand(procAlm, con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        con.Open();
        //        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //        num_reg = sda.Fill(dt);
        //        clasificacion.DataSource = dt;
        //        clasificacion.DataTextField = "descripcion";
        //        clasificacion.DataValueField = "id";
        //        clasificacion.DataBind();
        //        clasificacion.Items.Insert(1, new ListItem(labelClasifica, "0")); //deja nombre actual del label
        //        //clasificacion.SelectedValue = labelCla;
        //        con.Close();

        //        DropDownList unidad = new DropDownList();
        //        unidad = (DropDownList)gvDatos.Rows[fila].Cells[4].FindControl("ddlUnidad");
        //        string labelUnidad = ((Label)(gvDatos.Rows[fila].Cells[4].FindControl("lbUni"))).Text;
        //        DataTable dt2 = new DataTable();
        //        int num_reg2;
        //        string procAlm2 = "PA_Consulta_Unidad_Articulo";
        //        SqlCommand cmd2 = new SqlCommand(procAlm2, con);
        //        cmd2.CommandType = CommandType.StoredProcedure;
        //        con.Open();
        //        SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
        //        num_reg2 = sda2.Fill(dt2);
        //        unidad.DataSource = dt2;
        //        unidad.DataTextField = "unidad";
        //        unidad.DataBind();
        //        unidad.Items.Insert(0, new ListItem(labelUnidad, "0")); //deja el nombre actual del label
        //        unidad.SelectedValue = "0";
        //        con.Close();



        //    }

        //}
        //protected void gvDatos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    int idArticulo = Convert.ToInt32(Session["Button1"]);

        //    string usuario = Session["usuario"].ToString();
        //    string contrasena = Session["Pass"].ToString();
        //    string nomBD = Session["NomBD"].ToString();

        //    GridViewRow fila = gvDatos.Rows[e.RowIndex];

        //    int id = Int32.Parse(((Label)(fila.FindControl("lbID"))).Text);
        //    string articulo = ((TextBox)(fila.FindControl("tbArticulo"))).Text;
        //    DropDownList ddlCla = (DropDownList)fila.FindControl("ddlClasificacion");
        //    string listaCla = ddlCla.SelectedItem.Text;
        //    DropDownList ddlUni = (DropDownList)fila.FindControl("ddlClasificacion");
        //    string ddlUnidad = ddlCla.SelectedItem.Text;
        //    int minimo = Int32.Parse(((TextBox)(fila.FindControl("tbMinimo"))).Text);
        //    DropDownList listaEDo = (DropDownList)fila.FindControl("ddlHabilitado");
        //    int habilitado = Convert.ToInt32(listaEDo.SelectedValue);
        //    string msg = "";

        //    try
        //    {
        //        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["strBodega"].ConnectionString);
        //        con = new SqlConnection(ConfigurationManager.ConnectionStrings[nomBD].ConnectionString + ";User ID=" + usuario + ";Password=" + contrasena);
        //        con.Open();
        //        string procAlm = "PA_Insertar_Actualiza_Articulo";
        //        SqlCommand cmd = new SqlCommand(procAlm, con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@id", id);
        //        cmd.Parameters.AddWithValue("@nombre", articulo);
        //        cmd.Parameters.AddWithValue("@descripcion", listaCla);
        //        cmd.Parameters.AddWithValue("@unidad", ddlUnidad);
        //        cmd.Parameters.AddWithValue("@minimo", minimo);
        //        cmd.Parameters.AddWithValue("@habilitado", habilitado);


        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }
        //    catch (SqlException ex)
        //    {
        //        msg = ex.Message;
        //    }

        //    gvDatos.EditIndex = -1;
        //    cargarGV();

        //    Session.Remove("Button1");
        //}

        //protected void btBuscar_Click(object sender, EventArgs e)
        //{
        //    string usuario = Session["usuario"].ToString();
        //    string contrasena = Session["Pass"].ToString();
        //    string nomBD = Session["NomBD"].ToString();

        //    string nomArti = tbBuscar.Text;
        //    DataTable dt = new DataTable();
        //    int num_reg;
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["strBodega"].ConnectionString);
        //    con = new SqlConnection(ConfigurationManager.ConnectionStrings[nomBD].ConnectionString + ";User ID=" + usuario + ";Password=" + contrasena);
        //    string procAlm = "pa_ConsultaArticulo_Mant";
        //    SqlCommand cmd = new SqlCommand(procAlm, con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    //cmd.Parameters.AddWithValue("@numrut", rutFun);
        //    cmd.Parameters.AddWithValue("@nombre", nomArti);
        //    con.Open();
        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //    num_reg = sda.Fill(dt);
        //    gvDatos.DataSource = dt;
        //    gvDatos.DataBind();
        //    con.Close();
        //}

        //protected void btGuardar_Click(object sender, EventArgs e)
        //{
        //    string nombre = tbAgregaArticulo.Text;
        //    int clasificacion = Convert.ToInt32(ddlAgreCla.SelectedValue);
        //    string unidad = ddlAgregarUnidad.Text;
        //    int minimo = Convert.ToInt32(tbAgregaMinimo.Text);
        //    int habilitado = Convert.ToInt32(DropDownList3.SelectedValue);
        //    int bodega = Convert.ToInt32(ddlAgreBodega.SelectedValue);

        //    string usuario = Session["usuario"].ToString();
        //    string contrasena = Session["Pass"].ToString();
        //    string nomBD = Session["NomBD"].ToString();

        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings[nomBD].ConnectionString + ";User ID=" + usuario + ";Password=" + contrasena);
        //    string procAlm = "pa_Inserta_Articulo_Art_Bodega";
        //    SqlCommand cmd = new SqlCommand(procAlm, con);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.AddWithValue("@nombre", nombre);
        //    cmd.Parameters.AddWithValue("@clasificacion", clasificacion);
        //    cmd.Parameters.AddWithValue("@unidad", unidad);
        //    cmd.Parameters.AddWithValue("@minimo", minimo);
        //    cmd.Parameters.AddWithValue("@habilitado", habilitado);
        //    cmd.Parameters.AddWithValue("@bodega", bodega);
        //    cmd.Parameters.AddWithValue("@articulo", 0);
        //    cmd.Parameters.AddWithValue("@ultimo_precio", 0);
        //    cmd.Parameters.AddWithValue("@tipo_codigo", 1);

        //    try
        //    {
        //        con.Open();
        //        int filasAfectadas = cmd.ExecuteNonQuery();
        //        if (filasAfectadas > 0)
        //        {
        //            divMensaje.Visible = true;
        //            divError.Visible = false;
        //            lbMensaje.Text = "Se ha hecho el registro con éxito";
        //        }
        //        else
        //        {
        //            divMensaje.Visible = false;
        //            divError.Visible = true;
        //            lbMensaje.Text = "Hubo un error al insertar los datos.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        divMensaje.Visible = false;
        //        divError.Visible = true;
        //        lbMensaje.Text = "Hubo un error al insertar los datos. Detalles: " + ex.Message;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}


    }
}