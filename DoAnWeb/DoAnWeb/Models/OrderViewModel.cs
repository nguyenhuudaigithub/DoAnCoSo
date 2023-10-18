using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnWeb.Models
{
    public class OrderViewModel
    {
        [Required(ErrorMessage = "Tên khách hàng không được để trống")]
        public string customername { get; set; }
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string phone { get; set; }
        [Required(ErrorMessage = "Địa chỉ được để trống")]
        public string address { get; set; }
        public string email { get; set; }
        public int typepayment { get; set; }
        public int typepaymentVN { get; set; }


    }
}