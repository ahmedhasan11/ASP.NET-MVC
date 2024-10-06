
using System.ComponentModel.DataAnnotations;

namespace Form_Application.Models
{
    public class UserModel
    {
        [Required]
        public int id { set; get; }

        [Required]
        public string FirstName { set; get; }

        [Required]
        public string LastName { set; get; }

        [Required]
        public string Email { set; get; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { set; get; }

        [StringLength(50)]
        public string address { set; get; }

        [Range(1000, 6000)]
        public int salary { set; get; }

    }
}
