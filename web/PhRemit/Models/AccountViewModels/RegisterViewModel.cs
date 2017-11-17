using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhRemit.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Residential Address")]
        public string ResidentialAddress { get; set; }

        [Required]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Secondary Email")]
        public string SecondaryEmail { get; set; }

        [Required]
        [Display(Name = "ID Number")]
        public string IdentificationNumber { get; set; }

        [Required]
        [Display(Name = "Expiration")]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "Promo Code")]
        public string PromoCode { get; set; }

        [Phone]
        [Required]
        [Display(Name = "Australian mobile number")]
        public string PhoneNumber { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public int StateId { get; set; }
        public virtual State State { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }

        public int NationalityId { get; set; }
        public virtual Nationality Nationality { get; set; }

        public int CivilStatusId { get; set; }
        public virtual CivilStatus CivilStatus { get; set; }

        public int IdentificationTypeId { get; set; }
        public virtual IdentificationType IdentificationType { get; set; }
    }
}
