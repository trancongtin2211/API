using System;
using System.Collections.Generic;
using System.Linq;
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
   public  class GuestController : ControllerBase
   {
     private readonly AppDBContext _context;
      private readonly IMapper _mapper;

      public GuestController(AppDBContext context, IMapper mapper)
      {
         _context = context;
         _mapper = mapper;
      }
      
      /// <summary>
        /// Lấy tất cả danh sách Guests
        /// </summary>
        /// <returns>Danh sách Guests</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestDTO>>> Get()
        {
            try
            {
                var data = await _context.Guest
                    .Include(r => r.CreatedUser)
                    .Include(r => r.UpdatedUser).ToArrayAsync();
                var model = _mapper.Map<IEnumerable<GuestDTO>>(data);
                return new JsonResult(model);
            }
            catch(ArgumentException ex)
            {
                return BadRequest("Not good");
            }
        }


        /// <summary>
        /// Lấy tất cả danh sách Guests với Id
        /// </summary>
        /// <returns>Danh sách Guests</returns>
        /// <param name = "Id">Tham số là Id của Guest</param>
        [HttpGet("Id")]
        public Guest Get([FromQuery] int Id)
        {
            return _context.Guest.Where(Res => Res.Id == Id).FirstOrDefault();
        }

        /// <summary>
        /// Thêm mới Guests
        /// </summary>
        /// <returns>Guests</returns>
        [HttpPost]
        public Guest Post([FromBody] Guest Guest)
        {
            var createdUser = _context.User.Find(Guest.CreatedUser.Id);
            Guest.CreatedUser = createdUser;
            var updatedUser = _context.User.Find(Guest.UpdatedUser.Id);
            Guest.UpdatedUser = updatedUser;

            _context.Guest.Add(Guest);
            _context.SaveChanges();
            return Guest;
        }
      
        /// <summary>
        /// Update Guest
        /// </summary>
        /// <returns>Guest</returns>
        [HttpPut]
        public Guest Put([FromBody] Guest Guest)
        {
            var guest = _context.Guest.Find(Guest.Id);
            if(guest == null)
            {
                return Guest;
            }
            guest.Name = Guest.Name;
            guest.Phone = Guest.Phone;
            guest.Description = Guest.Description;
            guest.Deleted = Guest.Deleted;
            var updatedUser = _context.User.Find((Guest.UpdatedUser != null) ? Guest.UpdatedUser.Id : 1);
            guest.UpdatedUser = updatedUser;
            _context.SaveChanges();
            return guest;
        }
   }
}