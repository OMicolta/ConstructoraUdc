using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdcController.DTO.SecurityModule
{
    public class RoleDTO
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

        private String description;

        public String Description
        {
            get { return description; }
            set { description = value; }
        }


        private bool removed;

        public bool Removed
        {
            get { return removed; }
            set { removed = value; }
        }



    }
}
