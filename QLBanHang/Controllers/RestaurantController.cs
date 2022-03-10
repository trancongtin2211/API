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
   public  class RestaurantController : ControllerBase
   {
     private readonly AppDBContext _context;

      public RestaurantController(AppDBContext context)
      {
         _context = context;
      }
        [HttpGet]
        public IEnumerable<Restaurant> Get()
        {
            return _context.Restaurant.ToList();
        }

        [HttpGet("Id")]
        public Restaurant Get([FromQuery] int Id)
        {
            return _context.Restaurant.Where(Res => Res.Id == Id).FirstOrDefault();
        }

        [HttpPost]
        public Restaurant Post([FromQuery] Restaurant Restaurant)
        {
            _context.Restaurant.Add(Restaurant);
            _context.SaveChanges();
            return Restaurant;
        }
      
   }
}