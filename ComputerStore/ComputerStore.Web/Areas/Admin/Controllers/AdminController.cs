using ComputerStore.Models.BindingModels.DeskComputers;
using ComputerStore.Models.BindingModels.Notebook;
using ComputerStore.Service;
using ComputerStore.Web.Attributes;
using System.Web.Mvc;

namespace ComputerStore.Web.Areas.Admin.Controllers
{

    [RouteArea("Admin")]
    [MyAuthorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private AdminService service;

        public AdminController()
        {
            this.service = new AdminService();
        }


        [Route("Index")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [Route("AddNotebook")]
        [HttpGet]
        public ActionResult AddNotebook()
        {
            return View();
        }


        [Route("AddNotebook")]
        [HttpPost]
        public ActionResult AddNotebook([Bind(Include = "Brand, Model, Price, Processor, RAM, Storage, VideoGraphic, OparationSystem, DisplaySize, Dimensions, Description, ImageUrl, Image2Url, Image3Url")]AddNotebookBm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddNotebookFromBind(bind);
                return this.RedirectToAction("Index", "Admin");
            }
            return View();
        }

        [Route("AddDeskComp")]
        [HttpGet]
        public ActionResult AddDeskComp()
        {
            return View();
        }


        [Route("AddDeskComp")]
        [HttpPost]
        public ActionResult AddDeskComp([Bind(Include = "Brand, Model, Price, Processor, RAM, Storage, VideoGraphic, OparationSystem, OpticalDrive, Dimensions, Description, ImageUrl, Image2Url, Image3Url")]AddDeskCompBM bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddDeskComputerBind(bind);
                return this.RedirectToAction("Index", "Admin");
            }
            return View();
        }

    }
}