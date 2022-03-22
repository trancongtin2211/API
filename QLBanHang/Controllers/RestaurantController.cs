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
   public class RestaurantController : ControllerBase
   {
     private readonly AppDBContext _context;

      public RestaurantController(AppDBContext context)
      {
         _context = context;
      }
        /// <summary>
        /// Lấy tất cả danh sách Restaurants
        /// </summary>
        /// <returns>Danh sách Restaurants</returns>
        [HttpGet]
        public IEnumerable<Restaurant> Get()
        {
            return _context.Restaurant.Where(c => !c.Deleted)
                                        .Include(r => r.CreatedUser)
                                        .Include(r => r.UpdatedUser)
                                        .ToList();
                                
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
            _context.SaveChanges();
            return restaurant;
        }
   }
}