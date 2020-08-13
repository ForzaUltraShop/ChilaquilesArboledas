<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="ChilaquilesArboledas.Forms.Controls.Login" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<style>
    body {
        margin: 0;
        color: #6a6f8c;
        background: #c8c8c8;
        font: 600 16px/18px 'Open Sans', sans-serif
    }

    .login-box {
        width: 100%;
        margin: auto;
        max-width: 525px;
        min-height: 670px;
        position: relative;
        background: url(https://images.unsplash.com/photo-1507208773393-40d9fc670acf?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1268&q=80) no-repeat center;
        box-shadow: 0 12px 15px 0 rgba(0, 0, 0, .24), 0 17px 50px 0 rgba(0, 0, 0, .19)
    }

    .login-snip {
        width: 100%;
        height: 100%;
        position: absolute;
        padding: 90px 70px 50px 70px;
        background: rgba(0, 77, 77, .9)
    }

    .login-snip .login,
    .login-snip .sign-up-form {
        top: 0;
        left: 0;
        right: 0;
        bottom: 0;
        position: absolute;
        transform: rotateY(180deg);
        backface-visibility: hidden;
        transition: all .4s linear
    }

    .login-snip .sign-in,
    .login-snip .sign-up,
    .login-space .group .check {
        display: none
    }

    .login-snip .tab,
    .login-space .group .label,
    .login-space .group .button {
        text-transform: uppercase
    }
 
</style>

<asp:Panel runat="server" ID="pnlLogin">
    <div class="row">
    <div class="col-md-6 mx-auto p-0">
        <div class="card">
            <div class="login-box">
                <div class="login-snip"> <input id="tab-1" type="radio" name="tab" class="sign-in" checked><label for="tab-1" class="tab">Login</label> <input id="tab-2" type="radio" name="tab" class="sign-up"><label for="tab-2" class="tab">Sign Up</label>
                    <div class="login-space">
                        <div class="login">
                            <div class="group"> <label for="user" class="label">Username</label> <input id="user" type="text" class="input" placeholder="Enter your username"> </div>
                            <div class="group"> <label for="pass" class="label">Password</label> <input id="pass" type="password" class="input" data-type="password" placeholder="Enter your password"> </div>
                            <div class="group"> <input id="check" type="checkbox" class="check" checked> <label for="check"><span class="icon"></span> Keep me Signed in</label> </div>
                            <div class="group"> <input type="submit" class="button" value="Sign In"> </div>
                            <div class="hr"></div>
                            <div class="foot"> <a href="#">Forgot Password?</a> </div>
                        </div>
                        <div class="sign-up-form">
                            <div class="group"> <label for="user" class="label">Username</label> <input id="user" type="text" class="input" placeholder="Create your Username"> </div>
                            <div class="group"> <label for="pass" class="label">Password</label> <input id="pass" type="password" class="input" data-type="password" placeholder="Create your password"> </div>
                            <div class="group"> <label for="pass" class="label">Repeat Password</label> <input id="pass" type="password" class="input" data-type="password" placeholder="Repeat your password"> </div>
                            <div class="group"> <label for="pass" class="label">Email Address</label> <input id="pass" type="text" class="input" placeholder="Enter your email address"> </div>
                            <div class="group"> <input type="submit" class="button" value="Sign Up"> </div>
                            <div class="hr"></div>
                            <div class="foot"> <label for="tab-1">Already Member?</label> </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Panel>
<ajax:ModalPopupExtender runat="server"
    ID="mpeConfirmDelete"
    BackgroundCssClass="fondoModal"
    TargetControlID="btnModalPopup"
    PopupControlID="pnlConfirmDelete">
</ajax:ModalPopupExtender>
<div style="display: none">
    <asp:Button runat="server" ID="btnModalPopup" ClientIDMode="Static" />
</div>