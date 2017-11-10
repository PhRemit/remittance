using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhRemit.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        public string PostalCode { get; set; }

        [Required]
        public bool Active { get; set; }
        
        public int StateId { get; set; }
        public virtual State State { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
    }
}
