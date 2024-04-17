using System.ComponentModel.DataAnnotations;

namespace Project1.Modal
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }
        public string UserPassWord { get; set; }

        public DateTime CreateUserDate { get; set; }
    }
}
