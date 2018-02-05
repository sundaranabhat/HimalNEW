using BusinessAccessLayer.Controller;
using DataAccessLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Himal.Controllers
{
    public class vPersonnalController : Controller
    {
        // GET: TestLayout
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ViewSearch()
        {

            var bal = new vPersonnalCtrl();
            var model = new PersonnalListModel();
           
            //if (searchText.Trim() != "" && searchText != null)
            //{
                model.vPersonnalList = bal.GetList();
            //}
            return Json(model.vPersonnalList, JsonRequestBehavior.AllowGet);
        }

    }
}