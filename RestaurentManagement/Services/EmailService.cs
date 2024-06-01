using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace RestaurentManagement.Services
{
    internal class EmailService
    {
        MainForm mf = new MainForm();
        private static EmailService _instance;
        public static EmailService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EmailService();
                }
                return _instance;
            }
        }

        public int SendEmail(string email)
        {
            int OTP = 0;
            try
            {
                var getEmail = email;
                OTP = new Random().Next(1000, 9999);
                var fromAddress = new MailAddress("vcb.031024@gmail.com");
                var toAddress = new MailAddress(getEmail.ToString());
                const string fromPass = "nyef itif ztha ruet";
                const string subject = "OTP code";
                string body = OTP.ToString();
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPass),
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
                mf.NotifySuss("OTP đã được gửi qua email");
            }
            catch (Exception ex)
            {
                mf.NotifyErr(ex.Message);
            }


            if(OTP != 0)
            {
                return OTP;
            }
            else
            {
                return 0;
            }
        }
    }
}
