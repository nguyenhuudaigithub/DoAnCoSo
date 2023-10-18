using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.WebSockets;

namespace DoAnWeb.Models.EF
{
    [Table("table_Order")]
    public class Order : CommonAbstracts
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string code { get; set; }
        [Required(ErrorMessage = "Tên khách hàng không được để trống")]
        public string customername { get; set; }
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string phone { get; set; }
        [Required(ErrorMessage = "Địa chỉ được để trống")]
        public string address { get; set; }
        public string email { get; set; }
        public decimal total { get; set; }
        public int quantity { get; set; }
        public int Status { get; set; }
        public int typepayment { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}