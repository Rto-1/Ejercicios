<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ejercicios.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <html xmlns="http://www.w3.org/1999/xhtml">

    <body>

        <style>
            .formulario {
                width: 300px;
                margin: 0 auto;
                padding: 10px;
                border: 1px solid #ccc;
                border-radius: 5px;
                background-color: #f9f9f9;
            }

                .formulario div {
                    margin-bottom: 10px;
                }

                .formulario label {
                    display: block;
                    font-weight: bold;
                }

                .formulario input[type="text"], .formulario input[type="password"] {
                    width: 100%;
                    padding: 5px;
                    border: 1px solid #ccc;
                    border-radius: 5px;
                }

                .formulario input[type="submit"] {
                    width: 50%;
                    margin: 0 auto;
                    padding: 5px;
                    border: 1px solid #ccc;
                    border-radius: 5px;
                    background-color: #f9f9f9;
                    cursor: pointer;
                }

                    .formulario input[type="submit"]:hover {
                        background-color: #f0f0f0;
                    }

            .Bienvenido {
                text-align: center;
                font-size: 20px;
                font-weight: bold;
                color: #333;
            }
        </style>

        <div class="container align-content-center" style="height: 30rem">
            <div class="formulario">
                <div class="formulario_login" id="formulario_login" runat="server">
                    <div>
                        <h5 class="Bienvenido">
                            <label for="txt_nombre">Bienvenido/a al Sistema</label>
                        </h5>
                    </div>
                    <div>
                        <label for="txt_usuario">Usuario:</label>
                        <input type="text" id="tbUsuario" name="txt_usuario" runat="server" />
                    </div>
                    <div>
                        <label for="txt_password">Contraseña:</label>
                        <input type="password" id="tbPassword" name="txt_password" runat="server" />
                    </div>
                    <div>
                        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="row">
                        <asp:Button ID="BtnIngresar" CssClass="btn btn-primary btn-dark text-dark" runat="server" Text="Iniciar sesión" OnClick="BtnIngresarClick" />
                        <%--                <input type="submit" id="btn_login1" name="btn_login" value="Iniciar sesión" runat="server" />--%>
                    </div>
                </div>
            </div>
        </div>

    </body>
    </html>
</asp:Content>
