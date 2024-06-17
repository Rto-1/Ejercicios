<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="tablaDomingo.aspx.cs" Inherits="Ejercicios.tablaDomingo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div>
        <!-- Bootstrap CSS -->
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-B4gt1jrGC7Jh4AgTPSdUtOBvfO8shC8X3h8fM5CUw3DIp0M2jKWoPcXw7ZEWr0j4" crossorigin="anonymous">
    </div>
    
    <div>
        <main>
            <div class="container-fluid">
                <nav class="navbar navbar-expand-lg navbar-dark bg-dark" style="border-radius: 10px;">
                    <div class="container">
                        <a class="navbar-brand" style="font-size: 30px" href="Miembros">Registro de Miembros</a>
                        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavM" aria-controls="navbarNavM" aria-expanded="false" aria-label="Toggle navigation">
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
            
            <!-- Other content -->

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
        </main>

        <!-- Bootstrap JS (Popper included) -->
        <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js" integrity="sha384-EFvw7NQzay+TjKxBV+gCtdxvB/f2kEdpzHvxExb9I8KNUKlW+xTNc9TQQg8B+YoO" crossorigin="anonymous"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.min.js" integrity="sha384-b5uXw7ZC7e9JNt6Hko56CkDJJCp08h+KjoZY2vFj5A9xgAo/xVwGToxkR+7ze2Iz" crossorigin="anonymous"></script>
    </div>
</asp:Content>



