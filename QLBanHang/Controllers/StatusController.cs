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
    public class StatusController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public StatusController(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Lấy tất cả danh sách Statuss
        /// </summary>
        /// <returns>Danh sách Statuss</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusDTO>>> Get()
        {
            try
            {
                var data = await _context.Status
                    .Include(r => r.CreatedUser)
                    .Include(r => r.UpdatedUser).ToArrayAsync();
                var model = _mapper.Map<IEnumerable<StatusDTO>>(data);
                return new JsonResult(model);
            }
            catch (ArgumentException ex)
            {
                return BadRequest("Not good");
            }
        }


        /// <summary>
        /// Lấy tất cả danh sách Statuss với Id
        /// </summary>
        /// <returns>Danh sách Statuss</returns>
        /// <param name = "Id">Tham số là Id của Status</param>
        [HttpGet("Id")]
        public Status Get([FromQuery] int Id)
        {
            return _context.Status.Where(Res => Res.Id == Id).FirstOrDefault();
        }

        /// <summary>
        /// Thêm mới Statuss
        /// </summary>
        /// <returns>Statuss</returns>
        [HttpPost]
        public Status Post([FromBody] Status Status)
        {
            var createdUser = _context.User.Find(Status.CreatedUser.Id);
            Status.CreatedUser = createdUser;
            var updatedUser = _context.User.Find(Status.UpdatedUser.Id);
            Status.UpdatedUser = updatedUser;

            _context.Status.Add(Status);
            _context.SaveChanges();
            return Status;
        }

      //   /// <summary>
      //   /// Thêm mới Statuss
      //   /// </summary>
      //   /// <returns>Statuss</returns>
      //   [HttpPost]
      //   public async Task<Object> Add([FromBody] Status Status)
      //   {
      //      try
      //      {
      //       var createdUser = _context.User.Find(Status.CreatedUser.Id);
      //       Status.CreatedUser = createdUser;
      //       var updatedUser = _context.User.Find(Status.UpdatedUser.Id);
      //       Status.UpdatedUser = updatedUser;

      //       _context.Status.Add(Status);
      //       _context.SaveChanges();
      //       return Status;
      //      }
      //      catch(Exception ex)
      //      {
      //         return await Task.FromResult(ex.Message);
      //      }
      //   }

        /// <summary> 
        /// Update Status
        /// </summary>
        /// <returns>Status</returns>
        [HttpPut]
        public Status Put([FromBody] Status Status)
        {
            var status = _context.Status.Find(Status.Id);
            if (status == null)
            {
                return Status;
            }
            status.Name = Status.Name;
            status.Phone = Status.Phone;
            status.Description = Status.Description;
            status.Deleted = Status.Deleted;
            var updatedUser = _context.User.Find((Status.UpdatedUser != null) ? Status.UpdatedUser.Id : 1);
            status.UpdatedUser = updatedUser;
            _context.SaveChanges();
            return status;
        }


    }
}