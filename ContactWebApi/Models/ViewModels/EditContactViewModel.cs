
using System.ComponentModel.DataAnnotations;

namespace ContactWebApi.Models.ViewModels
{
    public class EditContactViewModel
    {       
        public int ContactId { get; set; }
        [Required(ErrorMessage = "Please Write  the FirstName of the contact")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Please writetheLastNameof the contact")]
        public string FirstName { get; set; }     
        public string Adress { get; set; }
        [Required(ErrorMessage = "Please write the email adress of the contact")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "InValid email")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Please write the Phone number of thw contact")]
        public int PhoneNumber { get; set; }
    }
}
