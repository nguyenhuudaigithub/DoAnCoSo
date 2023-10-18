using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoAnWeb.Models.EF
{
    [Table("table_Adv")]
    public class Adv:CommonAbstracts 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [StringLength(150)]
        public string title { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        [StringLength(500)]
        public string link { get; set; }
        public int type { get; set; }
    }
}