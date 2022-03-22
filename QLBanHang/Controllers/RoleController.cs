using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QLBanHang.Data;
using QLBanHang.Models;

namespace QLBanHang.Controllers
{
   [ApiController]
    [Route("api/[controller]")]
   public  class RoleController : ControllerBase
   {
     private readonly AppDBContext _context;

      public RoleController(AppDBContext context)
      {
         _context = context;
      }

        [HttpGet]
        public IEnumerable<Role> Get()
        {
            return _context.Role.ToList();
        }

        [HttpGet("Id")]
        public Role Get([FromQuery] int Id)
        {
            return _context.Role.Where(role => role.Id == Id).FirstOrDefault();
        }

        [HttpPost]
        public Role Post([FromBody] Role Role)
        {
            _context.Role.Add(Role);
            _context.SaveChanges();
            return Role;
        }
   }
}