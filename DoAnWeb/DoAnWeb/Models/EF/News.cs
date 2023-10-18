using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWeb.Models.EF
{
    [Table("table_News")]
    public class News : CommonAbstracts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required(ErrorMessage ="Bạn không thể trống tiêu đề tin")]
        [StringLength(150)]
        public string title { get; set; }
        public string alias { get; set; }
        public string description { get; set; }
        [AllowHtml]
        public string detail { get; set; }
        public string image { get; set; }
        public int categoryid { get; set; }
        public string seotitle { get; set; }
        public string seodescription { get; set; }
        public string seokeywords { get; set; }
        public bool isactive { get; set; }
        public virtual Category Category { get; set; }
    }
}