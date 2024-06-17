using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Ejercicios
{
    public partial class PiePagina : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=RTO;Initial Catalog=Miramontes;User ID=sa;Password=123456;Encrypt=False";
            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                Font Font7 = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 7, iTextSharp.text.Font.NORMAL));
                Font Font8 = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.NORMAL));
                Font FontB8 = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.BOLD));
                Font FontB9 = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.BOLD));
                Font Font9 = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.NORMAL));
                Font FontB10 = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.BOLD));
                Font Font12 = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.Font.BOLD));
                Font Font6_pie = new Font(FontFactory.GetFont(FontFactory.TIMES, 6, iTextSharp.text.Font.NORMAL));
                Font FontB12_pie = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.Font.BOLD, new BaseColor(12, 119, 157)));
                Font Font32 = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 32, iTextSharp.text.Font.BOLD));
                Font FontB8_text = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.BOLD, new BaseColor(255, 255, 255)));
                Font FontB7_text = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 6, iTextSharp.text.Font.BOLD, new BaseColor(255, 255, 255)));




                string rut = "";
                string nacimiento = "";
                string nombres = "";
                string paterno = "";
                string materno = "";

                string directorio_pdf = "~/carnetPDF/";
                string nombre_archivo_pdf = directorio_pdf + "Reporte_Prod_Ped_Entreg.pdf";
                string FicheroPDF = Server.MapPath(nombre_archivo_pdf);

                // Nombre del procedimiento almacenado
                string procedureName = "sp_Miramontes";

                // Crear el comando para ejecutar el procedimiento almacenado
                SqlCommand command = new SqlCommand(procedureName, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Abre la conexión
                connection.Open();

                // Ejecutar el comando y obtener un SqlDataReader
                SqlDataReader reader = command.ExecuteReader();

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

                string imagenURL = "./images/miramontes.png";
                iTextSharp.text.Image imagenJPG;
                imagenJPG = iTextSharp.text.Image.GetInstance(Server.MapPath(imagenURL));
                imagenJPG.ScaleToFit(60.0F, 60.0F);
                imagenJPG.SpacingBefore = 10.0F;
                imagenJPG.SpacingAfter = 5.0F;
                imagenJPG.SetAbsolutePosition(50, 735);
                documentoPDF.Add(imagenJPG);

                string categoria = "Carnet Jugador";
                string titulo = "Club Deportivo Miramontes";

                PdfPTable Tabla1 = new PdfPTable(2);
                Tabla1.WidthPercentage = 95;

                Tabla1.AddCell(new PdfPCell(new Phrase(" ", Font12)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP, Rowspan = 3 });
                Tabla1.AddCell(new PdfPCell(new Phrase(titulo, Font12)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                Tabla1.AddCell(new PdfPCell(new Phrase(categoria, Font8)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                Tabla1.AddCell(new PdfPCell(new Phrase(" ", Font12)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_TOP, Rowspan = 3 });

                documentoPDF.Add(new Paragraph(" "));

                PdfPTable Tabla3 = new PdfPTable(10);
                float[] ancho2 = new float[] { 20.0F, 10.0F, 20.0F, 9.0F, 16.0F, 5.0F, 5.0F, 5.0F, 5.0F, 5.0F };
                Tabla3.WidthPercentage = 95;
                Tabla3.SetWidths(ancho2);

                while (reader.Read())
                {
                    rut = reader["rut"].ToString();
                    nacimiento = reader["nacimiento"].ToString();
                    nombres = reader["nombres"].ToString();
                    paterno = reader["paterno"].ToString();
                    materno = reader["materno"].ToString();

                }
                Tabla3.AddCell(new PdfPCell(new Phrase("COMPROBANTE TRÁMITE JUGADOR – ADFLC\"", FontB8_text)) { BackgroundColor = new BaseColor(120, 120, 120), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 3 });
                Tabla3.AddCell(new PdfPCell(new Phrase("- SOLO VÁLIDO EN AÑO 2024-2027-", FontB8_text)) { BackgroundColor = new BaseColor(120, 120, 120), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 7 });

                Tabla3.AddCell(new PdfPCell(new Phrase(nombres + " " + paterno + " " + materno, Font9)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Colspan =10});
                documentoPDF.Add(new Paragraph(" "));

                // Agregar la tabla al documento
                documentoPDF.Add(Tabla1);
                documentoPDF.Add(Tabla3);

                // Cerrar el documento y liberar los recursos
                documentoPDF.Close();
                reader.Close();
                connection.Close();
            }
            var pathCorto = "carnetPDF/Reporte_Prod_Ped_Entreg.pdf";
            StringBuilder cstext2 = new StringBuilder();
            cstext2.Append("<script language=javascript>");
            cstext2.Append("window.open('" + pathCorto + "','_blank','scrollbars=yes,width=800px,height=600px,top=50px, left=10px,toolbar=yes,menubar=yes,location=no,location=0')");
            cstext2.Append("</script>");
            ClientScript.RegisterStartupScript(Page.GetType(), "BlahBlah", cstext2.ToString());

        }
    }
}