using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrackerTwo.Models
{
    public class LicenceItem
    {
        public Guid Id { get; set; }

        //TODO Move DataAnnotations to EntityType Configuration
        [Required]
        public string User { get; set; }
        [Required]
        public string Key { get; set; }

        public DateTimeOffset? ExpiresOn { get; set;}

        public bool IsDisabled { get; set; }
    }
}
