using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxCascadingDropdown.Models;

namespace AjaxCascadingDropdown.Controllers
{
    public class DemoController : Controller
    {
        InventoryEntities obj = new InventoryEntities();
       
        public ActionResult Index()
        {
            List<SelectListItem> cat = new List<SelectListItem>();
            cat.Add(new SelectListItem { Text="-Select Category-"});
            foreach(var c in obj.categories.ToList() )
            {
                cat.Add(new SelectListItem { Text=c.catedesc , Value=c.cateid.ToString() });
            }
            ViewBag.category = cat;

            return View();
        }

        public JsonResult getproducts(int cid)
        {
            var prod = from p in obj.products where p.cateid == cid select new { p.proddesc, p.prodid };
            return Json(prod , JsonRequestBehavior.AllowGet);
        }


    }
}