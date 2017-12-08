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

        public ActionResult Search(string searchText)
       {

            var bal = new PersonnalController();
            var model = new PersonnalListModel();
            if(searchText==null)
            {
                return null;
            }
            if (searchText.Trim() != "" && searchText != null)
            {
                model.PersonnalList = bal.GetList(searchText);
            }
            return PartialView("_Search", model);
        }
        public ActionResult Detail(int id)
        {
            var bal = new PersonnalController();
            var model = new PersonnalViewModel();
            model = bal.Detail(id);
            return View(model);
        }
        public ActionResult Create()
        {
            var model = new PersonnalViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(PersonnalViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var bal = new PersonnalController();
                    bal.Insert(model);
                    return RedirectToAction("Index", "Search");

                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult Edit(int id)
        {
            var model = new PersonnalViewModel();
            var bal = new PersonnalController();
            model = bal.Detail(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(PersonnalViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var bal = new PersonnalController();
                    bal.Update(model);
                    return RedirectToAction("Index", "Search");
                }
                else
                {
                    return View();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}