using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BusinessAccessLayer.Controller;
using DataAccessLayer.ViewModel;

namespace Himal.Areas.PrimaryUser.Controllers
{
    public class SearchController : Controller
    {
        // GET: PrimaryUser/Home

        public ActionResult Index()
        {
            var model = new PersonnalListModel();

            return View(model);
        }




        [HttpPost]
        public ActionResult Index(string searchText)
        {

            var bal = new PersonnalController();
            var model = new PersonnalListModel();
            if (searchText.Trim() != "")
            {
                model.PersonnalList = bal.GetList(searchText);
            }
            return View(model);
        }
        public ActionResult Detail(int id)
        {
            var bal = new PersonnalController();
            var model = new PersonnalViewModel();
            model = bal.Detail(id);
            return View(model);
        }
    }
}