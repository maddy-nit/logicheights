using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Logic_Heights.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage = "Name Required")]
        [StringLength(100, ErrorMessage = "Less than 5 characters", MinimumLength = 5)]
        [Display(Name = "Your Name:", Prompt = "Enter Your Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [Display(Name = "Email:")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email Format is wrong")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile Number Required")]
        [StringLength(10, ErrorMessage = "Not a Mobile Number")]
        [Display(Name = "Mobile:")]
        public string Phone { get; set; }

        
        [Required(ErrorMessage = "Message Required")]
        [StringLength(500, ErrorMessage = "Minimum 10 Characters Required in Message", MinimumLength = 10)]
        [Display(Name = "Message:")]
        public string Message { get; set; }
    }
}