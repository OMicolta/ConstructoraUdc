using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdcController.Services
{
    public class Notifications
    {
        public Boolean sendEmail(string subject, string content, string to, string from )
        {
            // sengrind serbvice
            return true;
        }

        public Boolean sendSMS(string content, string to, string from)
        {
            // twillio serbvice
            return true;
        }
    }
}
