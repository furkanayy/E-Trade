using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grup22.Models
{
    [Table ("Ürün Satış Kaydı")]
    public class ProductSalesRecord
    {
        [Key]
        public int salesRecordId { get; set; }
        public bool salesRecordConfirmation { get; set; }
        [Required, DisplayName("Miktar")]
        public int salesRecordAmount { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime orderCreationDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? orderCompletionDate { get; set; }
        public int? sellerId { get; set; }
        public int productId { get; set; }
        public Product salesRecordProduct { get; set; }
    }
}
