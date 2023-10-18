using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWeb.Models.EF
{
    [Table("table_Product")]
    public class Product : CommonAbstracts
    {
        public Product()
        {
            this.ProductImage = new HashSet<ProductImage>();
            this.OrderDetails = new HashSet<OrderDetail>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [StringLength(250)]
        public string title { get; set; }
        public string alias { get; set; }
        [StringLength(50)]
        public string productcode { get; set; }
        public string description { get; set; }
        [AllowHtml]
        public string detail { get; set; }
        [StringLength(250)]
        public string image { get; set; }
        public decimal price { get; set; }
        public decimal? pricesale { get; set; }
        public int quantity { get; set; }
        public bool ishome { get; set; }
        public bool issale { get; set; }
        public bool ishot { get; set; }
        public bool isactive { get; set; }
        public bool isfeature { get; set; }
        public bool isflashsale { get; set; }

        public int productcategoryid { get; set; }
        [StringLength(250)]
        public string seotitle { get; set; }
        [StringLength(500)]
        public string seodescription { get; set; }
        [StringLength(250)]
        public string seokeywords { get; set; }



        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<ProductImage> ProductImage { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}