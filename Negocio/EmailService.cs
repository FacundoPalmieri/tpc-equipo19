using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
   

    public class EmailService
    {
        private MailMessage Email;
        private SmtpClient Server;

        public EmailService()
        {
            Server = new SmtpClient();
            Server.Credentials = new NetworkCredential("3ced0b39abe958", "********48ec");
            Server.EnableSsl = true;
            Server.Port = 2525;
            Server.Host = "sandbox.smtp.mailtrap.io";

        }

        public void ArmarCorreo(string EmailDestino, string Asunto, string Cuerpo)
        {
            Email = new MailMessage();
            Email.From = new MailAddress("NoResponder@Palmierifacundo@gmail.com");
            Email.To.Add(EmailDestino);
            Email.Subject = Asunto;
            Email.IsBodyHtml = true;
            Email.Body = "<H1> Bienvenido<H1>";


        }

        public void EnviarMail()
        {
            try
            {
                    Server.Send(Email);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        
    }
}
