using Movie_Repo.Models;
using Movie_Repo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Repo.Services
{
    public interface IMasterMovieService
    {
        IEnumerable<MasterMovie> GetAll();
        MasterMovie GetById(int id);

        bool AddMovie(MasterMovie model);

        bool UpdateMovie(MasterMovie model);

        bool DeleteMovie(int id);
    }
    public class MasterMovieService : IMasterMovieService
    {
        private readonly IMasterMovieRepository masterMovieRepository;
        public MasterMovieService(IMasterMovieRepository masterMovieRepository)
        {
            this.masterMovieRepository = masterMovieRepository;
        }
        public IEnumerable<MasterMovie> GetAll()
        {
            var listMovie = masterMovieRepository.GetAll();
            return listMovie;
        }

        public MasterMovie GetById(int id)
        {
            var idMovie = masterMovieRepository.GetById(id);
            return idMovie;
        }

        public bool AddMovie(MasterMovie model)
        {
            return masterMovieRepository.Add(model) > 0;
        }

        public bool UpdateMovie(MasterMovie model)
        {
            var masterMovie = masterMovieRepository.GetById(model.Id);
            masterMovie.Title = model.Title;
            masterMovie.ImgLink = model.ImgLink;
            masterMovie.Time = model.Time;
            masterMovie.Date = model.Date;
            masterMovie.Type = model.Type;
            return masterMovieRepository.Update(masterMovie) > 0;
        }

        public bool DeleteMovie(int id)
        {
            var masterMovie = new MasterMovie { Id = id };
            return masterMovieRepository.Delete(masterMovie) > 0;
        }
    }
}
