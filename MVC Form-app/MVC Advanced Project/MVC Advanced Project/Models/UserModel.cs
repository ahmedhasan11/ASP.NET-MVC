using System.ComponentModel.DataAnnotations;

namespace MVC_Advanced_Project.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Phone]
        public int PhoneNumber { get; set; }

        public string Address {  get; set; }


        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }


    }
}
