using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;

namespace AdvancedMVCApplication.Models
{
    public class UserModels
    {

        [Required]
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Range(100, 1000000)]
        public decimal Salary { get; set; }
}   } 