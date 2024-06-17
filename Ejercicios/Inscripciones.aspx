<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inscripciones.aspx.cs" Inherits="Ejercicios.Inscripciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .card img {
            width: 100%;
            height: auto;
        }

        .form-group {
            margin-bottom: 15px;
        }

        .digital_signature-pad {
            width: 100%;
            max-width: 400px;
            height: auto;
        }

        @media (max-width: 767.98px) {
            .digital_signature-pad {
                width: 100%;
                height: 150px;
            }
        }

        .btn-custom {
            border-radius: 6px;
            border: 1px solid #000;
        }

        .input-group p {
            margin: 0;
        }
    </style>
        <div class="container">
            <div class="row p-4">
                <div class="col-sm-12 col-md-6 mb-3">
                    <div class="card">
                        <div class="card-body">
                            <h2 class="text-center"><strong>FORMULARIO DE INSCRIPCIÓN</strong></h2>
                            <ul class="list-group list-group-flush">
                                <li class="list-group-item">
                                    <div class="row">
                                        <div class="col-12 col-md-6">
                                            <asp:TextBox runat="server" class="form-control" ID="lbnombres" placeholder="Nombres"></asp:TextBox>
                                        </div>
                                        <div class="col-12 col-md-6">
                                            <asp:TextBox runat="server" class="form-control" ID="lbPaterno" placeholder="Apellido Paterno"></asp:TextBox>
                                        </div>
                                    </div>
                                </li>
                                <li class="list-group-item">
                                    <div class="row">
                                        <div class="col-12 col-md-6">
                                            <asp:TextBox runat="server" class="form-control" ID="lbMaterno" placeholder="Apellido Materno"></asp:TextBox>
                                        </div>
                                        <div class="col-12 col-md-6">
                                            <asp:TextBox runat="server" class="form-control" ID="lbNacimiento" placeholder="DD-MM-AAAA"></asp:TextBox>
                                        </div>
                                    </div>
                                </li>
                                <li class="list-group-item">
                                    <div class="row">
                                        <div class="col-12 col-md-6">
                                            <asp:TextBox runat="server" class="form-control" ID="lbRut" placeholder="11.111.111-1"></asp:TextBox>
                                        </div>
                                        <div class="col-12 col-md-6">
                                            <asp:TextBox runat="server" class="form-control" ID="lbDireccion" placeholder="Dirección"></asp:TextBox>
                                        </div>
                                    </div>
                                </li>
                                <li class="list-group-item">
                                    <div class="row">
                                        <div class="col-12 col-md-5">
                                            <div class="input-group">
                                                <input type="file" class="form-control" id="frontal" aria-label="Upload">
                                            </div>
                                        </div>
                                        <div class="col-12 col-md-7">
                                            <p class="text-center" data-toggle="tooltip" title="JUGADOR">Agregar carnet identidad parte Frontal</p>
                                        </div>
                                    </div>
                                </li>
                                <li class="list-group-item">
                                    <div class="row">
                                        <div class="col-12 col-md-5">
                                            <div class="input-group">
                                                <input type="file" class="form-control" id="trasera" aria-label="Upload">
                                            </div>
                                        </div>
                                        <div class="col-12 col-md-7">
                                            <p class="text-center" data-toggle="tooltip" title="JUGADOR">Agregar carnet identidad parte Trasera</p>
                                        </div>
                                    </div>
                                </li>
                                <li class="list-group-item">
                                    <div class="row">
                                        <div class="col-12 col-md-5">
                                            <div class="input-group">
                                                <input type="file" class="form-control" id="inputGroupFile03" aria-label="Upload">
                                            </div>
                                        </div>
                                        <div class="col-12 col-md-5">
                                            <p class="text-center">Solo menores de 18 años</p>
                                        </div>
                                        <div class="col-12 col-md-2 text-center">
                                            <a href="/resources/autorizacion.docx" data-toggle="tooltip" title="DESCARGAR AUTORIZACIÓN" class="btn btn-primary">Permiso</a>
                                        </div>
                                    </div>
                                </li>
                                <li class="list-group-item">
                                    <div class="row">
                                        <div class="col-12 col-md-5">
                                            <div class="input-group">
                                                <input type="file" class="form-control" id="autoriza" aria-label="Upload">
                                            </div>
                                        </div>
                                        <div class="col-12 col-md-7">
                                            <p class="text-center" data-toggle="tooltip" title="SOLO MAYORES DE EDAD">Agregar carnet quien autoriza al menor</p>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                            <div class="text-center mt-3">
                                <canvas id="digital_signature-pad_signature-499" backcolor="#dddddd" class="digital_signature-pad" color="#000000" height="170" name="signature-499" style="touch-action: none;"></canvas>
                                <br>
                                <div class="mt-2">
                                    <button id="clear-button1" class="btn btn-custom">Limpiar</button>
                                    <button id="save-button1" class="btn btn-custom">Guardar Firma</button>
                                </div>
                            </div>
                        </div>
                        <div class="row mt-3">
                            <div class="col-12 text-center">
                                <input class="btn btn-success" type="submit" name="name" value="Enviar">
                                <br>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-12 col-md-6 mb-3">
                    <div class="card border-0 bg-black">
                        <div class="card-body">
                            <img src="/images/miramontes.png" alt="Alternate Text">
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <script>
            window.onload = function () {
                var canvas = document.getElementById('digital_signature-pad_signature-499');
                var signaturePad = new SignaturePad(canvas, {
                    backgroundColor: canvas.getAttribute('backcolor'),
                    penColor: canvas.getAttribute('color')
                });

                // Función para limpiar la firma
                document.getElementById('clear-button1').addEventListener('click', function () {
                    signaturePad.clear();
                });

                // Función para guardar la firma
                document.getElementById('save-button1').addEventListener('click', function () {
                    if (signaturePad.isEmpty()) {
                        alert('Por favor, firme antes de guardar.');
                    } else {
                        // Aquí puedes enviar la firma a tu servidor o hacer cualquier otra acción
                        var signatureData = signaturePad.toDataURL(); // Obtener la firma como base64
                        console.log(signatureData);
                        // Aquí puedes enviar signatureData a tu servidor o hacer cualquier otra acción
                    }
                });
            };
        </script>

        <script src="https://cdnjs.cloudflare.com/ajax/libs/signature_pad/1.5.3/signature_pad.min.js"></script>
        <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</asp:Content>
