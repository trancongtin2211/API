using System.ComponentModel.DataAnnotations;
namespace QLBanHang.Models
{
    public class User{

        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}