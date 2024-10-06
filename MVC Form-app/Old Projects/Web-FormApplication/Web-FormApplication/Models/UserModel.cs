using System.ComponentModel.DataAnnotations;

namespace Web_FormApplication.Models
{
    public class UserModel
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get;set; }

        public string Address { get; set; }

        [Required]
        public int PhoneNumber {  get; set; }

        [Required]

        public string Email { get; set; }

        [DataType(DataType.Date)]
        
        public DateTime DateOfBirth { get; set; }

    }
}
