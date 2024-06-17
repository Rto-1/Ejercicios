<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PiePagina.aspx.cs" Inherits="Ejercicios.PiePagina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <html xmlns="http://www.w3.org/1999/xhtml">
 <head>
     <title>Generar PDF desde SQL Server</title>
 </head>
 <body>
         <div>
             <asp:Button ID="btnGenerarPDF" runat="server" Text="Generar PDF" OnClick="btnGenerarPDF_Click" />
         </div>
    
 </body>
 </html>



</asp:Content>
