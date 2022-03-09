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
   public  class GuestController : ControllerBase
   {
     private readonly AppDBContext _context;

      public GuestController(AppDBContext context)
      {
         _context = context;
      }

      
   }
}