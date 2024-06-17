<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TGeneral.aspx.cs" Inherits="Ejercicios.TGeneral" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" rel="stylesheet">

    <style>
        .table-striped.table {
            background-color: white;
            color: black;
        }

            .table-striped.table th,
            .table-striped.table td {
                background-color: white;
                color: black;
            }
    </style>

    <div class="bg-black" style="background-color: black">
        <div class="p-4">
            <nav class="navbar navbar-expand-lg navbar-dark bg-dark" style="border-radius: 10px;">
                <div class="container">
                    <a class="navbar-brand" style="font-size: 20px" runat="server" href="~/Default">Tabla de Posiciones</a>
                    <button type="button" class="navbar-toggler" data-bs-toggle="collapse" data-bs-target="#navbarNavD" title="Alternar navegación" aria-controls="navbarSupportedContent"
                        aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse d-sm-inline-flex justify-content-between align-middle" id="navbarNavD">
                        <ul class="navbar-nav flex-grow-3">
                            <li class="nav-item"><a class="nav-link" runat="server" href="~/"></a></li>
                            <li class="nav-item"><a class="nav-link" runat="server" href="~/TTInfantil">3ra Infantil</a></li>
                            <li class="nav-item"><a class="nav-link" runat="server" href="~/TSInfantil">2da Infantil</a></li>
                            <li class="nav-item"><a class="nav-link" runat="server" href="~/TPInfantil">1ra Infantil</a></li>
                            <li class="nav-item"><a class="nav-link" runat="server" href="~/TSeniors">Seniors</a></li>
                            <li class="nav-item"><a class="nav-link" runat="server" href="~/TSuperSeniors">Super Seniors</a></li>
                            <li class="nav-item"><a class="nav-link" runat="server" href="~/TDorados">Dorados</a></li>
                            <li class="nav-item"><a class="nav-link" runat="server" href="~/TTAdulto">3ra Adulto</a></li>
                            <li class="nav-item"><a class="nav-link" runat="server" href="~/TSAdulto">2da Adulto</a></li>
                            <li class="nav-item"><a class="nav-link" runat="server" href="~/TPAdulto">1ra Adulto</a></li>
                            <li class="nav-item"><a class="nav-link" runat="server" href="~/TGeneral">General</a></li>
                        </ul>
                    </div>
                </div>
            </nav>
        </div>

        <div class="container-fluid d-flex justify-content-center align-items-center">
            <div class="grilla form-row text-white">
                <div class="col-md-12 ">
                    <div class="table-responsive justify-content-center align-items-center">
                        <h3 class="text-center text-white p-3">General
                        </h3>
                        <asp:GridView ID="gvDatos" runat="server" CssClass="table table-striped" DataKeyNames="ID" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Pos">
                                    <ItemTemplate>
                                        <asp:Label ID="lbId" runat="server" Text='<%# Eval("ID") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Club">
                                    <ItemTemplate>
                                        <asp:Label ID="lbPaterno" runat="server" Text='<%# Eval("Equipo") %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="tbPaterno" runat="server" Text='<%# Eval("Equipo") %>' Width="150px" class="form-control" />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Puntos" ControlStyle-Font-Bold="true" ItemStyle-CssClass ="text-center">
                                    <ItemTemplate>
                                        <asp:Label ID="lbMaterno" runat="server" Text='<%# Eval("TotalPuntos") %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="tbMaterno" runat="server" Text='<%# Eval("TotalPuntos") %>' Width="150px" class="form-control" />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                              <%--  <asp:TemplateField HeaderText="PJ">
                                    <ItemTemplate>
                                        <asp:Label ID="lbNacimiento" runat="server" Text='<%# Eval("PJ") %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="tbNacimiento" runat="server" Text='<%# Eval("PJ") %>' Width="150px" class="form-control" />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PG">
                                    <ItemTemplate>
                                        <asp:Label ID="lbRut" runat="server" Text='<%# Eval("PG") %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="tbRut" runat="server" Text='<%# Eval("PG") %>' Width="150px" class="form-control" />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PP">
                                    <ItemTemplate>
                                        <asp:Label ID="lbDireccion" runat="server" Text='<%# Eval("PP") %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="tbDireccion" runat="server" Text='<%# Eval("PP") %>' Width="150px" class="form-control" />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DG">
                                    <ItemTemplate>
                                        <asp:Label ID="lbDireccion" runat="server" Text='<%# Eval("DG") %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="tbDireccion" runat="server" Text='<%# Eval("DG") %>' Width="150px" class="form-control" />
                                    </EditItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
