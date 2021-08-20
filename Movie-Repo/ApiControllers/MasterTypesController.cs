using Microsoft.AspNetCore.Mvc;
using Movie_Repo.Models;
using Movie_Repo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Repo.ApiControllers
{
    [Route("api/mastertypes")]
    [ApiController]
    public class MasterTypeController : Controller
    {
        private readonly IMasterTypeService _masterTypeService;
        public MasterTypeController(IMasterTypeService masterTypeService)
        {
            _masterTypeService = masterTypeService;
        }

        [HttpGet]
        [Route("getall")]
        public IEnumerable<MasterType> GetAll()
        {
            var Types = _masterTypeService.GetAll();
            return Types;
        }

        [HttpGet]
        [Route("getbyid/{id?}")]
        public MasterType GetById(int id)
        {
            var item = _masterTypeService.GetById(id);
            return item;
        }

        [HttpPost]
        [Route("AddType")]
        public IActionResult AddType([FromBody] MasterType item)
        {
            _masterTypeService.AddType(item);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateType")]
        public IActionResult UpdateType(MasterType item)
        {
            _masterTypeService.UpdateType(item);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteTypes")]
        public IActionResult DeleteType(int id)
        {
            _masterTypeService.DeleteType(id);
            return Ok();
        }


    }
}
