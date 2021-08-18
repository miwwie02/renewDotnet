using Microsoft.AspNetCore.Mvc;
using Movie_Repo.Models;
using Movie_Repo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Repo.ApiControllers
{
    [Route("api/mastermovies")]
    [ApiController]
    public class MasterMoviesController : Controller
    {
        private readonly IMasterMovieService _masterMovieService;
        public MasterMoviesController(IMasterMovieService masterMovieService)
        {
            _masterMovieService = masterMovieService;
        }

        [HttpGet]
        [Route("getall")]
        public IEnumerable<MasterMovie> GetAll()
        {
            var movies = _masterMovieService.GetAll();
            return movies;
        }

        [HttpGet]
        [Route("getbyid/{id?}")]
        public MasterMovie GetById(int id)
        {
            var item = _masterMovieService.GetById(id);
            return item;
        }

        [HttpPost]
        [Route("AddMovie")]
        public IActionResult AddMovie([FromBody] MasterMovie item)
        {
            _masterMovieService.AddMovie(item);
            return Ok();
        } 

        [HttpPut]
        [Route("UpdateMovie")]
        public IActionResult UpdateMovie(MasterMovie item)
        {
            _masterMovieService.UpdateMovie(item);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteMovies")]
        public IActionResult DeleteMovie(int id)
        {
            _masterMovieService.DeleteMovie(id);
            return Ok();
        }


    }
}
