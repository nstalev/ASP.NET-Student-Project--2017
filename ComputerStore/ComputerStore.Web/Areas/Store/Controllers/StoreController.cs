using ComputerStore.Models.ViewModels.Orders;
using ComputerStore.Service;
using ComputerStore.Web.Attributes;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ComputerStore.Web.Areas.Store.Controllers
{

    [RouteArea("Store")]
    [MyAuthorize(Roles = "Administrator")]
    public class StoreController : Controller
    {
        private AdminService service;

        public StoreController()
        {
            service = new AdminService();
        }

        [Route("Index")]
        [HttpGet]
        public ActionResult Index()
        {
            CountOrdersVM vm = service.GetCountOrdersVM();

            return View(vm);
        }



        [Route("ActiveOrders")]
        [HttpGet]
        public ActionResult ActiveOrders()
        {
            IEnumerable<AllOrdersVm> vms = service.GetAllInActiveOrdersVM();

            return View(vms);
        }

        [Route("InProgressOrders")]
        [HttpGet]
        public ActionResult InProgressOrders()
        {
            IEnumerable<AllOrdersVm> vms = service.GetAllInProgressOrdersVM();

            return View(vms);
        }
        [Route("CompletedOrders")]
        [HttpGet]
        public ActionResult CompletedOrders()
        {
            IEnumerable<AllOrdersVm> vms = service.GetAllCompletedOrdersVM();

            return View(vms);
        }
        


        [Route("DetailsOrder/{Id}")]
        [HttpGet]
        public ActionResult DetailsOrder(int Id)
        {
            string userName = User.Identity.Name;

            DetailsStoreOrderVm vm = service.GetDetailsStoreOrderVm(Id);

            return View(vm);
        }


        [Route("ChangeToInProgress/{Id}")]
        [HttpPost]
        public ActionResult ChangeToInProgress(int Id)
        {
            if (this.ModelState.IsValid)
            {
                service.ChangeStatusToInProgress(Id);

                return RedirectToAction("InProgressOrders");
            }
            return View();

        }

        [Route("ChangeToCompleted/{Id}")]
        [HttpPost]
        public ActionResult ChangeToCompleted(int Id)
        {
            if (this.ModelState.IsValid)
            {
                service.ChangeStatusToCompleted(Id);

                return RedirectToAction("CompletedOrders");
            }
            return View();

        }


    }
}