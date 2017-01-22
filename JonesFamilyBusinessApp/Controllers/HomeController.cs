using JonesFamilyBusinessApp.Models;
using JonesFamilyBusinessApp.Persistence;
using JonesFamilyBusinessApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace JonesFamilyBusinessApp.Controllers
{
    /// <summary>
    /// Main Controller of the system
    /// </summary>
    public class HomeController : Controller
    {
        // Default Action. Load Index View
        public ActionResult Index()
        {
            IndexViewModel vm = createEmptyViewModel();
            return View("Index",vm);
        }

        // Save data from Index form
        [HttpPost]
        public ActionResult Save(IndexViewModel vm)
        {
            // Initialize error
            vm.errors.Clear();

            // Get database manager
            DBManager dbman = DBManager.Instance;

            // No server side errors
            if (ModelState.IsValid)
            {
                // Get Model
                TimeModel model = createModel(vm);
                model.endTime = TimeCalculator(model.startTime, model.hours);
                // Save object
                bool result = dbman.SaveObject(model);

                // Redirecto to index
                return RedirectToAction("Index", "Home");
            }

            // Viewmodel contains errors
            else
            {
                // Build message error
                buildErrorField("startTime", ModelState,vm.errors);
                buildErrorField("hours", ModelState, vm.errors);
                buildErrorField("endTime", ModelState, vm.errors);
                
                // Return index view with errors
                return View("Index",vm);
            }
            
        }

        // Shows partial view with list of times in db
        [ChildActionOnly]
        public PartialViewResult TimesList()
        {
            // Create view model
            TimesListViewModel tlvm = new TimesListViewModel();

            // Get datatable
            tlvm.dt = DBManager.Instance.getObjects("Time");

            // Return view;
            return PartialView("TimesList", tlvm);
        }
        // Create empty view model to show in index view
        private IndexViewModel createEmptyViewModel()
        {
            IndexViewModel vm = new IndexViewModel();
            vm.startTime = new TimeSpan(12, 0, 0);
            vm.hours = 1;
            vm.endTime = vm.startTime + new TimeSpan(1, 0, 0);
            return vm;
        }

        //Create an empty model to store in db
        private TimeModel createModel(IndexViewModel vm)
        {
            TimeModel model = new TimeModel();
            model.startTime = vm.startTime;
            model.hours = vm.hours;
            model.endTime = vm.endTime;
            return model;
        }

        // Fill the errors dictionary with errors in model state
        private void buildErrorField(string fieldName, ModelStateDictionary ms, Dictionary<string,string> errors)
        {
            StringBuilder sb = new StringBuilder();
            if (!ms.IsValidField(fieldName))
            {
                ms[fieldName].Errors
                    .ToList()
                    .ForEach(e => sb.Append(e.ErrorMessage + "."));
                errors.Add(fieldName, sb.ToString());
            }
        }

        //Calculate TIme. Add hours to startTime and return new time
        private TimeSpan TimeCalculator(TimeSpan startTime, decimal hours)
        {
            return startTime.Add(TimeSpan.FromHours(double.Parse(hours.ToString())));
        }
    }
}