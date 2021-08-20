using Dapper;
using Microsoft.Extensions.Configuration;
using Movie_Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Repo.Repositories
{
    public interface IMasterTypeRepository
    {
        IEnumerable<MasterType> GetAll();
        MasterType GetById(int id);

        int Add(MasterType model);

        int Update(MasterType model);

        int Delete(MasterType model);
    }
    public class MasterTypeRepository : GenericRepository<MasterType> , IMasterTypeRepository
    {
        public MasterTypeRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public override string CreateSelectString()
        {
            var commandStr = "SELECT * FROM MasterType";
            return commandStr;
        }

        public override int Add(MasterType tModel)
        {
            var commandStr = string.Format(@"INSERT INTO [dbo].[MasterType]
                                                               ([Name])
                                                               VALUES
                                                               (@Name)");
            return _db.Execute(commandStr, MappingParameter(tModel));
        }

        public override int Delete(MasterType tModel)
        {
            var commandStr = string.Format(@"DELETE FROM [dbo].[MasterType]
                                                    WHERE [Id] = @Id");

            return _db.Execute(commandStr, new { Id = tModel.Id });
        }

        public override int Update(MasterType tModel)
        {
            var commanStr = string.Format(@"UPDATE [dbo].[MasterType]
                                                    SET[Name] = @Name
                                                    WHERE [Id] = @Id ");
            return _db.Execute(commanStr, MappingParameter(tModel));
        }

        public object MappingParameter(MasterType tModel)
        {
            return new
            {
                Id = tModel.Id,
                Name = tModel.Name,
            };
        }
    }
}
