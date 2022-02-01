using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grup22.Models
{
    [Table("Ürün")]
    public class Product
    {
        [Key]
        public int productId { get; set; }
        [Required, MaxLength(30, ErrorMessage = "30 karakterden uzun olamaz."), DisplayName("Ürün Adı")]
        public string productName { get; set; }
        [Required, DisplayName("Ürün Açıklaması")]
        public string productDescription { get; set; }
        [Required, DisplayName("Stok Adedi")]
        public int? productStock { get; set; }
        [Required, DisplayName("Ürün Fiyatı")]
        public double? productPrice { get; set; }
        [DisplayName("Ürün Resmi")]
        public string productImageUrl { get; set; }
        [Required]
        public int factoryUserId { get; set; }
        public FactoryUser productFactoryUser { get; set; }
    }
}
