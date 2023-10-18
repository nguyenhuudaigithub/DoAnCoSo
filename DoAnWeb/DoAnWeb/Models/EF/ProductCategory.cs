using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoAnWeb.Models.EF
{
    [Table("table_ProductCategory")]
    public class ProductCategory : CommonAbstracts
    {
        public ProductCategory()
        {
            this.Products = new HashSet<Product>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [StringLength(150)]
        public string title { get; set; }
        [Required]
        [StringLength(150)]
        public string alias { get; set; }
        [StringLength(250)]
        public string description { get; set; }
        [StringLength(250)]
        public string seotitle { get; set; }
        [StringLength(500)]
        public string seodescription { get; set; }
        [StringLength(250)]
        public string seokeywords { get; set; }

        public string icon { get; set; }    
        public ICollection<Product> Products { get; set; }
    }
}