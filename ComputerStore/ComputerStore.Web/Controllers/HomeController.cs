using ComputerStore.Models.ViewModels.Notebook;
using ComputerStore.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerStore.Web.Controllers
{
    //[RoutePrefix("Home")]
    public class HomeController : Controller
    {

        private HomeService service;

        public HomeController()
        {
            this.service = new HomeService();
        }


       // [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }

       


        [Route("Notebooks")]
        [HttpGet]
        public ActionResult Notebooks()
        {
            IEnumerable<AllNotebooksVm> vm = service.GetAllNotebooks();

            return View(vm);
        }


    }
}