using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWeb.Models.EF
{
    [Table("table_Post")]
    public class Posts : CommonAbstracts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [StringLength(150)]
        public string title { get; set; }
        [StringLength(150)]
        public string alias { get; set; }
        public string description { get; set; }
        [AllowHtml]
        public string detail { get; set; }
        [StringLength(250)]
        public string image { get; set; }
        public int categoryid { get; set; }
        [StringLength(250)]
        public string seotitle { get; set; }
        [StringLength(500)]
        public string seodescription { get; set; }
        [StringLength(250)]
        public string seokeywords { get; set; }
        public bool isactive { get; set; }

        public virtual Category Category { get; set; }

    }
}