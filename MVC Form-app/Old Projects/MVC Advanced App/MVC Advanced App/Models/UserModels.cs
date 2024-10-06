using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_Advanced_App.Models
{
    public class UserModels
    {
        [Required]
        public int id {  get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First name is required")]
        public string Firstname {  get; set; }


        [Required]
        public string Lastname { get; set; }


        public int Salary { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }


    }
}
