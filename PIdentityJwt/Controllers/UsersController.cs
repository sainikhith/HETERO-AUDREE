using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PIdentityJwt.AppExceptions;
using PIdentityJwt.DTOs;
using PIdentityJwt.Models;
using PIdentityJwt.Services;
using Microsoft.EntityFrameworkCore;


namespace PIdentityJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IRoleService _roleService;
        private IMapper _mapper;
        private readonly DataContext _dataContext;
        private readonly AppSettings _appSettings;

        public UsersController(
            IUserService userService,
            IRoleService roleService,
            IMapper mapper,
            IOptions<AppSettings> appSettings,DataContext dataContext)
            {
                _userService = userService;
                _roleService = roleService;
                _mapper = mapper;
            _dataContext = dataContext;
            _appSettings = appSettings.Value;
            }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody]UserDto userDto)
        {
            var user = _userService.Authenticate(userDto.Username, userDto.Password);
            if (user == null)
                return Unauthorized();
            //var claims = GetRoleClaims()
            //new List<Claim>;
            //var role = _roleService.GetRolesByUserID(user.Id);
             var role = _roleService.GetRolesByUserID(user.Id);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            int[] userroles = _dataContext.UsersInRoles.Where(w => w.UserId == user.Id).Select(x => x.RoleId).ToArray();
            //var usero = _dataContext.Roles.Where(w => w.Id == userroles.).ToList();
            //getting menu's and submenu's
            //var menus = (from 
            //             Mm in _dataContext.MenuMasters
            //             join Sm in _dataContext.Submenus on Mm.Id equals Sm.RoleId
                          
            //             select new
            //             {
            //                 Mm.Menu,
            //                 Sm.Name,
                             
            //             }).ToList();


            //getting role names
            var q = (from Ur in _dataContext.UsersInRoles
                     join ro in _dataContext.Roles on Ur.RoleId equals ro.Id                     
                     select new 
                     {
                         ro.Rolename,                        
                     }).ToList();
            // To Get Menus and submenus
            
            var MenuandSubmenus = (from a in _dataContext.MenuMasters
                                   join b in _dataContext.Submenus on a.Id equals b.MenuMasterId
                                   //join c in _dataContext.Roles on b.RoleId equals c.Id
                                   select new
                                   {
                                       a.Menu,
                                       b.Description,                                       //c.Id, //Role Id
                                       b.RoleId// submenu table role id
                                   }).ToList();

            // To filter menus based on roles

            var rolebasedMenus = (from a in MenuandSubmenus
                                  join b in role on a.RoleId equals b.Id
                                  select new
                                  {
                                      a.Menu,
                                      a.Description,
                                    }).ToList();
           List<Submenu> submenus = _dataContext.Submenus.Where(x=>userroles.Contains(x.RoleId)).Include("MenuMaster").ToList();
            
            //int[] rolesarray = db.PlantRoleAssignment.Where(w => uplantassign.Contains(w.UserPlantId)).Distinct().Select(s => s.RoleId).ToArray();


            List<Claim> obj = new List<Claim>();
          
            foreach (var item in q)
            {
                //var rolename = _dataContext.UsersInRoles.Where(w => w.UserId == item.RoleId).ToList();
                obj.Add(new Claim(ClaimTypes.Role, item.Rolename));

            }
          
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(obj),

                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
           
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString,
                //menusubmens= MenuandSubmenus,
                //submenus= rolebasedMenus
                submenus
            });
        }

        //[AllowAnonymous]
        //[HttpPost]
        //public IActionResult Register([FromBody]UserDto userDto)
        //{
        //    // map dto to entity
        //    var user = _mapper.Map<User>(userDto);
        //    try
        //    {
        //        // save 
        //        _userService.Create(user, userDto.Password);
        //        return Ok();
        //    }
        //    catch (AppException ex)
        //    {
        //        // return error message if there was an exception
        //        return BadRequest(ex.Message);
        //    }
        //}
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()


        {
            var users = _userService.GetAll();
            var userDtos = _mapper.Map<IList<UserDto>>(users);
            return Ok(userDtos);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UserDto userDto)
        {
            // map dto to entity and set id
            var user = _mapper.Map<User>(userDto);
            user.Id = id;

            try
            {
                // save 
                _userService.Update(user, userDto.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}