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
    public class ImplModel
    {
        /// <summary>
        /// Se agrega un nuevo registro a los Users
        /// </summary>
        /// <param name="dbModel">Representa un objecto con la informacion del rol</param>
        /// <returns>Entero con la respueta: 1, OK. 2, KO. 3, Ya existe</returns>
        public int RecordCreation( UserDbModel dbModel )
        {
            using (ConstructoraUdcDBEntities db = new ConstructoraUdcDBEntities())
            {
                try
                {                    
                    UserModelMapper mapper = new UserModelMapper();
                    SEC_User record = mapper.MapperT2T1(dbModel);

                    record.create_date = dbModel.CurrentDate;
                    record.create_user_id = dbModel.UserInSession;

                    db.SEC_User.Add(record);
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
        public int RecordUpdate( UserDbModel dbModel )
        {
            using (ConstructoraUdcDBEntities db = new ConstructoraUdcDBEntities())
            {
                try
                {
                    var record = db.SEC_User.Where(x => x.id == dbModel.Id).FirstOrDefault();
                    if(record == null)
                    {
                        return 3;
                    }

                    record.name = dbModel.Name;
                    record.lastName = dbModel.LastName;
                    record.document = dbModel.Document;
                    record.phone = dbModel.Phone;
                    record.email = dbModel.Email;
                    record.password_user = dbModel.PasswordUser;
                    record.city_id = dbModel.City;
                    record.update_date = dbModel.CurrentDate;
                    record.update_user_id = dbModel.UserInSession;
                    
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
        public int RecordRemove( UserDbModel dbModel )
        {
            using (ConstructoraUdcDBEntities db = new ConstructoraUdcDBEntities())
            {
                try
                {
                    var record = db.SEC_User.Where(x => x.id == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }

                    //db.SEC_User.Remove(record);        

                    record.removed = true;
                    record.removed_date = dbModel.CurrentDate;
                    record.removed_user_id = dbModel.UserInSession;

                    db.SaveChanges();
                    return 1;                   
                }
                catch
                {
                    return 2;
                }
            }
        }

        public IEnumerable<UserDbModel> RecordList( String filter )
        {
            using (ConstructoraUdcDBEntities db = new ConstructoraUdcDBEntities())
            {
                //var listaLambda = db.SEC_User.Where(x => !x.removed && x.name.ToUpper().Contains(filter.ToUpper())).ToList();

                var listaLinq = from User in db.SEC_User
                                where User.removed && User.name.ToUpper().Contains(filter.ToUpper())
                                select User;

                UserModelMapper mapper = new UserModelMapper();

                var listaFinal = mapper.MapperT1T2(listaLinq);                

                return listaFinal;
            }
        }
    }
}
