using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdcModel.DbModel
{
    public class DbModelBase
    {
        private DateTime currentDate;

        public DateTime CurrentDate
        {
            get { return DateTime.Now; }
            set { currentDate = value; }
        }

        private int userInSession;

        public int UserInSession
        {
            get { return userInSession; }
            set { userInSession = value; }
        }


    }
}
