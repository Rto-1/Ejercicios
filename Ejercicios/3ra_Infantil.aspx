<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="3ra_Infantil.aspx.cs" Inherits="Ejercicios._3ra_Infantil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <div id="" class="container w-50">
        <div class="row justify-content-center">
            <div class="Pos p-5">
                <%--style="height: 400px; overflow: scroll"--%>
                <asp:GridView ID="gvDatos" runat="server" CssClass="table table-striped " DataKeyNames="ID" AutoGenerateColumns="False">
                    <Columns>
                        <%--<asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:Button Text="Editar" ID="Button1" runat="server" CommandName="Edit" class="btn btn-light btn-sm" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Button Text="Actualizar" ID="updatebutton" runat="server" CommandName="Update" class="btn btn-link btn-sm" />
                                <asp:Button Text="Cancelar" ID="cancelbutton" runat="server" CommandName="Cancel" class="btn btn-link btn-sm" />
                            </EditItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField ControlStyle-CssClass="text-center" HeaderText="Posición">
                            <ItemTemplate>
                                <asp:Label ID="lbId" runat="server" Text='<%# Eval("id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Equipo">
                            <ItemTemplate>
                                <asp:Label ID="lbArticulo" runat="server" Text='<%# Eval("nombre_equipo") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="tbArticulo" runat="server" Text='<%# Eval("nombres_equipo") %>' Width="150px" class="form-control" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderText="F. 1">
                            <ItemTemplate>
                                <asp:Label ID="lbClasificacion" runat="server" Text='<%# Eval("f_uno") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="tbArticulo" runat="server" Text='<%# Eval("f_uno") %>' class="form-control" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="F. 2">
                            <ItemTemplate>
                                <asp:Label ID="lbUnidad" runat="server" Text='<%# Eval("f_dos") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="tbArticulo" runat="server" Text='<%# Eval("f_dos") %>' class="form-control" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="F. 3">
                            <ItemTemplate>
                                <asp:Label ID="lbUnidad" runat="server" Text='<%# Eval("f_tres") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="tbArticulo" runat="server" Text='<%# Eval("f_tres") %>' class="form-control" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="F. 4">
                            <ItemTemplate>
                                <asp:Label ID="lbUnidad" runat="server" Text='<%# Eval("f_cuatro") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="tbArticulo" runat="server" Text='<%# Eval("f_cuatro") %>' class="form-control" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
