using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QLBanHang.Data;

namespace QLBanHang.Controllers
{
   [ApiController]
    [Route("api/[controller]")]
   public  class UserController : ControllerBase
   {
     private readonly AppDBContext _context;

      public UserController(AppDBContext context)
      {
         _context = context;
      }

      
   }
}