<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompraConfirmada.aspx.cs" Inherits="tp_web_equipo_19.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
        <style>
        body {
            background-color: gray; /* Color celeste claro */
            /* Otros estilos que desees aplicar */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div  style ="color:#AAC3CD"font-size: 25px;>
            <h1>¡Compra confirmada!</h1>
            <p>¡Gracias por tu compra! El proceso se ha completado con éxito.</p>

            <!-- Aquí puedes agregar más contenido, como imágenes, tablas, etc. -->
        </div>
        <div>
            <script type="text/javascript">
                // Cuando se hace clic en la ventana emergente
                window.onclick = function () {
                    // Envia un mensaje a la ventana principal
                    window.opener.postMessage("clicEnVentanaEmergente", "*");

                    // Cierra la ventana emergente
                    window.close();
                };

                // Centrar la ventana emergente
                function centrarVentana() {
                    var left = (window.screen.width - window.outerWidth) / 2;
                    var top = (window.screen.height - window.outerHeight) / 2;
                    window.moveTo(left, top);
                }

                // Llama a la función para centrar la ventana emergente
                centrarVentana();
            </script>

        </div>
    </form>
</body>
</html>
