using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL.EmailSevice
{
    public class EmailServiceDAL
    {
        System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
        internal void EnviarEmail(string email, Usuario usuBE) //mail y clave sin encriptar
       {
           string mensaje =  "Se ha generado la clave: " + usuBE.clavesinencriptar + " para el usuario:" + usuBE._Usuario;

            msg.To.Add(email);
            msg.Subject = "clave Elara";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Bcc.Add("valentini.carlos.marcelo@gmail.com");
            msg.Body = "  " + mensaje.ToString() + "  .";
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = false;

            msg.From = new System.Net.Mail.MailAddress("valentini.carlos.marcelo@gmail.com");

            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            cliente.UseDefaultCredentials = false;
            cliente.Credentials = new System.Net.NetworkCredential("valentinicharly@gmail.com", "valentinicharly87");

            cliente.Port = 587;
            cliente.EnableSsl = true;

            cliente.Host = "smtp.gmail.com";


            cliente.Send(msg);

        }
    }
}
