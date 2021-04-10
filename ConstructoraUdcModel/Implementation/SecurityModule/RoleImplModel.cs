using ConstructoraUdcModel.DbModel.SecurityModule;
using ConstructoraUdcModel.Mappers.SecurityModule;
using ConstructoraUdcModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdcModel.Implementation.SecurityModule
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
                    // Verifica si existe un rol con nombre que se quiere crear
                    if(db.SEC_Role.Where(x => x.name.ToUpper().Equals(dbModel.Name.ToUpper())).Count() > 0)
                    {
                        return 3;
                    }

                    RoleModelMapper mapper = new RoleModelMapper();
                    SEC_Role record = mapper.MapperT2T1(dbModel);

                    db.SEC_Role.Add(record);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }

        }

        /// <summary>
        /// Actualizacion de un registro
        /// </summary>
        /// <param name="dbModel"></param>
        /// <returns></returns>
        public int RecordUpdate( RoleDbModel dbModel )
        {
            using (ConstructoraUdcDBEntities db = new ConstructoraUdcDBEntities())
            {
                try
                {
                    var record = db.SEC_Role.Where(x => x.id == dbModel.Id).FirstOrDefault();
                    if(record == null)
                    {
                        return 3;
                    }

                    record.name = dbModel.Name;
                    record.removed = dbModel.Removed;

                    db.SaveChanges();
                    return 1;
                    
                }
                catch
                {
                    return 2;
                }
            }
        }

        /// <summary>
        /// Eliminado lógico de un registro de un registro
        /// </summary>
        /// <param name="dbModel"></param>
        /// <returns></returns>
        public int RecordRemove( RoleDbModel dbModel )
        {
            using (ConstructoraUdcDBEntities db = new ConstructoraUdcDBEntities())
            {
                try
                {
                    var record = db.SEC_Role.Where(x => x.id == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }

                    //db.SEC_Role.Remove(record);        

                    record.removed = true;

                    db.SaveChanges();
                    return 1;                   
                }
                catch
                {
                    return 2;
                }
            }
        }

        public IEnumerable<RoleDbModel> RecordList( String filter )
        {
            using (ConstructoraUdcDBEntities db = new ConstructoraUdcDBEntities())
            {
                //var listaLambda = db.SEC_Role.Where(x => !x.removed && x.name.ToUpper().Contains(filter.ToUpper())).ToList();

                var listaLinq = from role in db.SEC_Role
                                where role.removed && role.name.ToUpper().Contains(filter.ToUpper())
                                select role;

                RoleModelMapper mapper = new RoleModelMapper();

                var listaFinal = mapper.MapperT1T2(listaLinq);                

                return listaFinal;
            }
        }
    }
}
