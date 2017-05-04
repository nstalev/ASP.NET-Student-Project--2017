using ComputerStore.Models.BindingModels.Comment;
using ComputerStore.Models.BindingModels.Orders;
using ComputerStore.Models.ViewModels.Comments;
using ComputerStore.Models.ViewModels.Notebook;
using ComputerStore.Models.ViewModels.Orders;
using ComputerStore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerStore.Web.Controllers
{
    [RoutePrefix("Notebooks")]
    public class NotebooksController : Controller
    {

        private NotebookService service;

        public NotebooksController()
        {
            this.service = new NotebookService();
        }

        [Route("All")]
        [HttpGet]
        public ActionResult All()
        {
            IEnumerable<AllNotebooksVm> vm = service.GetAllNotebooks();

            return View(vm);
        }

        [Route("{brand}")]
        [HttpGet]
        public ActionResult Brand(string brand)
        {
            IEnumerable<AllNotebooksVm> vm = service.GetAllNotebooksByBrand(brand);

            return View(vm);
        }

        [Route("Price/{range}")]
       // [Route("Price")]

        [HttpGet]
        public ActionResult Price(string range)
        {
            IEnumerable<AllNotebooksVm> vm = service.GetAllNotebooksByPrice(range);

            return View(vm);
        }



        [Route("{Id:int}")]
        [HttpGet]
        public ActionResult Details(int Id)
        {
            DetailsNotebookVm vm = service.GetDetailNotebookVM(Id);

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