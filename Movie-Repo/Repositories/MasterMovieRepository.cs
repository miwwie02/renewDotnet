using Dapper;
using Microsoft.Extensions.Configuration;
using Movie_Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Repo.Repositories
{
    public interface IMasterMovieRepository
    {
        IEnumerable<MasterMovie> GetAll();
        MasterMovie GetById(int id);

        int Add(MasterMovie model);

        int Update(MasterMovie model);

        int Delete(MasterMovie model);

    }

    public class MasterMovieRepository : GenericRepository<MasterMovie> , IMasterMovieRepository
    {
        public MasterMovieRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public override string CreateSelectString()
        {
            var commandStr = "SELECT * FROM MasterMovie";
            return commandStr;
        }

        public override int Add(MasterMovie tModel)
        {
            var commandStr = string.Format(@"INSERT INTO [dbo].[MasterMovie]
                                                               ([Title]
                                                               ,[ImgLink])
                                                               VALUES
                                                               (@Title
                                                               ,@ImgLink)");
            return _db.Execute(commandStr, MappingParameter(tModel));
        }

        public override int Delete(MasterMovie tModel)
        {
            var commandStr = string.Format(@"DELETE FROM [dbo].[MasterMovie]
                                                    WHERE [Id] = @Id");

            return _db.Execute(commandStr, new { Id = tModel.Id });
        }

        public override int Update(MasterMovie tModel)
        {
            var commanStr = string.Format(@"UPDATE [dbo].[MasterMovie]
                                                    SET[Title] = @Title
                                                    ,[ImgLink] = @ImgLink
                                                    WHERE [Id] = @Id ");
            return _db.Execute(commanStr, MappingParameter(tModel));
        }


        public object MappingParameter(MasterMovie tModel)
        {
            return new
            {
                Id = tModel.Id,
                Title = tModel.Title,
                ImgLink = tModel.ImgLink
            };
        }
    }
}
