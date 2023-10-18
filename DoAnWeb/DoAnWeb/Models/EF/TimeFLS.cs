using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWeb.Models.EF
{
    [Table("table_TimeFLS")]
    public class TimeFLS : CommonAbstracts
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public DateTime? ngayBD { get; set; }
        public DateTime? ngayKT { get; set; }

    }
}