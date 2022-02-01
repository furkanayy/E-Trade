using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grup22.Models
{
    [Table("Fabrika Kullanıcısı")]
    public class FactoryUser
    {
        [Key]
        public int factoryUserId { get; set; }
        [Required, MaxLength(30, ErrorMessage = "30 karakterden uzun olamaz."), DisplayName("E-posta Adresi")]
        public string factoryUserEmail { get; set; }
        [Required, DisplayName("Şifre")]
        public string factoryUserPassword { get; set; }
        [Required, MaxLength(50, ErrorMessage = "50 karakterden uzun olamaz."), DisplayName("Firma Adı")]
        public string factoryUserName { get; set; }
        [Required, DisplayName("Adres")]
        public string factoryUserAdress { get; set; }
        public IEnumerable<Product> factoryProducts { get; set; }
        public IEnumerable<Seller> factorySellers { get; set; }
    }
}
