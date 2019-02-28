using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.Models
{
    public class PointOfInterestForUpdateDto
    {
        [Required(ErrorMessage = "You Should Provide a Name Value.")]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }

        [ForeignKey("CityId")]
        public CityDto City { get; set; }
        public int CityId { get; set; }
    }
}
