namespace Models.DTO
{
   public class RestaurantDTO
   {
       public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }
        public UserDTO CreatedUser{get; set;}
        public UserDTO UpdatedUser{get; set;}
   } 
}