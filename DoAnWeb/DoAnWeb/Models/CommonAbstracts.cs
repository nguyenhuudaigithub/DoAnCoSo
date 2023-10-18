using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoAnWeb.Models
{
    public class CommonAbstracts
    {
        public string createdby { get; set; }
        public DateTime createddate { get; set; }
        public DateTime modifierdate { get; set; }
        public string modifierby { get; set; }
    }
}