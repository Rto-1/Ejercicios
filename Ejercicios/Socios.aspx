<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Socios.aspx.cs" Inherits="Ejercicios.Socios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel runat="server">
        <div class="col-md-12">
            <div class="col-md-2">
            </div>
            <div class="col-md-8">
                <a href="Mantenedor.aspx">
                    <input type="button" class="btn btn-primary btn-block" value="Volver a Mantenedor"></a>
            </div>
            <div class="col-md-2">
            </div>
        </div>

        <div class="col-md-12">
            <br />
        </div>

        <div class="col-md-12">
            <div class="col-md-2">
            </div>
            <div class="col-md-8">
                <button class="btn btn-primary btn-block" type="button" data-toggle="collapse" data-target="#collapseExample" aria-expanded="false" aria-controls="collapseExample">
                    Agregar artículo
                </button>
            </div>
            <div class="col-md-2">
            </div>
        </div>
        <div class="collapse" id="collapseExample">
            <div class="card card-body">
                <div class="col-md-12">
                    <br />
                </div>
                <div class="form-row" style="clear: both">
                    <div class="col-md-4">
                        <asp:Label ID="lbAgregarArct" runat="server" Text="Artículo"></asp:Label>
                        <asp:TextBox ID="tbAgregaArticulo" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="lbAgregarCla" runat="server" Text="Clasificación"></asp:Label>
                        <asp:DropDownList ID="ddlAgreCla" runat="server" class="form-control"></asp:DropDownList>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="lbAgregarUni" runat="server" Text="Unidad"></asp:Label>
                        <asp:DropDownList ID="ddlAgregarUnidad" runat="server" class="form-control"></asp:DropDownList>
                    </div>
                    <br />
                </div>

                <div class="col-md-12">
                    <br />
                </div>

                <div class="form-row" style="clear: both">
                    <div class="col-md-3">
                        <asp:Label ID="lbAgregarMinimo" runat="server" Text="Mínimo"></asp:Label>
                        <asp:TextBox ID="tbAgregaMinimo" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="lbAgregarHabi" runat="server" Text="Habilitado"></asp:Label>
                        <asp:DropDownList ID="DropDownList3" runat="server" class="form-control">
                            <asp:ListItem Value="-1">Seleccione..</asp:ListItem>
                            <asp:ListItem Value="1">Habilitado</asp:ListItem>
                            <asp:ListItem Value="0">Deshabilitado</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="Label1" runat="server" Text="Bodega"></asp:Label>
                        <asp:DropDownList ID="ddlAgreBodega" runat="server" class="form-control" />
                    </div>
                    <div class="col-md-1 text-right">
                        <br />
                        <asp:Button ID="Button3" runat="server" Text="Guardar" class="btn btn-primary" OnClick="btGuardar_Click" />
                        <%--<asp:Button ID="btLimpiar" runat="server" Text="Limpiar" class="btn btn-warning"/>--%>
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

        <div class="col-md-12">
            <br />
        </div>

        <div class="col-md-12">
            <div class="col-md-2">
            </div>
            <div class="col-md-8">
                <button class="btn btn-primary btn-block" type="button" data-toggle="collapse" data-target="#collapseExample1" aria-expanded="false" aria-controls="collapseExample">
                    Buscar artículo
                </button>
            </div>
            <div class="col-md-2">
            </div>
        </div>
        <div class="collapse" id="collapseExample1">
            <div class="card card-body">
                <div class="col-md-12">
                    <br />
                </div>
                <div class="form-row" style="clear: both">
                    <div class="col-md-12 text-center">
                        <asp:Label runat="server" Text=""><strong>Busca por nombre de artículo</strong></asp:Label>
                        <asp:TextBox ID="tbBuscar" runat="server" Text="" />
                        <asp:Button ID="button2" runat="server" Text="Buscar" class="btn btn-primary" OnClick="btBuscar_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-12">
            <br />
        </div>

        <div class="form-row">
            <div class="col-md-12">
                <%--style="height: 400px; overflow: scroll"--%>
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
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Articulo">
                            <ItemTemplate>
                                <asp:Label ID="lbArticulo" runat="server" Text='<%# Eval("nombre") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="tbArticulo" runat="server" Text='<%# Eval("nombre") %>' Width="250px" class="form-control" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Clasificación">
                            <ItemTemplate>
                                <asp:Label ID="lbClasificacion" runat="server" Text='<%# Eval("descripcion") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lbClasifica" runat="server" Text='<%# Eval("descripcion") %>' Visible="false" />
                                <asp:DropDownList ID="ddlClasificacion" runat="server" class="form-control"></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unidad">
                            <ItemTemplate>
                                <asp:Label ID="lbUnidad" runat="server" Text='<%# Eval("unidad") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lbUni" runat="server" Text='<%# Eval("unidad") %>' Visible="false" />
                                <asp:DropDownList ID="ddlUnidad" runat="server" class="form-control"></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Stock">
                            <ItemTemplate>
                                <asp:Label ID="lbStock" runat="server" Text='<%# Eval("stock") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mínimo">
                            <ItemTemplate>
                                <asp:Label ID="lbMinimo" runat="server" Text='<%# Eval("minimo") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="tbMinimo" runat="server" Text='<%# Eval("minimo") %>' Width="50px" class="form-control" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Habilitado">
                            <ItemTemplate>
                                <asp:Label ID="lbHabil" runat="server" Text='<%# Eval("habilitado").ToString() == "True" ? "Habilitado" : "deshabilitado" %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlHabilitado" runat="server" class="form-control">
                                    <%--SelectedValue='<%# Eval("p_estado").ToString() == "1" ? "1": Eval("p_estado").ToString() %>'--%>
                                    <asp:ListItem Value="-1">Seleccione..</asp:ListItem>
                                    <asp:ListItem Value="1">Habilitado</asp:ListItem>
                                    <asp:ListItem Value="0">Deshabilitado</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
