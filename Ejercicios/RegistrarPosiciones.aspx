<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarPosiciones.aspx.cs" Inherits="Ejercicios.RegistrarPosiciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" rel="stylesheet">

    <div class="p-2" id="Div1" runat="server">
        <div class="bg-light p-4">
            <h2>Registrar Todas las Series</h2>
            <div class="form-row" style="clear: both">
                <div class="col-md-4">
                    <asp:Label ID="Label3" runat="server" Text="Numero de fecha"></asp:Label>
                    <%--<select id="ddlFecha" class="form-select" aria-label="Default select example"></select>--%>
                    <asp:DropDownList ID="ddlFecha" runat="server" class="form-control">
                        <asp:ListItem Value="-1">Seleccione..</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="11">11</asp:ListItem>
                        <asp:ListItem Value="12">12</asp:ListItem>
                        <asp:ListItem Value="13">13</asp:ListItem>
                        <asp:ListItem Value="14">14</asp:ListItem>
                        <asp:ListItem Value="15">15</asp:ListItem>
                        <asp:ListItem Value="16">16</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label4" runat="server" Text="Equipo Local"></asp:Label>
                    <asp:DropDownList ID="ddlLocal" runat="server" class="form-control">
                        <asp:ListItem Value="-1">Seleccione..</asp:ListItem>
                        <asp:ListItem Value="1">Miramontes</asp:ListItem>
                        <asp:ListItem Value="2">Manuel Rodiguez</asp:ListItem>
                        <asp:ListItem Value="3">Unión los Saldes</asp:ListItem>
                        <asp:ListItem Value="4">Municipal las Condes</asp:ListItem>
                        <asp:ListItem Value="5">Porvenir</asp:ListItem>
                        <asp:ListItem Value="6">Los Condores</asp:ListItem>
                        <asp:ListItem Value="7">Botafogo</asp:ListItem>
                        <asp:ListItem Value="8">Bello Horizonte</asp:ListItem>
                        <asp:ListItem Value="9">Cooperativa Apoquindo</asp:ListItem>
                        <asp:ListItem Value="10">Coipina Unida</asp:ListItem>
                        <asp:ListItem Value="11">Villa Barcelona</asp:ListItem>
                        <asp:ListItem Value="12">Unión Rivadavia</asp:ListItem>
                        <asp:ListItem Value="13">Vicente Martinez</asp:ListItem>
                        <asp:ListItem Value="14">Unión Colón</asp:ListItem>
                        <asp:ListItem Value="15">Estrella Vitacura</asp:ListItem>
                        <asp:ListItem Value="16">Vital Apoquindo</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label5" runat="server" Text="Equipo Visita"></asp:Label>
                    <asp:DropDownList ID="ddlVisita" runat="server" class="form-control">
                        <asp:ListItem Value="-1">Seleccione..</asp:ListItem>
                        <asp:ListItem Value="1">Miramontes</asp:ListItem>
                        <asp:ListItem Value="2">Manuel Rodiguez</asp:ListItem>
                        <asp:ListItem Value="3">Los Saldes</asp:ListItem>
                        <asp:ListItem Value="4">Municipal las Condes</asp:ListItem>
                        <asp:ListItem Value="5">Porvenir</asp:ListItem>
                        <asp:ListItem Value="6">Los Condores</asp:ListItem>
                        <asp:ListItem Value="7">Botafogo</asp:ListItem>
                        <asp:ListItem Value="8">Bello Horizonte</asp:ListItem>
                        <asp:ListItem Value="9">Cooperativa Apoquindo</asp:ListItem>
                        <asp:ListItem Value="10">Coipina Unida</asp:ListItem>
                        <asp:ListItem Value="11">Villa Barcelona</asp:ListItem>
                        <asp:ListItem Value="12">Unión Rivadavia</asp:ListItem>
                        <asp:ListItem Value="13">Vicente Martinez</asp:ListItem>
                        <asp:ListItem Value="14">Unión Colón</asp:ListItem>
                        <asp:ListItem Value="15">Estrella Vitacura</asp:ListItem>
                        <asp:ListItem Value="16">Vital Apoquindo</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div>
                <br />
            </div>
            <div class="form-row" style="clear: both">
                <div class="col-md-4">
                    <asp:Label ID="Label6" runat="server" Text="Serie"></asp:Label>
                    <asp:DropDownList ID="ddlSerie" runat="server" class="form-control">
                        <asp:ListItem Value="-1">Seleccione..</asp:ListItem>                        
                        <asp:ListItem Value="2">Segunda Infantil</asp:ListItem>
                        <asp:ListItem Value="3">Primera Infantil</asp:ListItem>
                        <asp:ListItem Value="4">Tercera Adulto</asp:ListItem>
                        <asp:ListItem Value="5">Segunda Adulto</asp:ListItem>
                        <asp:ListItem Value="6">Primera Adulto</asp:ListItem>
                        <asp:ListItem Value="7">Seniors</asp:ListItem>
                        <asp:ListItem Value="8">Super Seniors</asp:ListItem>
                        <asp:ListItem Value="9">Dorados</asp:ListItem>
                        <asp:ListItem Value="10">Diamantes</asp:ListItem>
                        <asp:ListItem Value="11">Femenino</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lbGolLocal" runat="server" Text="Goles Equipo Local"></asp:Label>
                    <asp:TextBox ID="tbGolLocal" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lbGolVisita" runat="server" Text="Goles Equipo Visita"></asp:Label>
                    <asp:TextBox ID="tbGolVisita" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div>
                <br />
            </div>
            <div class=" boton form-row" style="clear: both">
                <div class="col-12 text-center">
                    <asp:Button ID="Button1" runat="server" Text="Registrar" OnClick="btnRegistra_Click" /><br />
                </div>
            </div>
        </div>
    </div>
  
    <div class="p-2" id="row" runat="server">
        <div class="bg-light p-4">
            <h2>Registrar Tercera Infantil</h2>
            <div class="form-row" style="clear: both">
                <div class="col-md-4">
                    <asp:Label ID="Label1" runat="server" Text="Numero de fecha"></asp:Label>
                    <%--<select id="ddlFecha" class="form-select" aria-label="Default select example"></select>--%>
                    <asp:DropDownList ID="ddlFecha1" runat="server" class="form-control">
                        <asp:ListItem Value="-1">Seleccione..</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="11">11</asp:ListItem>
                        <asp:ListItem Value="12">12</asp:ListItem>
                        <asp:ListItem Value="13">13</asp:ListItem>
                        <asp:ListItem Value="14">14</asp:ListItem>
                        <asp:ListItem Value="15">15</asp:ListItem>
                        <asp:ListItem Value="16">16</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lbAgregarCla" runat="server" Text="Equipo Local"></asp:Label>
                    <asp:DropDownList ID="ddlLocal1" runat="server" class="form-control">
                        <asp:ListItem Value="-1">Seleccione..</asp:ListItem>
                        <asp:ListItem Value="1">Miramontes</asp:ListItem>
                        <asp:ListItem Value="2">Manuel Rodiguez</asp:ListItem>
                        <asp:ListItem Value="3">Los Saldes</asp:ListItem>
                        <asp:ListItem Value="4">Municipal las Condes</asp:ListItem>
                        <asp:ListItem Value="5">Porvenir</asp:ListItem>
                        <asp:ListItem Value="6">Los Condores</asp:ListItem>
                        <asp:ListItem Value="7">Botafogo</asp:ListItem>
                        <asp:ListItem Value="8">Bello Horizonte</asp:ListItem>
                        <asp:ListItem Value="9">Cooperativa Apoquindo</asp:ListItem>
                        <asp:ListItem Value="10">Coipina Unida</asp:ListItem>
                        <asp:ListItem Value="11">Villa Barcelona</asp:ListItem>
                        <asp:ListItem Value="12">Unión Rivadavia</asp:ListItem>
                        <asp:ListItem Value="13">Vicente Martinez</asp:ListItem>
                        <asp:ListItem Value="14">Unión Colón</asp:ListItem>
                        <asp:ListItem Value="15">Estrella Vitacura</asp:ListItem>
                        <asp:ListItem Value="16">Vital Apoquindo</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lbAgregarUni" runat="server" Text="Equipo Visita"></asp:Label>
                    <asp:DropDownList ID="ddlVisita1" runat="server" class="form-control">
                        <asp:ListItem Value="-1">Seleccione..</asp:ListItem>
                        <asp:ListItem Value="1">Miramontes</asp:ListItem>
                        <asp:ListItem Value="2">Manuel Rodiguez</asp:ListItem>
                        <asp:ListItem Value="3">Los Saldes</asp:ListItem>
                        <asp:ListItem Value="4">Municipal las Condes</asp:ListItem>
                        <asp:ListItem Value="5">Porvenir</asp:ListItem>
                        <asp:ListItem Value="6">Los Condores</asp:ListItem>
                        <asp:ListItem Value="7">Botafogo</asp:ListItem>
                        <asp:ListItem Value="8">Bello Horizonte</asp:ListItem>
                        <asp:ListItem Value="9">Cooperativa Apoquindo</asp:ListItem>
                        <asp:ListItem Value="10">Coipina Unida</asp:ListItem>
                        <asp:ListItem Value="11">Villa Barcelona</asp:ListItem>
                        <asp:ListItem Value="12">Unión Rivadavia</asp:ListItem>
                        <asp:ListItem Value="13">Vicente Martinez</asp:ListItem>
                        <asp:ListItem Value="14">Unión Colón</asp:ListItem>
                        <asp:ListItem Value="15">Estrella Vitacura</asp:ListItem>
                        <asp:ListItem Value="16">Vital Apoquindo</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div>
                <br />
            </div>
            <div class="form-row" style="clear: both">
                <div class="col-md-4">
                    <asp:Label ID="Label2" runat="server" Text="Serie"></asp:Label>
                    <asp:DropDownList ID="ddlSerie1" runat="server" class="form-control">
                        <asp:ListItem Value="-1">Seleccione..</asp:ListItem>
                        <asp:ListItem Value="1">Tercera Infantil</asp:ListItem>                      
                    </asp:DropDownList>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lbGolLocal1" runat="server" Text="Goles Equipo Local"></asp:Label>
                    <asp:TextBox ID="tbGolLocal1" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lbGolVisita1" runat="server" Text="Goles Equipo Visita"></asp:Label>
                    <asp:TextBox ID="tbGolVisita1" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div>
                <br />
            </div>
            <div class=" boton form-row" style="clear: both">
                <div class="col-12 text-center">
                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" /><br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
