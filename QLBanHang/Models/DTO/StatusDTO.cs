using System;
using QLBanHang.Models;

namespace Models.DTO
{
    public class StatusDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }
        public UserDTO CreatedUser{get; set;}
        public UserDTO UpdatedUser{get; set;}
    }
}