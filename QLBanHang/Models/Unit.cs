using System;
using System.ComponentModel.DataAnnotations;
namespace QLBanHang.Models
{
    public class Unit
    {
       [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; } 
        public UnitType UnitType { get; set; }
    }
}