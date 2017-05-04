using ComputerStore.Models.BindingModels.Addresses;
using ComputerStore.Models.BindingModels.Orders;
using ComputerStore.Models.ViewModels.Addresses;
using ComputerStore.Models.ViewModels.Orders;
using ComputerStore.Models.ViewModels.User;
using ComputerStore.Service;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ComputerStore.Web.Controllers
{
    [Authorize]
    [RoutePrefix("Users")]
    public class UsersController : Controller
    {
        private UserService service;

        public UsersController()
        {
            this.service = new UserService();
        }

        [Route("Profile")]
        [HttpGet]
        public ActionResult Profile()
        {
            string userName = this.User.Identity.Name;

            UserProfileVM vm = service.GetUserProfile(userName);

            return View(vm);
        }

        [Route("DetailsAddress/{Id}")]
        [HttpGet]
        public ActionResult DetailsAddress(int Id)
        {

            DetailsAddressVm vm = service.GetDetailAddressVm(Id);

            return View(vm);
        }



        [Route("AddAddress")]
        [HttpGet]
        public ActionResult AddAddress()
        {

            return View();
        }

        [Route("AddAddress")]
        [HttpPost]
        public ActionResult AddAddress([Bind(Include = "City, Streat, PhoneNumber, PostCode")]AddAddressBM bind)
        {
            if (this.ModelState.IsValid)
            {
                string userName = User.Identity.Name;
                service.AddAddress(bind, userName);

                return this.RedirectToAction("Profile");

            }

            return View();
        }


        [Route("Edit/{Id}")]
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            EditAddressVm vm = service.GetEditAddressVm(Id);

            return View(vm);
        }

        [Route("Edit/{Id}")]
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id, City, Streat, PhoneNumber, PostCode")]EditAddressBM bind)
        {
            if (this.ModelState.IsValid)
            {
                service.EditAddress(bind);

                return this.RedirectToAction("MyAddresses");

            }

            return View();
        }

        [Route("Delete/{Id}")]
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            DeleteAddressVm vm = service.GetDeleteAddressVm(Id);
            return View(vm);
        }


        [Route("Delete/{Id}")]
        [HttpPost]
        public ActionResult Delete([Bind(Include = "AddressId")]DeleteAddressBm bind)
        {

            service.DeleteAddress(bind.AddressId);

            return this.RedirectToAction("MyAddresses");

        }

        [Route("MyAddresses")]
        [HttpGet]
        public ActionResult MyAddresses()
        {
            string userName = User.Identity.Name;

            IEnumerable<AddressVM> vms = service.GetAllAddressVm(userName);

            return View(vms);
        }

        
        [Route("MyOrders")]
        [HttpGet]
        public ActionResult MyOrders()
        {
            string userName = User.Identity.Name;

            IEnumerable<AllOrdersVm> vm = service.GetAllOrdersVm(userName);

            return View(vm);
        }



        [Route("DetailsOrder/{Id}")]
        [HttpGet]
        public ActionResult DetailsOrder(int Id)
        {
            string userName = User.Identity.Name;

            DetailsOrderVm vm = service.GetDetailsOrderVm(Id, userName);

            return View(vm);
        }

        

    }
}