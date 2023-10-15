using System;
using System.ComponentModel.DataAnnotations;

namespace PROJECT.Models
{
    public class Counselling
    {
        [Required]
        [Key]
        public int CounsellingId { get; set; }

        [Required(ErrorMessage = "Please select a counselling type.")]
        public string CounsellingType { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a preferred date.")]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "Please enter a preferred time.")]
        [DataType(DataType.Time)]
        public DateTime AppointmentTime { get; set; }

        [Display(Name = "Counsellor")]
        public string CounsellorName { get; set; }
    }
}
