using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Options;

using PIdentityJwt.AppExceptions;
using PIdentityJwt.DTOs;
using PIdentityJwt.Services;
using PIdentityJwt.Models;
namespace PIdentityJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleService _roleService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public RoleController(
            IRoleService roleService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _roleService = roleService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        // GET: api/Role
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Role/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Role
        [HttpPost]
        public IActionResult Create([FromBody]RoleDto roleDto)
        {
            // map dto to entity
            var role = _mapper.Map<Role>(roleDto);
            try
            {
                // save 
                _roleService.Create(role);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Role/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
