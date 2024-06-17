﻿using System;
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
    public partial class TSuperSeniors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarGV();
        }

        public void cargarGV()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringPosiciones"].ConnectionString;

            using (SqlConnection sqlConectar = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[spSuperSeniors]", sqlConectar))
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
    }
}