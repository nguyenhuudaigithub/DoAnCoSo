using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoAnWeb.Models.EF
{
    [Table("table_Category")]
    public class Category : CommonAbstracts
    {
        public Category()
        {
            this.News = new HashSet<News>();   
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; } 
        [Required(ErrorMessage ="Tên danh mục không được để trống")]
        [StringLength(150)]
        public string title { get; set; }
        public string alias { get; set; }
        //[StringLength(150)]
        //public string typecode { get; set; }
        public string link { get; set; }

        public string description { get; set; }
        [StringLength(150)]
        public string seotitle { get; set; }
        [StringLength(350)] 
        public string seodescription { get; set; }
        [StringLength(150)]
        public string seokeywords { get; set; }
        public int position { get; set; }
        public bool isactive { get; set; }

        public ICollection<News> News { get; set; }
        public ICollection<Posts> Posts { get; set; }
    }
}