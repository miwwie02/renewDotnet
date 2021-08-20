using Movie_Repo.Models;
using Movie_Repo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Repo.Services
{
    public interface IMasterTypeService
    {
        IEnumerable<MasterType> GetAll();
        MasterType GetById(int id);

        bool AddType(MasterType model);

        bool UpdateType(MasterType model);

        bool DeleteType(int id);
    }
    public class MasterTypeService : IMasterTypeService
    {
        private readonly IMasterTypeRepository masterTypeRepository;
        public MasterTypeService(IMasterTypeRepository masterTypeRepository)
        {
            this.masterTypeRepository = masterTypeRepository;
        }
        public IEnumerable<MasterType> GetAll()
        {
            var listType = masterTypeRepository.GetAll();
            return listType;
        }

        public MasterType GetById(int id)
        {
            var idType = masterTypeRepository.GetById(id);
            return idType;
        }
        public bool AddType(MasterType model)
        {
            return masterTypeRepository.Add(model) > 0;
        }

        public bool UpdateType(MasterType model)
        {
            var masterType = masterTypeRepository.GetById(model.Id);
            masterType.Name = model.Name;
            return masterTypeRepository.Update(masterType) > 0;
        }

        public bool DeleteType(int id)
        {
            var masterType = new MasterType { Id = id };
            return masterTypeRepository.Delete(masterType) > 0;
        }

    }
}
