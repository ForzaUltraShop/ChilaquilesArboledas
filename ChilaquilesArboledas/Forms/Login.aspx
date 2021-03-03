<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Login.aspx.cs" Inherits="ChilaquilesArboledas.Forms.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chilaquiles Arboledas</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.10/js/select2.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.10/css/select2.min.css" rel="stylesheet"/>
    <style>
        body {
            padding-top: 90px;
            font-family: Arial, Helvetica, sans-serif;
            background-image: url("../assets/images/wood-background_3.jpg")
        }

        .panel-login {
            border-color: #ccc;
            -webkit-box-shadow: 0px 2px 3px 0px rgba(0,0,0,0.2);
            -moz-box-shadow: 0px 2px 3px 0px rgba(0,0,0,0.2);
            box-shadow: 0px 2px 3px 0px rgba(0,0,0,0.2);
        }

        .panel-login > .panel-heading {
            color: #00415d;
            background-color: #fff;
            border-color: #fff;
            text-align: center;
        }

        .panel-login > .panel-heading a {
            text-decoration: none;
            color: #666;
            font-weight: bold;
            font-size: 15px;
            -webkit-transition: all 0.1s linear;
            -moz-transition: all 0.1s linear;
            transition: all 0.1s linear;
        }

        .panel-login > .panel-heading a.active {
            color: white;
            font-size: 16px;
            background-color:#00415d;
            padding:10px 10px 10px 10px;
            border-top-left-radius: 30px;
            border-bottom-left-radius: 30px;
            border-top-right-radius: 30px;
            border-bottom-right-radius: 30px;
        }

        .panel-login > .panel-heading hr {
            margin-top: 10px;
            margin-bottom: 0px;
            clear: both;
            border: 0;
            height: 1px;
            background-image: -webkit-linear-gradient(left,rgba(0, 0, 0, 0),rgba(0, 0, 0, 0.15),rgba(0, 0, 0, 0));
            background-image: -moz-linear-gradient(left,rgba(0,0,0,0),rgba(0,0,0,0.15),rgba(0,0,0,0));
            background-image: -ms-linear-gradient(left,rgba(0,0,0,0),rgba(0,0,0,0.15),rgba(0,0,0,0));
            background-image: -o-linear-gradient(left,rgba(0,0,0,0),rgba(0,0,0,0.15),rgba(0,0,0,0));
        }

        .panel-login input[type="text"], .panel-login input[type="email"], .panel-login input[type="password"] {
            height: 45px;
            border: 1px solid #ddd;
            font-size: 16px;
            -webkit-transition: all 0.1s linear;
            -moz-transition: all 0.1s linear;
            transition: all 0.1s linear;
        }

        .panel-login input:hover,
        .panel-login input:focus {
            outline: none;
            -webkit-box-shadow: none;
            -moz-box-shadow: none;
            box-shadow: none;
            border-color: #ccc;
        }

        .btn-login {
            background-color: #59B2E0;
            outline: none;
            color: #fff;
            font-size: 14px;
            height: auto;
            font-weight: normal;
            padding: 14px 0;
            text-transform: uppercase;
            border-color: #59B2E6;
        }

        .btn-login:hover,
        .btn-login:focus {
            color: #fff;
            background-color: #53A3CD;
            border-color: #53A3CD;
        }

        .forgot-password {
            text-decoration: underline;
            color: #888;
        }

        .forgot-password:hover,
        .forgot-password:focus {
            text-decoration: underline;
            color: #666;
        }

        .btn-register {
            background-color: #1CB94E;
            outline: none;
            color: #fff;
            font-size: 14px;
            height: auto;
            font-weight: normal;
            padding: 14px 0;
            text-transform: uppercase;
            border-color: #1CB94A;
        }

        .btn-register:hover,
        .btn-register:focus {
            color: #fff;
            background-color: #1CA347;
            border-color: #1CA347;
        }

        .select2-hidden-accessible {
            border: 0 !important;
            clip: rect(0 0 0 0) !important;
            height: 1px !important;
            margin: -1px !important;
            overflow: hidden !important;
            padding: 0 !important;
            position: absolute !important;
            width: 1px !important
        }

        .select2-container--default .select2-selection--single,
        .select2-selection .select2-selection--single {
            border: 1px solid #d2d6de;
            border-radius: 0;
            padding: 6px 12px;
            height: 34px
        }

        .select2-container--default .select2-selection--single {
            background-color: #fff;
            border: 1px solid #aaa;
            border-radius: 4px
        }

        .select2-container .select2-selection--single {
            box-sizing: border-box;
            cursor: pointer;
            display: block;
            height: 28px;
            user-select: none;
            -webkit-user-select: none
        }

        .select2-container .select2-selection--single .select2-selection__rendered {
            padding-right: 10px
        }

        .select2-container .select2-selection--single .select2-selection__rendered {
            padding-left: 0;
            padding-right: 0;
            height: auto;
            margin-top: -3px
        }

        .select2-container--default .select2-selection--single .select2-selection__rendered {
            color: #444;
            line-height: 28px
        }

        .select2-container--default .select2-selection--single,
        .select2-selection .select2-selection--single {
            border: 1px solid #d2d6de;
            border-radius: 0 !important;
            padding: 6px 12px;
            height: 40px !important
        }

        .select2-container--default .select2-selection--single .select2-selection__arrow {
            height: 26px;
            position: absolute;
            top: 6px !important;
            right: 1px;
            width: 20px
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <div class="panel panel-login">
                        <div class="panel-heading">
                            <div class="row">
                                <img src="../assets/images/logo.png" width="150px" height="150px" />
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-xs-6">
                                    <a href="#" class="active" id="login-form-link">Iniciar sesi&oacute;n</a>
                                </div>
                                <div class="col-xs-6">
                                    <a href="#" id="register-form-link">Registrarme</a>
                                </div>
                            </div>
                            <hr/>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div id="login-form" style="display: block;">
                                        <div class="form-group">
                                            <asp:TextBox runat="server" ID="txtUserPhoneNumber" type="phone" MaxLength="10" CssClass="form-control" placeholder="Número teléfonico" Height="45px" Font-Size="16px"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox runat="server" ID="txtUserPassword" type="password" MaxLength="8" CssClass="form-control" placeholder="Contraseña" />
                                        </div>
                                        <%--<div class="form-group">
                                            <input type="checkbox" tabindex="3" class="" name="remember" id="remember" />
                                            <label for="remember">Recu&eacute;rdame</label>
                                        </div>--%>
                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-sm-6 col-sm-offset-3">
                                                    <asp:Button runat="server" ID="bntLogin" CssClass="form-control btn btn-success" Text="Ingresar" OnClick="bntLogin_Click" />
                                                    <br />
                                                    <asp:Label runat="server" ID="lblErrorLogin" style="color:crimson; font-weight:bold" Text="Número teléfonico o contraseña no validos" Visible="false"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div class="text-center">
                                                        <%--<a href="https://phpoll.com/recover" tabindex="5" class="forgot-password">¿Olvidaste tu contraseña?</a>--%>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="register-form" style="display: none;">
                                        <div class="form-group">
                                            <asp:TextBox runat="server" ID="txtRegisterPhone" ClientIDMode="Static" type="phone" MaxLength="10" placeholder="Número de teléfono" CssClass="form-control" Height="45px" Font-Size="16px" ></asp:TextBox>
                                            <small id="spnRegisterPhone" class="form-text text-muted">(Teléfono a 10 dígitos)</small>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox runat="server" ID="txtRegisterName" ClientIDMode="Static" MaxLength="50" placeholder="Nombre y apellido" CssClass="form-control"></asp:TextBox>
                                            <small id="spnRegisterName" class="text-form text-muted">(Máximo 50 caracteres)</small>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox runat="server" ID="txtRegisterEmail" ClientIDMode="Static" type="email" CssClass="form-control" placeholder="Correo eléctronico" value="" />
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox runat="server" ID="txtRegisterPassword" ClientIDMode="Static" type="password" CssClass="form-control" placeholder="Password" MaxLength="8" />
                                            <small id="spnRegisterPassword" class="text-form text-muted">(Máximo 8 caracteres)</small>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox runat="server" ID="txtRegisterConfirmPassword" ClientIDMode="Static" type="password" CssClass="form-control" placeholder="Confirmar Password" MaxLength="8" />
                                        </div>
                                        <div class="form-group">
                                            <span style="border:none;color:#999;opacity:1;font-size:16px;">Selecciona tu colonia</span>
                                            <asp:DropDownList runat="server" ID="ddlPostalCode" ClientIDMode="Static" CssClass="form-control select2 select2-hidden-accessible" placeholder="Colonia"></asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox runat="server" ID="txtRegisterAddress" ClientIDMode="Static" CssClass="form-control" placeholder="Dirección" MaxLength="200" />
                                            <small id="spnRegisterAddress" class="text-form text-muted">(Máximo 200 caracteres)</small>
                                        </div>
                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-sm-6 col-sm-offset-3">
                                                    <input type="button" id="btnRegister" value="Registrarme ahora" class="btn btn-success" />
                                                    <br />
                                                    <span id="spnRegisterError" style="color:crimson; font-weight:bold; display:none;"></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript">

            jQuery.fn.ForceNumericOnly = function () {
                return this.each(function () {
                    $(this).keydown(function (e) {
                        var key = e.charCode || e.keyCode || 0;
                        // allow backspace, tab, delete, enter, arrows, numbers and keypad numbers ONLY
                        // home, end, period, and numpad decimal
                        return (
                            key == 8 ||
                            key == 9 ||
                            key == 13 ||
                            key == 46 ||
                            key == 110 ||
                            key == 190 ||
                            (key >= 35 && key <= 40) ||
                            (key >= 48 && key <= 57) ||
                            (key >= 96 && key <= 105));
                    });
                });
            };

            $(function () {

                $('#txtRegisterPhone').ForceNumericOnly();

                fillPostalCodeDropDownList();

                $('#login-form-link').click(function (e) {
                    $("#login-form").delay(100).fadeIn(100);
                    $("#register-form").fadeOut(100);
                    $('#register-form-link').removeClass('active');
                    $(this).addClass('active');
                    e.preventDefault();
                });

                $('#register-form-link').click(function (e) {
                    $("#register-form").delay(100).fadeIn(100);
                    $("#login-form").fadeOut(100);
                    $('#login-form-link').removeClass('active');
                    $(this).addClass('active');
                    e.preventDefault();
                });

                $('#btnRegister').click(function () {
                    $('#spnRegisterError').hide();

                    let formIsValid = true;
                    if ($('#txtRegisterPassword').val() !== $('#txtRegisterConfirmPassword').val()) {
                        $('#spnRegisterError').text('Los campos de contraseña deben tener el mismo valor');
                        $('#spnRegisterError').show();
                        formIsValid = false;
                    }

                    if ($('#txtRegisterPhone').val().trim() === '' ||
                        $('#txtRegisterName').val().trim() === '' ||
                        $('#txtRegisterEmail').val().trim() === '' ||
                        $('#txtRegisterPassword').val().trim() === '' ||
                        $('#txtRegisterConfirmPassword').val().trim() === '' ||
                        $('#ddlPostalCode').val() === '0' ||
                        $('#txtRegisterAddress').val().trim() === '') {
                        $('#spnRegisterError').text('Todos los campos son requeridos');
                        $('#spnRegisterError').show();
                        formIsValid = false;
                    }

                    if (formIsValid) {
                        let customer = {
                            CustomerName: $('#txtRegisterName').val().trim(),
                            CustomerPhoneNumber: $('#txtRegisterPhone').val().trim(),
                            CustomerEmail: $('#txtRegisterEmail').val().trim(),
                            CustomerPassword: $('#txtRegisterPassword').val().trim(),
                            CustomerPostalCode: $('#ddlPostalCode').val(),
                            CustomerAddress: $('#txtRegisterAddress').val().trim()
                        };

                        $.ajax({
                            type: "POST",
                            url: "Login.aspx/RegisterCustomer",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            data: JSON.stringify({ 'customer': customer }),
                            success: function (response) {
                                let data = response.d;
                                if (data != undefined) {
                                    console.log('registerData', data);
                                    if (data.Success) {
                                        $('#txtRegisterName').val('');
                                        $('#txtRegisterPhone').val('');
                                        $('#txtRegisterEmail').val('');
                                        $('#txtRegisterPassword').val('');
                                        $('#txtRegisterConfirmPassword').val();
                                        $('#ddlPostalCode').val('0');
                                        $('#txtRegisterAddress').val('');
                                        alert("Tu registro esta completo, ya puedes iniciar sesión");
                                    }
                                    else {
                                        if (data.ErrorMessage === 'WrongPostalCode') {
                                            $('#spnRegisterError').text("Lo sentimos el código postal que ingresaste esta fuera de nuestra zona de cobertura");
                                            $('#spnRegisterError').show();
                                        }
                                        else {
                                            $('#spnRegisterError').text("No fue posible realizar tu registro, por favor intenta más tarde");
                                            $('#spnRegisterError').show();
                                        }
                                    }
                                }
                            },
                            failure: function (xhr, textStatus, errorThrown) {
                                $('#spnRegisterError').text("Ocurrió un error al realizar tu registro, por favor intenta más tarde");
                                $('#spnRegisterError').show();
                            }
                        });
                    }
                });

                function fillPostalCodeDropDownList()
                {
                    $.ajax({
                        type: "POST",
                        url: "Login.aspx/PostalCodeGetList",
                        contentType: "application/json; charset=utf-8",
                        async: false,
                        dataType: "json",
                        success: function (response) {
                            let data = response.d;
                            if (data != undefined) {
                                if (data.Success) {
                                    var html = "";
                                    var postalCodeList = data.Result;
                                    $.each(postalCodeList, function (i, item) {
                                        html += "<option value='" + postalCodeList[i].PostalCode + "'>" + postalCodeList[i].Municipality.toUpperCase() + "</option>";
                                    });
                                    
                                    $('#ddlPostalCode').empty();
                                    $('#ddlPostalCode').append("<option value='0'>-Seleccione-</option>");
                                    $('#ddlPostalCode').append(html);
                                    $('#ddlPostalCode').select2(
                                    {
                                        width: '100%',
                                        "language": {
                                            "noResults": function () {
                                                return "Disculpa, no tenemos servicio a esta colonia";
                                            }
                                        }
                                    });
                                }
                                else {
                                    $('#spnRegisterError').text("Intenta de nuevo más tarde");
                                    $('#spnRegisterError').show();
                                }
                            }
                        },
                        failure: function (xhr, textStatus, errorThrown) {
                            $('#spnRegisterError').text("Ocurrió un error al realizar tu registro, por favor intenta más tarde");
                            $('#spnRegisterError').show();
                        }
                    });
                };
              
            });

        </script>
    </form>
</body>
</html>