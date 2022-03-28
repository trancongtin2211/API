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
   public class RestaurantController : ControllerBase
   {
     private readonly AppDBContext _context;
     private readonly IMapper _mapper;

      public RestaurantController(AppDBContext context, IMapper mapper)
      {
         _context = context;
         _mapper = mapper;
      }

        /// <summary>
        /// Lấy tất cả danh sách Restaurants
        /// </summary>
        /// <returns>Danh sách Restaurants</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantDTO>>> Get()
        {
            try
            {
                var data = await _context.Restaurant
                    .Include(r => r.CreatedUser)
                    .Include(r => r.UpdatedUser).ToArrayAsync();
                var model = _mapper.Map<IEnumerable<RestaurantDTO>>(data);
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
        public Restaurant Get([FromQuery] int Id)
        {
            return _context.Restaurant.Where(Res => Res.Id == Id).FirstOrDefault();
        }

        /// <summary>
        /// Thêm mới Restaurants
        /// </summary>
        /// <returns>Restaurants</returns>
        [HttpPost]
        public Restaurant Post([FromBody] Restaurant Restaurant)
        {
            var createdUser = _context.User.Find(Restaurant.CreatedUser.Id);
            Restaurant.CreatedUser = createdUser;
            var updatedUser = _context.User.Find(Restaurant.UpdatedUser.Id);
            Restaurant.UpdatedUser = updatedUser;

            _context.Restaurant.Add(Restaurant);
            _context.SaveChanges();
            return Restaurant;
        }
      
        /// <summary> 
        /// Update Restaurant
        /// </summary>
        /// <returns>Restaurant</returns>
        [HttpPut]
        public Restaurant Put([FromBody] Restaurant Restaurant)
        {
            var restaurant = _context.Restaurant.Find(Restaurant.Id);
            if(restaurant == null)
            {
                return Restaurant;
            }
            restaurant.Name = Restaurant.Name;
            restaurant.Address = Restaurant.Address;
            restaurant.Phone = Restaurant.Phone;
            restaurant.Description = Restaurant.Description;
            restaurant.Deleted = Restaurant.Deleted;
            var updatedUser = _context.User.Find((Restaurant.UpdatedUser != null) ? Restaurant.UpdatedUser.Id : 1);
            restaurant.UpdatedUser = updatedUser;
            _context.SaveChanges();
            return restaurant;
        }
   }
}