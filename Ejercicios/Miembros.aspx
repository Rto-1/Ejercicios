<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Miembros.aspx.cs" Inherits="Ejercicios.Miembros" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <main class="rto">
            <div class="container-fluid p-4">
                <nav class="navbar navbar-expand-lg navbar-dark bg-dark" style="border-radius: 10px;">
                    <div class="container">
                        <a class="navbar-brand" style="font-size: 30px" href="Miembros">Registro de Miembros</a>
                        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavM" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                            <span class="navbar-toggler-icon"></span>
                        </button>
                        <div class="collapse navbar-collapse" id="navbarNavM">
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
            </style>


            <div>
                <br />
            </div>

            <div class="container" id="">
                <div class="Ingreso card text-white ">
                    <h2 class="p-3">Ingreso de Jugadores</h2>
                    <div class="form-row m-3 align-content-between" style="clear: both">
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="lbAgregarArct" runat="server" Text="Nombres"></asp:Label>
                                <asp:TextBox ID="tbANombres" runat="server" CssClass="form-control" placeholder="Todos los Nombres"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="lbAgregarCla" runat="server" Text="Apellido paterno"></asp:Label>
                                <asp:TextBox ID="tbAPaterno" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="lbAgregarUni" runat="server" Text="Apellido materno"></asp:Label>
                                <asp:TextBox ID="tbAMaterno" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                            </div>
                            <br />
                        </div>
                    </div>
                    <div class="form-row m-3 align-content-between" style="clear: both">
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="Label2" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                                <asp:TextBox ID="tbANacimiento" runat="server" CssClass="form-control" placeholder="AAAA-MM-DD"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="lbAgregarMinimo" runat="server" Text="RUT"></asp:Label>
                                <asp:TextBox ID="tbARut" runat="server" CssClass="form-control" placeholder="11.111.111-1"></asp:TextBox>
                            </div>
                            <div class="col-md-3 ">
                                <asp:Label ID="Label1" runat="server" Text="Dirección"></asp:Label>
                                <asp:TextBox ID="tbADireccion" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="guardar col-md-3 text-center">
                                <br />
                                <asp:Button ID="Button3" runat="server" Text="Guardar" class="btn btn-dark" OnClick="btGuardar_Click" />
                                <%--<asp:Button ID="btLimpiar" runat="server" Text="Limpiar" class="btn btn-warning"/>--%>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <br />
                    </div>

                    <div class="alert alert-success" id="divMensaje" runat="server" visible="false" style="clear: both">
                        <button type="button" class="close" data-dismiss="alert">×</button><br>
                        <strong>
                            <asp:Label ID="lbMensaje" runat="server" /></strong>
                    </div>

                    <div class="alert alert-danger " id="divError" runat="server" visible="false" style="clear: both">
                        <button type="button" class="close" data-dismiss="alert">×</button><br>
                        <strong>
                            <asp:Label ID="lbError" runat="server" /></strong>
                    </div>
                </div>
            </div>

            <div class="container" id="">
                <div class="Ingreso card text-white ">
                    <h3 class="p-3">Realizar Carnet</h3>
                    <div class="form-row m-3 align-content-between" style="clear: both">
                        <div class="row">
                            <%--<div class="form-row">
                                <div class="col-md-12 text-center">
                                    <asp:Label runat="server" Text=""><strong>BUSCA JUGADOR POR SU ID</strong></asp:Label>
                                    <asp:TextBox ID="btnBuscar1" runat="server" Text="" />
                                    <asp:Button ID="btn1" runat="server" Text="Buscar" class="btn btn-primary" OnClick="btnBuscar_Click" />
                                    <asp:Button ID="Button4" runat="server" Text="Crear" class="btn btn-primary" OnClick="btnGenerarPDF_Click" />
                                </div>
                            </div>--%>
                            <div class="form-row border-1">
                                <div class="col-md-12 text-center">
                                    <asp:Label class="" ID="Label9" runat="server" Text="NOMBRE COMPLETO" Style="font-weight: bold;" Visible="false"></asp:Label>
                                </div>
                                <div class="nombre col-md-12 text-center">
                                    <asp:Label ID="lblNombre" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:Label ID="lbPaterno" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:Label ID="lbMaterno" runat="server" Text="" Visible="false"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col-md-12 text-center">
                                    <asp:Label ID="lbRut" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:Label ID="lbNacimiento" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:Label ID="lbDireccion" runat="server" Text="" Visible="false"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="Label10" runat="server" Text="Busca por el Rut"></asp:Label>
                                <asp:TextBox ID="btnBuscar" runat="server" CssClass="form-control" placeholder="Ingresa el Rut"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <br />
                                <asp:Button ID="Button5" runat="server" Text="Buscar" class="btn btn-dark" OnClick="btnBuscar_Click" />
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="Label3" runat="server" Text="Nombres"></asp:Label>
                                <asp:TextBox ID="tbNombre" runat="server" CssClass="form-control" placeholder="Todos los Nombres"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="Label4" runat="server" Text="Apellido paterno"></asp:Label>
                                <asp:TextBox ID="tbPaterno" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="Label5" runat="server" Text="Apellido materno"></asp:Label>
                                <asp:TextBox ID="tbMaterno" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <br />
                                <asp:Button ID="Button6" runat="server" Text="Crear Carnet" class="btn btn-dark" OnClick="btnGenerarPDF_Click" />
                            </div>
                        </div>
                    </div>
                    <%-- <div class="form-row m-3 align-content-between" style="clear: both">
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="Label6" runat="server" Text="Fecha de Nacimiento" Visible="false"></asp:Label>
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" placeholder="AAAA-MM-DD" Visible="false"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="Label7" runat="server" Text="RUT" Visible="false"></asp:Label>
                                <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" placeholder="11.111.111-1" Visible="false"></asp:TextBox>
                            </div>
                            <div class="col-md-3 ">
                                <asp:Label ID="Label8" runat="server" Text="Dirección" Visible="false"></asp:Label>
                                <asp:TextBox ID="TextBox6" runat="server" class="form-control" Visible="false"></asp:TextBox>
                            </div>
                            <div class="guardar col-md-3 text-center">
                                <br />
                                <asp:Button ID="Button2" runat="server" Text="Guardar" class="btn btn-dark" OnClick="btGuardar_Click" Visible="false" />
                                <asp:Button ID="btLimpiar" runat="server" Text="Limpiar" class="btn btn-warning"/>
                            </div>
                        </div>
                    </div> --%>
                </div>
            </div>


            <div class="container-fluid">
                <div class="grilla form-row p-5">
                    <div class="col-md-12 ">
                        <div class="table-responsive">
                            <asp:GridView ID="gvDatos" runat="server" CssClass="table table-striped" DataKeyNames="ID" AutoGenerateColumns="False" OnRowCancelingEdit="gvDatos_RowCancelingEdit" OnRowEditing="gvDatos_RowEditing" OnRowUpdating="gvDatos_RowUpdating">
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
                                        <%--<EditItemTemplate>
                                    <asp:TextBox ID="lbID" runat="server" Text='<%# Eval("id") %>' Width="150px" class="form-control" />
                                </EditItemTemplate>--%>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombres">
                                        <ItemTemplate>
                                            <asp:Label ID="lbNombre" runat="server" Text='<%# Eval("nombres") %>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbNombre" runat="server" Text='<%# Eval("nombres") %>' Width="150px" class="form-control" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Apellido paterno">
                                        <ItemTemplate>
                                            <asp:Label ID="lbPaterno" runat="server" Text='<%# Eval("paterno") %>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbPaterno" runat="server" Text='<%# Eval("paterno") %>' Width="150px" class="form-control" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Apellido Materno">
                                        <ItemTemplate>
                                            <asp:Label ID="lbMaterno" runat="server" Text='<%# Eval("materno") %>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbMaterno" runat="server" Text='<%# Eval("materno") %>' Width="150px" class="form-control" />
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
                                            <asp:Label ID="lbRut" runat="server" Text='<%# Eval("rut") %>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbRut" runat="server" Text='<%# Eval("rut") %>' Width="150px" class="form-control" />
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
