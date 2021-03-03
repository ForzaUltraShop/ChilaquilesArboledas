
using System;
using System.Configuration;
using System.Globalization;

namespace FoodApp.Models
{
    public class MailDTO
    {
        public string EmailFrom { get; private set; }

        public string EmailTo { get; set; }

        public string EmailSubject { get; set; }

        public string EmailBody { get; set; }

        public string SmtpServer { get; private set; }

        public int Port { get; private set; }

        public string SmtpUser { get; private set; }

        public string SmtpPassword { get; private set; }

        public bool EnableSsl { get; private set; }

        public MailDTO()
        {
            EmailFrom = ConfigurationManager.AppSettings["EmailOptions.EmailFrom"].ToString();
            Port = Convert.ToInt32(ConfigurationManager.AppSettings["EmailOptions.Port"].ToString(), CultureInfo.InvariantCulture);
            EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EmailOptions.EnableSsl"].ToString());
            SmtpServer = ConfigurationManager.AppSettings["EmailOptions.SmptServer"].ToString();
            SmtpUser = ConfigurationManager.AppSettings["EmailOptions.SmtpUser"].ToString();
            SmtpPassword = ConfigurationManager.AppSettings["EmailOptions.SmtpPassword"].ToString();
        }
    }
}
