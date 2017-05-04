using ComputerStore.Models.BindingModels.Comment;
using ComputerStore.Models.ViewModels.Comments;
using ComputerStore.Models.ViewModels.DeskComputers;
using ComputerStore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerStore.Web.Controllers
{

    [RoutePrefix("DeskComputers")]
    public class DeskComputersController : Controller
    {
        private DeskComputersService service;

        public DeskComputersController()
        {
            this.service = new DeskComputersService();
        }


        [Route("All")]
        [HttpGet]
        public ActionResult All()
        {
            IEnumerable<AllDescCompVM> vm = service.GetAllNotebooks();

            return View(vm);
        }

        [Route("{brand}")]
        [HttpGet]
        public ActionResult Brand(string brand)
        {
            IEnumerable<AllDescCompVM> vm = service.GetAllDescByBrand(brand);

            return View(vm);
        }

        [Route("{Id:int}")]
        [HttpGet]
        public ActionResult Details(int Id)
        {
            DetailsDescCompVM vm = service.GetDetailNotebookVM(Id);

            return View(vm);
        }



        [HttpGet]
        [Route("AllComments/{Id}")]
        public ActionResult AllComments(int Id)
        {
            AllCommentVm vm = service.GetAllComents(Id);

            return this.PartialView("_AllCommentsPartial", vm);
        }


        [Route("{Id}")]
        [Authorize]
        [HttpPost]
        public ActionResult AddComment(int Id, [Bind(Include = "Content")]AddCommentBM bind)
        {
            string userName = User.Identity.Name;
            if (this.ModelState.IsValid)
            {
                service.AddCommentToProduct(Id, userName, bind);

                return RedirectToAction("Details", new { Id = Id });
            }
            return View();

        }

    }
}