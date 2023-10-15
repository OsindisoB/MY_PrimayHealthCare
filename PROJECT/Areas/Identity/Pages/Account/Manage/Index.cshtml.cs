// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PROJECT.Data;

namespace PROJECT.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {


            [Required]
            public string PatientName { get; set; }

            [Required]
            public string PatientSurrname { get; set; }

            [Required]
            [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone number. The phone number must have exactly 10 digits.")]
            public string PhoneNumber { get; set; }
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            /// 

            public DateTime DateOfBirth { get; set; }

            [Required(ErrorMessage = "Gender is required.")]
            public string Gender { get; set; }

            //[Required(ErrorMessage = "Please enter your email address.")]
            //[EmailAddress(ErrorMessage = "Invalid email address format.")]
            //[Display(Name = "Email Address")]
            //public string EmailAddress { get; set; }

            [Required(ErrorMessage = "Street is required.")]
            public string Street { get; set; }

            [Required(ErrorMessage = "City is required.")]
            public string City { get; set; }

            [Required(ErrorMessage = "Please select province.")]
            public string Province { get; set; }

            [Required(ErrorMessage = "Zip Code is required.")]
            [Display(Name = "Zip Code")]
            public string ZipCode { get; set; }

            [Required(ErrorMessage = "Medical history is required, please enter N/A if you don't history.")]
            [Display(Name = "Medical History")]
            public string MedicalHistory { get; set; }

            // Optional properties (no required validation)

            [Display(Name = "Allergies")]
            public string Allergies { get; set; }

            [Display(Name = "Current Medications")]
            public string CurrentMedications { get; set; }

            [Required(ErrorMessage = "Weight is required.")]
            public string Weight { get; set; }

            [Required(ErrorMessage = "Height is required.")]
            public string Height { get; set; }

            [Required(ErrorMessage = "Occupation is required.")]
            public string Occupation { get; set; }

            [Required(ErrorMessage = "Please select a marital status.")]
            [Display(Name = "Marital Status")]
            public string MaritalStatus { get; set; }

            //[Required(ErrorMessage = "Emergency medical consent is required.")]
            [Display(Name = "Emergency Medical Consent")]
            public string EmergencyContact { get; set; }

            [Display(Name = "Blood Type")]
            public string BloodType { get; set; }

        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            //var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var patientName = user.PatientName; 
            var patientSurname = user.PatientSurrname;
            var phoneNumber = user.PhoneNumber;
            //var dateOfBirth = user.DateOfBirth;
            //var gender = user.Gender;
            //var street = user.Street;
            //var city = user.City;
            //var province = user.Province;
            //var zipcode = user.ZipCode;
            //var medicalHistory = user.MedicalHistory;
            //var allergies = user.Allergies;
            //var currentMedication = user.CurrentMedications;
            //var weight = user.Weight;
            //var height = user.Height;
            //var occupation = user.Occupation;
            //var maritalStatus = user.MaritalStatus;
            //var emergencyContact = user.EmergencyContact;



            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                PatientName = patientName, 
                PatientSurrname = patientSurname,
                //DateOfBirth = dateOfBirth,
                //Gender = user.Gender,
                //Street = user.Street,
                //City = user.City,
                //Province = user.Province,
                //ZipCode = user.ZipCode,
                //MedicalHistory = user.MedicalHistory,
                //Allergies = user.Allergies,
                //CurrentMedications = user.CurrentMedications,
                //Weight = user.Weight,
                //Height = user.Height,
                //Occupation = user.Occupation,
                //MaritalStatus = user.MaritalStatus,
                //EmergencyContact = user.EmergencyContact,
                //BloodType = user.BloodType,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            user.PhoneNumber = Input.PhoneNumber;
            user.PatientName = Input.PatientName;
            user.PatientSurrname = Input.PatientSurrname;
            //user.DateOfBirth = Input.DateOfBirth;
            //user.Gender = Input.Gender;
            //user.Street = Input.Street;
            //user.City = Input.City;
            //user.Province = Input.Province;
            //user.ZipCode = Input.ZipCode;
            //user.MedicalHistory = Input.MedicalHistory;
            //user.Allergies = Input.Allergies;
            //user.CurrentMedications = Input.CurrentMedications;
            //user.Weight = Input.Weight;
            //user.Height = Input.Height;
            //user.Occupation = Input.Occupation;
            //user.MaritalStatus = Input.MaritalStatus;
            //user.EmergencyContact = Input.EmergencyContact;
            //user.BloodType = Input.BloodType;

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
