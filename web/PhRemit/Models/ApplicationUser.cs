using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PhRemit.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Secondary Email")]
        public string SecondaryEmail { get; set; }

        [Display(Name = "ID Number")]
        public string IdentificationNumber { get; set; }

        [Display(Name = "Expiration")]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "Promo Code")]
        public string PromoCode { get; set; }

        public int CountryId { get; set; }
        public virtual Country Countries { get; set; }

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
