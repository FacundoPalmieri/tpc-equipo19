<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="tp_web_equipo_19.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-lg" style="height: 250px; margin: 1px; margin-bottom: 150px;">
        <div class="row justify-content-center align-items-center" style="height: 100%;">
            <div class="col-6">
                <div class="font weight-bold blockquote" style="color: #AAC3CD; display: flex">
                    <label for="exampleFormControlInput1" class="form-label">Email</label>
                </div>

                <div>
                    <asp:TextBox ID="TextBoxUser" CssClass="form-control mb-3" placeholder="nombre@ejemplo.com" runat="server"></asp:TextBox>
                </div>


                <div class="font weight-bold blockquote" style="color: #AAC3CD; display: flex">

                    <label for="inputPassword5" class="form-label">Contraseña</label>
                </div>


                <div>
                    <asp:TextBox ID="TextBoxPassword" type="password" CssClass="form-control mb-3" aria-describedby="passwordHelpBlock" runat="server"></asp:TextBox>     
                </div>
                <div>

                    <asp:Button ID="ButtonIngresar" CssClass="btn btn-success" OnClick="ButtonIngresar_Click" runat="server" Text="Ingresar" />
                    <asp:Button ID="ButtonRegistrarse" CssClass="btn btn-secondary" OnClick="ButtonRegistrarse_Click" runat="server" Text="Registrarme" />

                </div>

                 <asp:LinkButton ID="RecuperarContraseña" runat="server" Text="¿No recuerdas tu contraseña?" OnClick="RecuperarContraseña_Click" CssClass="link-inicial"  />

                <div>
                    <asp:Label ID="MensajeError" runat="server" Visible="false" CssClass="text-danger"></asp:Label>
                </div>
            </div>
        </div>
    </div>





































































</asp:Content>
