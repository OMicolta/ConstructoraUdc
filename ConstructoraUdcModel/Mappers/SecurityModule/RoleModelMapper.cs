using ConstructoraUdcModel.DbModel.SecurityModule;
using ConstructoraUdcModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdcModel.Mappers.SecurityModule
{
    public class RoleModelMapper : GeneralMapper<SEC_Role, RoleDbModel>
    {
        public override RoleDbModel MapperT1T2(SEC_Role input)
        {
            return new RoleDbModel()
            {
                Id = input.id,
                Name = input.name,
                Description = input.description,
                Removed = input.removed
            };
        }

        public override IEnumerable<RoleDbModel> MapperT1T2(IEnumerable<SEC_Role> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override SEC_Role MapperT2T1(RoleDbModel input)
        {
            return new SEC_Role()
            {
                id = input.Id,
                name = input.Name,
                description = input.Description,
                removed = input.Removed
            };
        }

        public override IEnumerable<SEC_Role> MapperT2T1(IEnumerable<RoleDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}
