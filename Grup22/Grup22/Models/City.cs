using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Grup22.Models
{
    public class City
    {
        [Key]
        public int CityID { get; set; }
        [Required, MaxLength(100)]
        public string CityName { get; set; }
    }
}
