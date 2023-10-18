using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoAnWeb.Models.EF
{
    [Table("table_Contract")]
    public class Contract : CommonAbstracts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(150,ErrorMessage ="Không được vượt quá 150 kí tự")]
        public string name { get; set; }
        public string website { get; set; }
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 kí tự")]
        public string email { get; set; }
        [StringLength(3000)]
        public string message { get; set; }
        public bool isread { get; set; }
    }
}