using DoAnWeb.Migrations;
using DoAnWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Xml.Linq;

namespace DoAnWeb.Controllers
{
    public class CountdownController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Countdown


        public DateTime[] GetStartAndEndDate()
        {
            using (var context = new ApplicationDbContext())
            {
                var countdown = context.TimeFLs.FirstOrDefault(); // Lấy countdown đầu tiên trong bảng Countdown
                if (countdown != null)
                {
                    return new DateTime[] { (DateTime)countdown.ngayBD, (DateTime)countdown.ngayKT };
                }
                else
                {
                    return null;
                }

            }
        }
        public ActionResult Index()
        {
            var startAndEndDate = GetStartAndEndDate(); // Lấy ngày bắt đầu và kết thúc từ cơ sở dữ liệu
            @ViewBag.StartDate = startAndEndDate[0];
            @ViewBag.EndDate = startAndEndDate[1];
            return View();
        }
    }
}