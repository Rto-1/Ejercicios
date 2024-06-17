<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ejercicios._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .bordered-text {
            text-shadow: -1px -1px 0 black, 1px -1px 0 black, -1px 1px 0 black, 1px 1px 0 black;
        }

        .c-img, .c-imgUno {
            opacity: 0.7; /* Ajusta este valor según sea necesario */
            mix-blend-mode: multiply; /* Otras opciones: screen, overlay, etc. */
            border: none;
        }

        .c-item {
            position: relative;
            background-color: rgba(0, 0, 0, 0.5); /* Fondo semitransparente oscuro */
        }

        .carousel-caption {
            color: #fff; /* Color del texto blanco para buen contraste */
            text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.5); /* Sombra para mejorar la legibilidad */
        }

        .carousel-control-prev-icon,
        .carousel-control-next-icon {
            border: none; /* Asegura que los iconos de control no tengan borde */
        }

        /* Estilos para el enlace de WhatsApp flotante */
        #whatsapp-float {
            position: fixed;
            bottom: 400px;
            right: 20px;
            z-index: 1000;
        }

        /*#whatsapp-float img {
                width: 50px;
                height: 50px;
            }*/

        #tooltip {
            display: none;
            position: absolute;
            bottom: 70px;
            right: 0;
            background-color: #fff;
            border: 1px solid #ccc;
            padding: 5px;
            border-radius: 5px;
            z-index: 1001;
        }
         
    </style>

    <main class="main p-4">

        <nav class="navbar navbar-expand-lg navbar-dark bg-dark" style="border-radius: 10px;">
            <div class="container">
                <a class="navbar-brand" style="font-size: 20px" runat="server" href="~/Default">Tabla de Posiciones</a>
                <button type="button" class="navbar-toggler" data-bs-toggle="collapse" data-bs-target="#navbarNavD" title="Alternar navegación" aria-controls="navbarSupportedContent"
                    aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse d-sm-inline-flex justify-content-between align-middle" id="navbarNavD">
                    <ul class="navbar-nav flex-grow-3">
                        <li class="nav-item"><a class="nav-link" runat="server" href="Default"></a></li>
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

        <div class="container center-container">
            <div class="text-center">
                <div class="text-light m-4">
                    <div>
                        <h4>
                            <asp:Image ID="imgEquipo" Style="height: 40px;" Visible="false" runat="server" src="images/miramontes.png" />
                            <asp:Label ID="lbUno" runat="server" Visible="false" Text="Aquí">Deseamos un Feliz Cumpleaños</asp:Label>
                            <asp:Image ID="Image1" Style="height: 40px;" Visible="false" runat="server" src="images/miramontes.png" />
                        </h4>
                    </div>
                    <div>
                        <asp:Image ID="Image2" Style="height: 35px;" Visible="false" runat="server" src="images/confetti.png" />
                        <asp:Label ID="lblMensaje" CssClass="justify-content-center;" runat="server" Visible="false" Text="Aquí"></asp:Label>
                        <asp:Image ID="Image3" Style="height: 35px;" Visible="false" runat="server" src="images/confetti.png" />
                    </div>
                    <div>
                        <asp:Image ID="Image4" Style="height: 35px;" Visible="false" runat="server" src="images/confetti (1).png" />
                        <asp:Label ID="Label1" runat="server" Visible="false" Text="Aquí">¡¡ Felicidades y Exito !!</asp:Label>
                        <asp:Image ID="Image5" Style="height: 35px;" Visible="false" runat="server" src="images/confetti (1).png" />
                    </div>
                </div>
            </div>
        </div>


        <div class="row mt-0 justify-content-center p-4">
            <div class="col-sm-3">
                <div class="card  mb-3">
                    <ul class="list-group">
                        <li class="list-group-item text-white" style="background-color: #0B5345;" aria-current="true">
                            <strong>SUPER SENIORS</strong>
                        </li>
                        <li class="list-group-item text-center">
                            <h6 class="mt-0">Sabado 26 abril 15:00hrs</h6>
                            <span style="float: left;">
                                <img src="/images/miramontes.png" style="height: 30px;" alt="" />
                            </span>
                            <span class="mx-auto" style="">
                                <strong><span>MIRAMONTES</span></strong>
                                <span class="text-success">VS</span>
                                <strong><span>LOS CONDORES</span></strong>
                            </span>
                            <p>cancha 10</p>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="col-sm-3">
                <div class="card  mb-3">
                    <ul class="list-group">
                        <li class="list-group-item text-white" style="background-color: #0B5345;" aria-current="true">
                            <strong>DORADOS</strong>
                        </li>
                        <li class="list-group-item text-center">
                            <h6 class="mt-0">Sabado 26 abril 15:00hrs</h6>
                            <span style="float: left;">
                                <img src="/images/miramontes.png" style="height: 30px;" alt="" />
                            </span>
                            <span class="mx-auto" style="">
                                <strong><span>MIRAMONTES</span></strong>
                                <span class="text-success">VS</span>
                                <strong><span>LOS CONDORES</span></strong>
                            </span>
                            <p>cancha 10</p>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="col-sm-3">
                <div class="card  mb-3">
                    <ul class="list-group">
                        <li class="list-group-item text-white" style="background-color: #0B5345;" aria-current="true">
                            <strong>DOMINGO</strong>
                        </li>
                        <li class="list-group-item text-center">
                            <h6 class="mt-0">Sabado 26 abril 15:00hrs</h6>
                            <span style="float: left;">
                                <img src="/images/miramontes.png" style="height: 30px;" alt="" />
                            </span>
                            <span class="mx-auto" style="">
                                <strong><span>MIRAMONTES</span></strong>
                                <span class="text-success">VS</span>
                                <strong><span>LOS CONDORES</span></strong>
                            </span>
                            <p>cancha 10</p>
                        </li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-4">
                <div class="card b-none">
                    <div id="carouselExampleCaptions" class="carousel slide ">
                        <div class="carousel-indicators">
                            <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                            <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="1" aria-label="Slide 2"></button>
                            <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="2" aria-label="Slide 3"></button>
                        </div>
                        <div class="carousel-inner">
                            <div class="carousel-item active c-item">
                                <img src="/images/mira.jpg" class="d-block w-100 c-img img-fluid" alt="...">
                                <div class="carousel-caption d-none d-md-block">
                                    <h5 class="bordered-text">First slide label</h5>
                                    <p class="bordered-text">Some representative placeholder content for the first slide.</p>
                                </div>
                            </div>
                            <div class="carousel-item c-item">
                                <img src="/images/1.jpg" class="d-block w-100 c-imgUno img-fluid" alt="...">
                                <div class="carousel-caption d-none d-md-block">
                                    <h5 class="bordered-text">Second slide label</h5>
                                    <p class="bordered-text">Some representative placeholder content for the second slide.</p>
                                </div>

                            </div>
                            <div class="carousel-item c-item">
                                <img src="/images/2.jpg" class="d-block w-100 c-imgUno img-fluid" alt="...">
                                <div class="carousel-caption d-none d-md-block">
                                    <h5 class="bordered-text">Third slide label</h5>
                                    <p class="bordered-text">Some representative placeholder content for the third slide.</p>
                                </div>
                            </div>
                        </div>
                        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Previous</span>
                        </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Next</span>
                        </button>
                    </div>
                </div>
            </div>

            <div class="col-sm-4">
                <div class="card b-none">
                    <div id="carouselExampleCaptions1" class="carousel slide ">
                        <div class="carousel-indicators">
                            <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                            <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="1" aria-label="Slide 2"></button>
                            <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="2" aria-label="Slide 3"></button>
                        </div>
                        <div class="carousel-inner">
                            <div class="carousel-item active c-item">
                                <img src="/images/mira.jpg" class="d-block w-100 c-img img-fluid" alt="...">
                                <div class="carousel-caption d-none d-md-block">
                                    <h5 class="bordered-text">First slide label</h5>
                                    <p class="bordered-text">Some representative placeholder content for the first slide.</p>
                                </div>
                            </div>
                            <div class="carousel-item c-item">
                                <img src="/images/1.jpg" class="d-block w-100 c-imgUno img-fluid" alt="...">
                                <div class="carousel-caption d-none d-md-block">
                                    <h5 class="bordered-text">Second slide label</h5>
                                    <p class="bordered-text">Some representative placeholder content for the second slide.</p>
                                </div>

                            </div>
                            <div class="carousel-item c-item">
                                <img src="/images/2.jpg" class="d-block w-100 c-imgUno img-fluid" alt="...">
                                <div class="carousel-caption d-none d-md-block">
                                    <h5 class="bordered-text">Third slide label</h5>
                                    <p class="bordered-text">Some representative placeholder content for the third slide.</p>
                                </div>
                            </div>
                        </div>
                        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions1" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Previous</span>
                        </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions1" data-bs-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Next</span>
                        </button>
                    </div>
                </div>
            </div>

            <div class="col-sm-4">
                <div class="card">
                    <div id="carouselExampleCaptions2" class="carousel slide ">
                        <div class="carousel-indicators">
                            <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                            <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="1" aria-label="Slide 2"></button>
                            <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="2" aria-label="Slide 3"></button>
                        </div>
                        <div class="carousel-inner">
                            <div class="carousel-item active c-item">
                                <img src="/images/mira.jpg" class="d-block w-100 c-img img-fluid" alt="...">
                                <div class="carousel-caption d-none d-md-block">
                                    <h5 class="bordered-text">First slide label</h5>
                                    <p class="bordered-text">Some representative placeholder content for the first slide.</p>
                                </div>
                            </div>
                            <div class="carousel-item c-item">
                                <img src="/images/1.jpg" class="d-block w-100 c-imgUno img-fluid" alt="...">
                                <div class="carousel-caption d-none d-md-block">
                                    <h5 class="bordered-text">Second slide label</h5>
                                    <p class="bordered-text">Some representative placeholder content for the second slide.</p>
                                </div>
                            </div>
                            <div class="carousel-item c-item">
                                <img src="/images/2.jpg" class="d-block w-100 c-imgUno img-fluid" alt="...">
                                <div class="carousel-caption d-none d-md-block">
                                    <h5 class="bordered-text">Third slide label</h5>
                                    <p class="bordered-text">Some representative placeholder content for the third slide.</p>
                                </div>
                            </div>
                        </div>
                        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions2" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Previous</span>
                        </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions2" data-bs-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Next</span>
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </main>

    <!-- Enlace de WhatsApp flotante -->
    <div id="whatsapp-float">
        <a href="https://api.whatsapp.com/send?phone=56997774303&text=Hola%20,te%20asesoramos%20por%20whatsapp%20gestiona%20tu%20compra%20por%20este%20canal."
            target="_blank" id="whatsapp-link" style="position: relative;">
            <img src="images/whatsapp.png" alt="WhatsApp" style="width: 50px; height: 50px; border-radius: 50%; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);">
            <div id="tooltip" style="display: none; position: absolute; bottom: 70px; right: 10px; background-color: #25D366; color: #fff; padding: 10px; border-radius: 5px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2); white-space: nowrap;">
                Chatea con nosotros en WhatsApp!
            </div>
        </a>
    </div>

    <script>
        // Mostrar el tooltip al pasar el ratón sobre el enlace de WhatsApp
        const whatsappLink = document.getElementById('whatsapp-float');

        const tooltip = document.getElementById('tooltip');

        whatsappLink.addEventListener('mouseenter', function () {
            tooltip.style.display = 'block';
        });

        whatsappLink.addEventListener('mouseleave', function () {
            tooltip.style.display = 'none';
        });
    </script>

</asp:Content>

