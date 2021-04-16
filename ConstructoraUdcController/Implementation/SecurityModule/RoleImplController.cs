using ConstructoraUdcController.DTO.SecurityModule;
using ConstructoraUdcController.Mappers.SecurityModule;
using ConstructoraUdcModel.DbModel.SecurityModule;
using ConstructoraUdcModel.Implementation.SecurityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdcController.Implementation.SecurityModule
{
    public class RoleImplController
    {
        private RoleImplModel model;
        public RoleImplController()
        {
            model = new RoleImplModel();
        }

        public int RecordCreation(RoleDTO dto)
        {
            RoleDTOMapper mapper = new RoleDTOMapper();
            RoleDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordCreation(dbModel);
        }

        public int RecordUpdate(RoleDTO dto)
        {
            RoleDTOMapper mapper = new RoleDTOMapper();
            RoleDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordUpdate(dbModel);
        }

        public int RecordRemove(RoleDTO dto)
        {
            RoleDTOMapper mapper = new RoleDTOMapper();
            RoleDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordRemove(dbModel);
        }

        public IEnumerable<RoleDTO> RecordList(String filter)
        {
            var list =  model.RecordList(filter);
            RoleDTOMapper mapper = new RoleDTOMapper();
            return  mapper.MapperT1T2(list);
        }
    }
}
