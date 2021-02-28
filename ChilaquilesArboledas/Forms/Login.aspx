<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ChilaquilesArboledas.Forms.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chilaquiles Arboledas</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
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
                                            <asp:TextBox runat="server" ID="txtRegisterPostalCode" ClientIDMode="Static" CssClass="form-control" placeholder="Código postal" MaxLength="8" />
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
            $(function ()
            {
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

                $('#btnRegister').click(function ()
                {
                    $('#spnRegisterError').hide();

                    let formIsValid = true;
                    if ($('#txtRegisterPassword').val() !== $('#txtRegisterConfirmPassword').val())
                    {
                        $('#spnRegisterError').text('Los campos de contraseña deben tener el mismo valor');
                        $('#spnRegisterError').show();
                        formIsValid = false;
                    }

                    if ($('#txtRegisterPhone').val().trim() === '' ||
                        $('#txtRegisterName').val().trim() === '' ||
                        $('#txtRegisterEmail').val().trim() === '' ||
                        $('#txtRegisterPassword').val().trim() === '' ||
                        $('#txtRegisterConfirmPassword').val().trim() === '' ||
                        $('#txtRegisterPostalCode').val().trim() === '' ||
                        $('#txtRegisterAddress').val().trim() === '')
                    {
                        $('#spnRegisterError').text('Todos los campos son requeridos');
                        $('#spnRegisterError').show();
                        formIsValid = false;
                    }

                    if (formIsValid)
                    {
                        let customer = {
                            CustomerName: $('#txtRegisterName').val().trim(),
                            CustomerPhoneNumber: $('#txtRegisterPhone').val().trim(),
                            CustomerEmail: $('#txtRegisterEmail').val().trim(),
                            CustomerPassword: $('#txtRegisterPassword').val().trim(),
                            CustomerPostalCode: $('#txtRegisterPostalCode').val().trim(),
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
                                        $('#txtRegisterPostalCode').val('');
                                        $('#txtRegisterAddress').val('');
                                        alert("Tu registro esta completo, ya puedes iniciar sesión");
                                    }
                                    else
                                    {
                                        if (data.ErrorMessage === 'WrongPostalCode')
                                        {
                                            $('#spnRegisterError').text("Lo sentimos el código postal que ingresaste esta fuera de nuestra zona de cobertura");
                                            $('#spnRegisterError').show();
                                        }
                                        else
                                        {
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

                    //return formIsValid;
                });
            });
        </script>
    </form>
</body>
</html>