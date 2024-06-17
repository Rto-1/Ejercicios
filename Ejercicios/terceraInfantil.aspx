<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="terceraInfantil.aspx.cs" Inherits="Ejercicios.terceraInfantil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <main>
            <div class="container-fluid pt-4">
                <nav class="navbar navbar-expand-lg navbar-dark bg-dark" style="border-radius: 10px;">
                    <div class="container">
                        <a class="navbar-brand" style="font-size: 30px" href="Miembros">Registro de Miembros</a>
                        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavS" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                            <span class="navbar-toggler-icon"></span>
                        </button>
                        <div class="collapse navbar-collapse" id="navbarNavS">
                            <ul class="navbar-nav ms-auto">
                                <li class="nav-item"><a class="nav-link" href="terceraInfantil">3ra Infantil</a></li>
                                <li class="nav-item"><a class="nav-link" href="segundaInfantil">2da Infantil</a></li>
                                <li class="nav-item"><a class="nav-link" href="primeraInfantil">1ra Infantil</a></li>
                                <li class="nav-item"><a class="nav-link" href="seniors">Seniors</a></li>
                                <li class="nav-item"><a class="nav-link" href="superSeniors">Super Seniors</a></li>
                                <li class="nav-item"><a class="nav-link" href="dorados">Dorados</a></li>
                                <li class="nav-item"><a class="nav-link" href="terceraAdulto">3ra Adulto</a></li>
                                <li class="nav-item"><a class="nav-link" href="segundaAdulto">2da Adulto</a></li>
                                <li class="nav-item"><a class="nav-link" href="primeraAdulto">1ra Adulto</a></li>
                            </ul>
                        </div>
                    </div>
                </nav>
            </div>

            <style>
                .titulo {
                    background-color: #0B5345;
                    border-radius: 10px;
                    margin: 20px;
                }

                .main {
                    margin: 0;
                    padding: 100px;
                    padding-top: 20px;
                    background-color: #094136;
                }

                .Ingreso {
                    background-color: #0B5345;
                    border-radius: 10px;
                    padding: 20px;
                    margin: 20px;
                }

                .grilla {
                    background-color: #EDF9ED;
                    border-radius: 10px;
                    padding: 20px;
                    margin: 20px;
                }

                .table-responsive {
                    overflow-x: auto;
                }

                .table {
                    width: 100%;
                    min-width: 600px;
                }
            </style>

            <div class="titulo card text-white">
                <div class="form-row m-3 align-content-between">
                    <div class="row">
                        <h3>Tercera Infantil</h3>
                    </div>
                </div>
            </div>

            <div class="container-fluid">
                <div class="grilla row">
                    <div class="col-12">
                        <div class="table-responsive">
                            <asp:GridView ID="gvDatos" runat="server" CssClass="table table-striped" DataKeyNames="ID" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField HeaderText="Acciones">
                                        <ItemTemplate>
                                            <asp:Button Text="Editar" ID="Button1" runat="server" CommandName="Edit" class="btn btn-light btn-sm" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Button Text="Actualizar" ID="updatebutton" runat="server" CommandName="Update" class="btn btn-link btn-sm" />
                                            <asp:Button Text="Cancelar" ID="cancelbutton" runat="server" CommandName="Cancel" class="btn btn-link btn-sm" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lbId" runat="server" Text='<%# Eval("id") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombres">
                                        <ItemTemplate>
                                            <asp:Label ID="lbArticulo" runat="server" Text='<%# Eval("nombres") %>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbArticulo" runat="server" Text='<%# Eval("nombres") %>' Width="150px" class="form-control" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Apellido paterno">
                                        <ItemTemplate>
                                            <asp:Label ID="lbClasificacion" runat="server" Text='<%# Eval("paterno") %>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbClasificacion" runat="server" Text='<%# Eval("paterno") %>' Width="150px" class="form-control" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Apellido Materno">
                                        <ItemTemplate>
                                            <asp:Label ID="lbUnidad" runat="server" Text='<%# Eval("materno") %>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbUnidad" runat="server" Text='<%# Eval("materno") %>' Width="150px" class="form-control" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha nacimiento">
                                        <ItemTemplate>
                                            <asp:Label ID="lbNacimiento" runat="server" Text='<%# Eval("nacimiento") %>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbNacimiento" runat="server" Text='<%# Eval("nacimiento") %>' Width="150px" class="form-control" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="RUT">
                                        <ItemTemplate>
                                            <asp:Label ID="lbRUT" runat="server" Text='<%# Eval("rut") %>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbRUT" runat="server" Text='<%# Eval("rut") %>' Width="150px" class="form-control" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dirección">
                                        <ItemTemplate>
                                            <asp:Label ID="lbDireccion" runat="server" Text='<%# Eval("direccion") %>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbDireccion" runat="server" Text='<%# Eval("direccion") %>' Width="150px" class="form-control" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </main>
</asp:Content>





