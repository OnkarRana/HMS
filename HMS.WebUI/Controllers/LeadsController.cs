using HMS.IBL;
using System.Web.Mvc;
using HMS.Models;
using HMS.BL;

namespace HMS.WebUI.Controllers
{
    public class LeadsController : Controller
    {
        private ILeadRep record;
        public LeadsController()
        {
            record = new BL.LeadRep();
        }

        public ActionResult Index()
        {

            return View(getList());
        }

        public JsonResult getList()
        {

            var model = record.Get();
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Create()
        {
            EditLeadModel model = record.CreateByID();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(EditLeadModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
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
            EditLeadModelDto model = record.GetByID(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EditLeadModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    LeadRep record = new BL.LeadRep();
                    var r = record.Save(model);
                    return RedirectToAction("Index");
                }
                catch
                {
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateLeadTask(int Id)
        {

            CreateTaskModel l = new CreateTaskModel()
            {
                LeadId = Id,createdBy=1
               
            };
            return PartialView("_createLeadTask", l);
        }
        [HttpPost]
        public ActionResult CreateLeadTask(CreateTaskModel item)
        {
            bool a = record.LeadTaskCreate(item);
            EditLeadModelDto model = record.GetByID(item.LeadId);
            return RedirectToAction("Edit", new { id= item.LeadId });
        }

    }
}
