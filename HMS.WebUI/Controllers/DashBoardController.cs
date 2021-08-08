using HMS.IBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMS.Models;

namespace HMS.WebUI.Controllers
{
    public class DashBoardController : Controller
    {
        // GET: DashBoard
        public ActionResult Index()
        {
            


            
                
            return View();
        }

        public JsonResult getData()
        {
            ILeadRep record = new BL.LeadRep();
            var data = record.ChartData();

            var list = data.GroupBy(x=>x.statusId).Select(g => new
            {
                name = g.Key,
                Count = g.Key.Count()
            });
            return Json(list,JsonRequestBehavior.AllowGet);
        }
    }
}