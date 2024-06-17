<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="tablaSuperSeniors.aspx.cs" Inherits="Ejercicios.tablaSuperSeniors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" rel="stylesheet">   

  <div class="container-fluid bg-light d-flex justify-content-center align-items-center" style="min-height: 50vh;">
      <div class="grilla form-row p-5 ">
          <div class="col-md-12 ">
              <div class="table-responsive justify-content-center align-items-center">
                  <h3 class="text-center p-3">Super Seniors
                  </h3>
                  <asp:GridView ID="gvDatos" runat="server" CssClass="table table-striped" DataKeyNames="ID" AutoGenerateColumns="False">
                      <Columns>                            
                          <asp:TemplateField HeaderText="Ps">
                              <ItemTemplate>
                                  <asp:Label ID="lbId" runat="server" Text='<%# Eval("ID") %>' />
                              </ItemTemplate>                  
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Equipo">
                              <ItemTemplate>
                                  <asp:Label ID="lbPaterno" runat="server" Text='<%# Eval("Equipo") %>' />
                              </ItemTemplate>
                              <EditItemTemplate>
                                  <asp:TextBox ID="tbPaterno" runat="server" Text='<%# Eval("Equipo") %>' Width="150px" class="form-control" />
                              </EditItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Puntos">
                              <ItemTemplate>
                                  <asp:Label ID="lbMaterno" runat="server" Text='<%# Eval("Puntos") %>' />
                              </ItemTemplate>
                              <EditItemTemplate>
                                  <asp:TextBox ID="tbMaterno" runat="server" Text='<%# Eval("Puntos") %>' Width="150px" class="form-control" />
                              </EditItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="PJ">
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
                          </asp:TemplateField>
                      </Columns>
                  </asp:GridView>
              </div>
          </div>
      </div>
  </div>

</asp:Content>
