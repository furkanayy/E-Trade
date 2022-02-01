using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Grup22.Models
{
    public class Town
    {
        [Key]
        public int TownID { get; set; }
        public int CityID { get; set; }
        public City TownsCity { get; set; }
        [Required, MaxLength(50)]
        public string TownName { get; set; }
    }
}
