using System;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Text;
using System.Web.Hosting;

namespace AndersonPay.Controllers.EmailClass
{
    public class SendEmail
    {
        public System.String EmailReceipient;
        public string Message;
        public void EmailNotifications()
        {

            //Declaration of thingys
            NetworkCredential _login;
            SmtpClient _client;
            MailMessage _clientMsg = new MailMessage();
            MailMessage _userMsg = new MailMessage();

            // Credentials can be found on web.config :)) to be O B F U S C A T E D
            _login = new NetworkCredential(ConfigurationManager.AppSettings["SenderAddress"], ConfigurationManager.AppSettings["SenderPassword"]);

            //For SMTP Settings
            _client = new SmtpClient(ConfigurationManager.AppSettings["SMTP"]);
            _client.Port = Convert.ToInt32(int.Parse(ConfigurationManager.AppSettings["Port"]));
            _client.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["SSL"]);
            _client.Credentials = _login;

            // For client
            _clientMsg.From = new MailAddress(ConfigurationManager.AppSettings["SenderAddress"]);
            _clientMsg.Subject = ConfigurationManager.AppSettings["Subject"];
            _clientMsg.IsBodyHtml = bool.Parse(ConfigurationManager.AppSettings["HTML"]);
            //_clientMsg.Body = System.IO.File.ReadAllText(ConfigurationManager.AppSettings["ClientFilePath"])3+this.Message;
            _clientMsg.Body = this.Message;
            _clientMsg.BodyEncoding = Encoding.UTF8;

            // For user
            _userMsg.Subject = ConfigurationManager.AppSettings["Subject"];
            _userMsg.IsBodyHtml = bool.Parse(ConfigurationManager.AppSettings["HTML"]);
            _userMsg.Body = System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/EmailMessage/UserMessage.html"));
            _userMsg.BodyEncoding = Encoding.UTF8;

            // Recipient of the email
            //_clientMsg.To.Add("ryandc@andersongroup.uk.com");
            _clientMsg.To.Add("2ellei4ares@gmail.com");

            //  _userMsg.To.Add();

            // For client
            _clientMsg.Priority = MailPriority.Normal;
            _clientMsg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure; //notify if sending has failed

            // For user
            _userMsg.Priority = MailPriority.Normal;
            _userMsg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure; //notify if sending has failed

            // For client
            _client.Send(_clientMsg);

            // For user
            //  _client.Send(_userMsg);

            // For client
            _clientMsg.Dispose();

            // For user
            //  _userMsg.Dispose();


        }

    }
}