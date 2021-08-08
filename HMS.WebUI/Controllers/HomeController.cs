using HMS.IBL;
using System.Web.Mvc;
using HMS.Models;

namespace HMS.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private ICustomerRep record;
        public HomeController()
        {
            record = new BL.CustomerRep();
        }
        
        public ActionResult Index()
        {

            return View();
        }

        public JsonResult getList()
        {
           
            var model = record.Get();
            return Json(model,JsonRequestBehavior.AllowGet);
        }


        public ActionResult Create()
        {
            CustomeEditModel model = record.GetByID(0);
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(CustomeEditModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ICustomerRep record = new BL.CustomerRep();
                   
                    var r = record.Save(model);


                    return RedirectToAction("Index");
                }
                catch
                {
                }
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            CustomeEditModel model = record.GetByID(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(CustomeEditModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ICustomerRep record = new BL.CustomerRep();
                    var r = record.Save(model);
                    return RedirectToAction("Index");
                }
                catch
                {
                }
            }
            return View(model);
        }
    }
}