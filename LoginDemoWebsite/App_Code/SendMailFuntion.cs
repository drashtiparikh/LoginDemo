using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

/// <summary>
/// Summary description for clsSendMailFuntion
/// </summary>
public class SendMailFuntion
{
    public SendMailFuntion()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool SendMail(string from, string to, string subject, string body)
    {
        try
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(from);
            mail.From = new MailAddress(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SmtpClient smtpClient = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);

            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("project.temp2014@gmail.com", "rakesh@123");
            smtpClient.Send(mail);
            return true;
        }
        catch
        {
            return false;
        }
    }
}