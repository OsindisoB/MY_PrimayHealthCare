using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Microsoft.AspNetCore.Identity

{
    public class ApplicationUser : IdentityUser
    {
       
        public string PatientName { get; set; }

      
        public string PatientSurrname { get; set; }

 
        public string PhoneNumber { get; set; }

      
        //[Required(ErrorMessage = "Please enter your email address.")]
        //[EmailAddress(ErrorMessage = "Invalid email address format.")]
        //[Display(Name = "Email Address")]
        //public string EmailAddress { get; set; }

       
    }
}
