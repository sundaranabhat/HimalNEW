using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BusinessAccessLayer.Controller;
using DataAccessLayer.ViewModel;


namespace Himal.Controllers
{
    public class SearchController : Controller
    {
        // GET: /Search

        public ActionResult Index()
        {

            return View();
        }

        public JsonResult Search(string searchText)
        {

            var bal = new PersonnalController();
            var model = new PersonnalListModel();
            if (searchText == null)
            {
                return Json(model.PersonnalList, JsonRequestBehavior.AllowGet);
            }
            if (searchText.Trim() != "" && searchText != null)
            {
                model.PersonnalList = bal.GetList(searchText);
            }
            return Json(model.PersonnalList, JsonRequestBehavior.AllowGet);
        }

        public string Insert(PersonnalViewModel personnalModel)
        {
            var message = "";
            try
            {

                if (ModelState.IsValid)
                {
                    var bal = new PersonnalController();
                    bal.Insert(personnalModel);
                    message = "Successfully Record Inserted";
                    return message;

                }
                else
                {
                    message = "Failed to Insert Record";
                    return message;
                }
            }
            catch (Exception)
            {
                return "Catch Exception, Failed to insert record";
            }
        }

        public string Update(PersonnalViewModel personnalModel)
        {
            var message = "";
            try
            {
                if (ModelState.IsValid)
                {
                    var bal = new PersonnalController();
                    bal.Update(personnalModel);
                    message = "Successfully Record Updated";
                    return message;

                }
                else
                {
                    message = "Failed to Update Record";
                    return message;
                }

            }
            catch (Exception)
            {

                return "Catch Exception, Failed to Update record";

            }
        }

        public JsonResult Detail(PersonnalViewModel personnalModel)
        {
            var id = personnalModel.ID;
            var bal = new PersonnalController();
            var model = new PersonnalViewModel();
            model = bal.Detail(id);
            return Json(model,JsonRequestBehavior.AllowGet);
        }

        #region ActionResult
        //public ActionResult Detail(int id)
        //{
        //    var bal = new PersonnalController();
        //    var model = new PersonnalViewModel();
        //    model = bal.Detail(id);
        //    return View(model);
        //}
        //public ActionResult Create()
        //{
        //    var model = new PersonnalViewModel();
        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult Create(PersonnalViewModel model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var bal = new PersonnalController();
        //            bal.Insert(model);
        //            return RedirectToAction("Index", "Search");

        //        }
        //        else
        //        {
        //            return View(model);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //public ActionResult Edit(int id)
        //{
        //    var model = new PersonnalViewModel();
        //    var bal = new PersonnalController();
        //    model = bal.Detail(id);
        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult Edit(PersonnalViewModel model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var bal = new PersonnalController();
        //            bal.Update(model);
        //            return RedirectToAction("Index", "Search");
        //        }
        //        else
        //        {
        //            return View();
        //        }

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        #endregion
    }
}