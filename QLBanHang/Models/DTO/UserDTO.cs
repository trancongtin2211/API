using System;
using System.Collections.Generic;
using QLBanHang.Models;

namespace Models.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Description{get; set;}
        public DateTime Created {get; set;}
        public DateTime Updated {get; set;}
        public bool Deleted {get; set;}
        public bool OffDuty {get; set;}
        public Role Role { get; set; }
        public IEnumerable<UserDTO> CreatedUser {get; set;}
        public IEnumerable<UserDTO> UpdatedUser {get; set;}
    }
}