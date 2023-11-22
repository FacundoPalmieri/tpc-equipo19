﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="tp_web_equipo_19.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-lg" style="height: 250px; margin: 1px; margin-bottom: 150px;">
        <div class="row justify-content-center align-items-center" style="height: 100%;">
            <div class="col-6">
                <div class="font weight-bold blockquote" style="color: #AAC3CD; display: flex">
                    <%--   <div class="mb-3 ">--%>
                    <label for="exampleFormControlInput1" class="form-label">Email</label>
                    <%--</div>--%>
                </div>

                <div>
                    <%-- <input type="email" class="form-control mb-3" id="exampleFormControlInput1" placeholder="nombre@ejemplo.com">--%>
                    <asp:TextBox ID="TextBoxUser" CssClass="form-control mb-3" placeholder="nombre@ejemplo.com" runat="server"></asp:TextBox>
                </div>


                <div class="font weight-bold blockquote" style="color: #AAC3CD; display: flex">

                    <label for="inputPassword5" class="form-label">Contraseña</label>
                </div>


                <div>
                    <asp:TextBox ID="TextBoxPassword" type="password" CssClass="form-control mb-3" aria-describedby="passwordHelpBlock" runat="server"></asp:TextBox>
                    <%--     <input type="password" id="inputPassword5" class="form-control mb-3" aria-describedby="passwordHelpBlock">--%>
                </div>


                <%--       <div id="passwordHelpBlock" class="form-text">--%>
                <%--Your password must be 8-20 characters long, contain letters and numbers, and must not contain spaces, special characters, or emoji.--%>
                <%--  </div>--%>


                <div>
                    <%-- <button type="button" class="btn btn-secondary btn-sm">Ingresar</button>--%>
                    <asp:Button ID="ButtonIngresar" CssClass="btn btn-success" OnClick="ButtonIngresar_Click" runat="server" Text="Ingresar" />
                    <%-- <button type="button" class="btn btn-secondary btn-sm">Ingresar</button>--%>
                    <asp:Button ID="ButtonRegistrarse" CssClass="btn btn-secondary" OnClick="ButtonRegistrarse_Click" runat="server" Text="Registrarme" />
                </div>
                 
            



                <div>
                    <asp:Label ID="MensajeError" runat="server" Visible="false" CssClass="text-danger"></asp:Label>
                </div>
            </div>
        </div>
    </div>

</asp:Content>