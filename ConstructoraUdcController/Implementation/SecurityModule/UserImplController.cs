using ConstructoraUdcController.DTO.SecurityModule;
using ConstructoraUdcController.Mappers.SecurityModule;
using ConstructoraUdcController.Services;
using ConstructoraUdcModel.DbModel.SecurityModule;
using ConstructoraUdcModel.Implementation.SecurityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdcController.Implementation.SecurityModule
{
    public class UserImplController
    {
        private UserImplModel model;
        public UserImplController()
        {
            model = new UserImplModel();
        }

        public int RecordCreation(UserDTO dto)
        {
            UserDTOMapper mapper = new UserDTOMapper();
            UserDbModel dbModel = mapper.MapperT2T1(dto);
            Encrypt enc = new Encrypt();
            string randomPassword = enc.RandomString(10);
            string newPassword = enc.CreateMD5(randomPassword);
            dbModel.PasswordUser = enc.CreateMD5(randomPassword);
            int response = model.RecordCreation(dbModel);
            // Verify if user was saved to send email
            if(response == 1)
            {
                new Notifications().sendEmail("User registration", "Content...", dto.Email, "test@ucaldas.edu.co");
            }
            return response;
        }

        public int RecordUpdate(UserDTO dto)
        {
            UserDTOMapper mapper = new UserDTOMapper();
            UserDbModel dbModel = mapper.MapperT2T1(dto);
            dbModel.PasswordUser = new Encrypt().CreateMD5(dbModel.PasswordUser);
            return model.RecordUpdate(dbModel);
        }

        public int RecordRemove(UserDTO dto)
        {
            UserDTOMapper mapper = new UserDTOMapper();
            UserDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordRemove(dbModel);
        }

        public IEnumerable<UserDTO> RecordList(String filter)
        {
            var list =  model.RecordList(filter);
            UserDTOMapper mapper = new UserDTOMapper();
            return  mapper.MapperT1T2(list);
        }

        public UserDTO Login(UserDTO dto)
        {
            UserDTOMapper mapper = new UserDTOMapper();
            UserDbModel dbModel = mapper.MapperT2T1(dto);
            dbModel.PasswordUser = new Encrypt().CreateMD5(dbModel.PasswordUser);
            var obj = model.Login(dbModel);
            return mapper.MapperT1T2(obj);
        }

        public int PasswordReset(string email)
        {
            Encrypt enc = new Encrypt();
            string randomPassword = enc.RandomString(10);
            string newPassword = enc.CreateMD5(randomPassword);
            var response = model.PasswordReset(email, newPassword);
            if (response == 1)
            {
                new Notifications().sendEmail("Password change", "Content...", email, "test@ucaldas.edu.co");
            }
            return response;
        }

        public int ChangePassword(string currentPassword, string newPassword, int userId)
        {
            string email = string.Empty;
            var response = model.ChangePassword(currentPassword, newPassword, userId, out email);
            if (response == 1)
            {
                new Notifications().sendEmail("Password reset", "Content...", email, "test@ucaldas.edu.co");
            }
            return response;
        }
    }
}
