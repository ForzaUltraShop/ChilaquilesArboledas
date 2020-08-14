<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="ChilaquilesArboledas.Forms.Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        
        .title {
            margin-bottom: 50px;
            text-transform: uppercase;
        }

        .card-block {
            font-size: 1em;
            position: relative;
            margin: 0;
            padding: 1em;
            border: none;
            box-shadow: none;
        }

        .card {
            font-size: 1em;
            overflow: hidden;
            padding: 5px;
            border: none;
            border-radius: .28571429rem;
            box-shadow: 0 1px 3px 0 #d4d4d5, 0 0 0 1px #d4d4d5;
            margin-top: 20px;
            cursor:pointer;
        }

        .btn {
            margin-top: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="divContent">

    </div>
    <br />
    <br />

    <%--<div class="row">
        <div class="col-12 mt-3">
            <div class="card">
                <div class="card-horizontal">
                    <div class="img-square-wrapper">
                        <img class="imgChilaquiles" src="../assets/images/platoChilaquiles.jpg" width="300px" height="180px" alt="Card image cap" data-toggle="modal" data-target="#chilaquilesModal">
                    </div>
                    <div class="card-body">
                        <h4 class="card-title">Chilaquiles</h4>
                        <p class="card-text">
                            Crujientes totopos bañados en cualquiera de nuestras deliciosas salsas (verdes, rojos, de mole o suizos), grandes o chicos. ¡Su sabor te encantara!.
                        </p>
                    </div>
                </div>
                <div class="card-footer">
                    <small class="text-muted">
                        <i class="fa fa-fw fa-heart" aria-hidden="true"></i>A 50 personas les guta esto
                    </small>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-12 mt-3">
            <div class="card">
                <div class="card-horizontal">
                    <div class="img-square-wrapper">
                        <img class="" src="assets/images/tortaChilaquiles2.jpg" width="300px" height="180px" alt="Card image cap">
                    </div>
                    <div class="card-body">
                        <h4 class="card-title">Torta de Chilaquiles</h4>
                        <p class="card-text">Exquisita torta disponible en nuestras salsas clásicas verde o roja.</p>
                    </div>
                </div>
                <div class="card-footer">
                    <small class="text-muted">
                        <i class="fa fa-fw fa-heart" aria-hidden="true"></i>A 50 personas les guta esto
                    </small>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-12 mt-3">
            <div class="card">
                <div class="card-horizontal">
                    <div class="img-square-wrapper">
                        <img class="" src="assets/images/cafeOlla.jpg" width="300px" height="180px" alt="Card image cap">
                    </div>
                    <div class="card-body">
                        <h4 class="card-title">Complementos</h4>
                        <p class="card-text">Acompaña tu orden con un ríquisimo café de olla preparado con canela, anis, piloncillo, clavo de olor y cáscara de naranja. </p>
                    </div>
                </div>
                <div class="card-footer">
                    <small class="text-muted">
                        <i class="fa fa-fw fa-heart" aria-hidden="true"></i>A 50 personas les guta esto
                    </small>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-12 mt-3">
            <div class="card">
                <div class="card-horizontal">
                    <div class="img-square-wrapper">
                        <img class="" src="assets/images/descuentos.png" width="300px" height="180px" alt="Card image cap">
                    </div>
                    <div class="card-body">
                        <h4 class="card-title">Promociones, cupones y descuentos</h4>
                        <p class="card-text">Gana la oportunidad de acceder a increibles descuentos y promociones volviendote un cliente frecuente. </p>
                    </div>
                </div>
                <div class="card-footer">
                    <small class="text-muted">
                        <i class="fa fa-fw fa-heart" aria-hidden="true"></i>A 200 personas les guta esto
                    </small>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-12 mt-3">
            <div class="card">
                <div class="card-horizontal">
                    <div class="img-square-wrapper">
                        <img class="" src="assets/images/eventos.jpg" width="300px" height="180px" alt="Card image cap">
                    </div>
                    <div class="card-body">
                        <h4 class="card-title">Pedidos para eventos</h4>
                        <p class="card-text">Te acompañamos en tus mejores momentos, elije esta opción para agendar tu evento.</p>
                    </div>
                </div>
                <div class="card-footer">
                    <small class="text-muted">
                        <i class="fa fa-fw fa-heart" aria-hidden="true"></i>A 200 personas les guta esto
                    </small>
                </div>
            </div>
        </div>
    </div>--%>
    <script type="text/javascript" src='<%=ResolveUrl(string.Format("~/assets/js/menu.js?{0}", DateTime.Now.Ticks)) %>'></script>
</asp:Content>