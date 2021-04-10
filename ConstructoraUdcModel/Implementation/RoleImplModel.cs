using ConstructoraUdcModel.DbModel;
using ConstructoraUdcModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdcModel.Implementation
{
    public class RoleImplModel
    {
        /// <summary>
        /// Se agrega un nuevo registro a los roles
        /// </summary>
        /// <param name="dbModel">Representa un objecto con la informacion del rol</param>
        /// <returns>Entero con la respueta: 1, OK. 2, KO. 3, Ya existe</returns>
        public int RecordCreation( RoleDbModel dbModel )
        {
            using (ConstructoraUdcDBEntities db = new ConstructoraUdcDBEntities())
            {
                try
                {
                    if(db.SEC_Role.Where(x => x.name.ToUpper().Equals(dbModel.Name.ToUpper())).Count() > 0)
                    {
                        return 3;
                    }
                    
                    SEC_Role role = new SEC_Role()
                    {
                        name = dbModel.Name,
                        removed = false
                    };

                    db.SEC_Role.Add(role);
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }

        }

        public int RecordUpdate( RoleDbModel dbModel )
        {
            return 1;
        }

        public int RecordRemove( RoleDbModel dbModel )
        {
            return 1;
        }

        public IEnumerable<RoleDbModel> RecordList( String filter )
        {
            return null;
        }
    }
}
