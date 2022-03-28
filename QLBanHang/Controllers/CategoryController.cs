using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QLBanHang.Data;
using QLBanHang.Models;

namespace QLBanHang.Controllers
{
   [ApiController]
    [Route("api/[controller]")]
   public  class CategoryController : ControllerBase
   {
     private readonly AppDBContext _context;

      public CategoryController(AppDBContext context)
      {
         _context = context;
      }

      /// <summary>
      /// Lấy tất cả danh sách Restaurants
      /// </summary>
      /// <returns>Danh sách Restaurants</returns>
      [HttpGet]
      public IEnumerable<Category> Get()
      {
         return _context.Category.ToList();
      }

      /// <summary>
      /// Lấy tất cả danh sách Restaurants với Id
      /// </summary>
      /// <returns>Danh sách Restaurants</returns>
      /// <param name = "Id">Tham số là Id của Restaurant</param>
      [HttpGet("id")]
      public async Task<IActionResult> Category(int? id)
      {
         try
         {
            if(id == null)
            {
               return NotFound();
            }
            var cata = await _context.Category.FirstOrDefaultAsync(m => m.Id == id );
            if(cata == null)
            {
              return NotFound();
            }
            return Ok(cata);
         }
         catch(ArgumentException ex)
         {
            return BadRequest(ex.Message);
         }
      }

      // [HttpPost]
      // public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource)
      // {
      // }

      /// <summary>
      /// Thêm mới Statuss
      /// </summary>
      /// <returns>Statuss</returns>
      [HttpPost]
      public async Task<Object> Add([FromBody] Category Category)
      {
           try
           {
            // var createdUser =  _context.User.Find(Category.CreatedUser.Id);
            // Category.CreatedUser = createdUser;
            // var updatedUser = _context.User.Find(Status.UpdatedUser.Id);
            // Status.UpdatedUser = updatedUser;
             _context.Category.Add(Category);
            _context.SaveChanges();
            return  Category;
           }
           catch(Exception ex)
           {
              return await Task.FromResult(ex.Message);
           }
      }
   }
}