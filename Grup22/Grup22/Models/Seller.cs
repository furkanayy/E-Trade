using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grup22.Models
{
    [Table("Bayi")]
    public class Seller
    {
        [Key]
        public int sellerId { get; set; }
        [Required, MaxLength(30, ErrorMessage = "30 karakterden uzun olamaz."), DisplayName("E-posta Adresi")]
        public string sellerEmail { get; set; }
        [Required, DisplayName("Şifre")]
        public string sellerPassword { get; set; }
        [Required, MaxLength(50, ErrorMessage = "50 karakterden uzun olamaz."), DisplayName("Bayi Adı")]
        public string sellerName { get; set; }
        [Required, MaxLength(50, ErrorMessage = "50 karakterden uzun olamaz."), DisplayName("Bayi Sorumlusunun Adı")]
        public string sellerOwnersName { get; set; }
        [Required, MaxLength(100)]
        public string sellerCityName { get; set; }
        [Required, MaxLength(50)]
        public string sellerTownName { get; set; }
        [Required, DisplayName("Adres")]
        public string sellerAdress { get; set; }
        [Required]
        public int factoryUserId { get; set; }
        public FactoryUser sellerFactoryUser { get; set; }
        public IEnumerable<ProductSalesRecord> sellerSalesRecord { get; set; }
    }
}
