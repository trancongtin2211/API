using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.DTO;
using QLBanHang.Data;
using QLBanHang.Models;

namespace QLBanHang.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public UserController(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Lấy tất cả danh sách Restaurants
        /// </summary>
        /// <returns>Danh sách Restaurants</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
        {
            try
            {
                var data = await _context.User.Select(d => new User
                {
                    Id = d.Id,
                    Username = d.Username,
                    Description = d.Description,
                    Created = d.Created,
                    Updated = d.Updated,
                    Deleted = d.Deleted,
                    OffDuty = d.OffDuty,
                    Role = d.Role,
                    CreatedUser = _context.User
                      .Where(c => c.Id == d.CreatedUserId)
                      .Select(s => new User
                      {
                          Id = s.Id,
                          Username = s.Username,
                          Description = s.Description,
                          Created = s.Created,
                          Updated = s.Updated,
                          Deleted = s.Deleted,
                          OffDuty = s.OffDuty,
                          Role = s.Role
                      }).ToList(),
                     UpdatedUser = _context.User
                      .Where(c => c.Id == d.CreatedUserId)
                      .Select(s => new User
                      {
                          Id = s.Id,
                          Username = s.Username,
                          Description = s.Description,
                          Created = s.Created,
                          Updated = s.Updated,
                          Deleted = s.Deleted,
                          OffDuty = s.OffDuty,
                          Role = s.Role
                      }).ToList()
                }).ToArrayAsync();
                var model = _mapper.Map<IEnumerable<UserDTO>>(data);
                return new JsonResult(model);
            }
            catch(ArgumentException ex)
            {
               return BadRequest(ex.Message);
            }
      }

        /// <summary>
        /// Lấy tất cả danh sách Restaurants với Id
        /// </summary>
        /// <returns>Danh sách Restaurants</returns>
        /// <param name = "Id">Tham số là Id của Restaurant</param>
        [HttpGet("Id")]
        public User Get([FromQuery] int Id)
        {
            return _context.User.Where(Res => Res.Id == Id).FirstOrDefault();
        }

        /// <summary>
        /// Thêm mới Restaurants
        /// </summary>
        /// <returns>Restaurants</returns>
        [HttpPost]
        public User Post([FromBody] User User)
        {
            _context.User.Add(User);
            _context.SaveChanges();
            return User;
        }

         //  /// <summary>
         //  /// Update Restaurant
         //  /// </summary>
         //  /// <returns>Restaurant</returns>
         //  [HttpPut]
         //  public User Put([FromBody] User User)
         //  {
         //      var user = _context.User.Find(User.Id);
         //      if(User == null)
         //      {
         //          return User;
         //      }
         //      User.Name = Restaurant.Name;
         //      User.Address = Restaurant.Address;
         //      User.Phone = Restaurant.Phone;
         //      User.Description = Restaurant.Description;
         //      _context.SaveChanges();
         //      return restaurant;
         //  }
    }
}