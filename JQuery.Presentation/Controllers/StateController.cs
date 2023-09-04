using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JQuery.Presentation.Models;
using JQuery.Application.Interfaces;
using System.Text;
using JQuery.Domain.Entities;
using JQuery.Domain.Interfaces.Services;

using Microsoft.AspNetCore.Http;

namespace JQuery.Presentation.Controllers
{
    public class StateController : Controller
    {
        private readonly IStateApplicationService _stateapplicationservice;



        public StateController(IStateApplicationService stateapplicationservice)
        {

            _stateapplicationservice = stateapplicationservice;

        }


        // GET: StateController
        public JsonResult GetStates()
        {
            var StateList = new List<StateModel>();
            var list = _stateapplicationservice.GetAll().OrderBy(x => x.StateAcronym);

            foreach(var item in list)
            {
                var m = new StateModel();
                m.IdState = item.IdState.ToString();
                m.StateAcronym = item.StateAcronym;
                StateList.Add(m);
            }

            return Json(StateList);

        }

        // GET: StateController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StateController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StateController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StateController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StateController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StateController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
