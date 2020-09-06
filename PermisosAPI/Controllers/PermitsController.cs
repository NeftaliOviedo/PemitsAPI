using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PermisosAPI.Models;
using PermisosAPI.Services;

namespace PermisosAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class PermitsController : ControllerBase
    {
        private readonly PermitService _service;
        public PermitsController(PermitService service)
        {
            _service  = service;
        }

        [Route("permit/getAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [Route("permit/create")]
        [HttpPost]

        public IActionResult Create([FromBody] Permit permit)
        {
            var result = _service.CreatePermit(permit);

            if (result) return Ok();
            else return BadRequest();
        }

        [Route("permit/edit")]
        [HttpPut]

        public IActionResult Edit([FromBody] Permit permit)
        {
            var result = _service.UpdatePermit(permit);

            if (result) return Ok();
            else return BadRequest();
        }

      [Route("permit/delete/{permitId}")]
      [HttpDelete]
      public IActionResult Delete(int permitId)
        {
            var result = _service.Delete(permitId);

            if (result) return Ok();
            else return BadRequest();
        }


        [Route("permit/{permitId}")]
        [HttpGet]
        public IActionResult GetPermit(int permitId)
        {
            return Ok(_service.GetPermit(permitId));
        }

        [Route("permitTypes")]
        [HttpGet]
        public IActionResult GetPermitTypes()
        {
            return Ok(_service.GetPermitTypes());
        }
    }

    
}

