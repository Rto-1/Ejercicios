<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="true" CodeBehind="Carnet.aspx.cs" Inherits="Ejercicios.Carnet" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <style>
        .form-container {
            margin-top: 20px;
        }

        .form-row {
            margin-bottom: 10px;
        }

        .col-md-12 {
            width: 100%;
        }

        .text-center {
            text-align: center;
        }

        .btn {
            display: inline-block;
            padding: 8px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            text-align: center;
            text-decoration: none;
            outline: none;
        }

        .btn-primary {
            background-color: #007bff;
            color: #fff;
        }

            .btn-primary:hover {
                background-color: #0056b3;
            }
    </style>

    <div class="row p-4">
        <div class="col-sm-12 mb-3 mb-sm-0">
            <div class="card">
                <div class="card-body">
                    <div class="form-container">
                        <div class="col-md-12 text-center pb-3">
                            <h1>BUSCA JUGADOR Y CREAR SU CARNET</h1>
                        </div>
                        <div class="form-row">
                            <div class="col-md-12 text-center">
                                <asp:Label runat="server" Text=""><strong>BUSCA JUGADOR POR SU ID</strong></asp:Label>
                                <asp:TextBox ID="btnBuscar" runat="server" Text="" />
                                <asp:Button ID="btn1" runat="server" Text="Buscar" class="btn btn-primary" OnClick="btnBuscar_Click" />
                                <asp:Button ID="Button3" runat="server" Text="Crear" class="btn btn-primary" OnClick="btnGenerarPDF_Click" />
                            </div>
                        </div>
                        <div class="form-row border-1">
                            <div class="col-md-12 text-center">
                                <asp:Label class="" ID="Label2" runat="server" Text="NOMBRE COMPLETO" Style="font-weight: bold;"></asp:Label>
                            </div>
                            <div class="nombre col-md-12 text-center">
                                <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lbPaterno" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lbMaterno" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col-md-12 text-center">
                                <asp:Label ID="lbRut" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="lbNacimiento" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="lbDireccion" runat="server" Text="" Visible="false"></asp:Label>
                            </div>
                        </div>
                    </div>


                </div>
            </div>
        </div>
    </div>
</asp:Content>
