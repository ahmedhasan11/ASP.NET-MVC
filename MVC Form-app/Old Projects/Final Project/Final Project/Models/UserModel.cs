using System.ComponentModel.DataAnnotations;

namespace Final_Project.Models
{
    public class UserModel
    {

        [Required]
        public int id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string phone { get; set; }

        public string address { get; set; }



    }
}
