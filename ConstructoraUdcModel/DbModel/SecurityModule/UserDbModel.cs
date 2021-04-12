using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdcModel.DbModel.SecurityModule
{
    public class UserDbModel : DbModelBase
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private String lastName;

        public String LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private String document;

        public String Document
        {
            get { return document; }
            set { document = value; }
        }

        private String email;

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        private String passwordUser;

        public String PasswordUser
        {
            get { return passwordUser; }
            set { passwordUser = value; }
        }

        private String phone;

        public String Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private int city;

        public int City
        {
            get { return city; }
            set { city = value; }
        }

        private bool removed;

        public bool Removed
        {
            get { return removed; }
            set { removed = value; }
        }

        private DateTime removedDate;

        public DateTime RemovedDate
        {
            get { return removedDate; }
            set { removedDate = value; }
        }

        private DateTime createDate;

        public DateTime CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }

        
        private int removedUserId;

        public int RemovedUserId
        {
            get { return removedUserId; }
            set { removedUserId = value; }
        }

        private int createUserId;

        public int CreateUserId
        {
            get { return createUserId; }
            set { createUserId = value; }
        }

        private int updateUserId;

        public int UpdateUserId
        {
            get { return updateUserId; }
            set { updateUserId = value; }
        }

        private DateTime updateDate;

        public DateTime UpdateDate
        {
            get { return updateDate; }
            set { updateDate = value; }
        }


        private IEnumerable<RoleDbModel> roles;

        public IEnumerable<RoleDbModel> Roles
        {
            get { return roles; }
            set { roles = value; }
        }


    }
}
