using ComputerStore.Models.BindingModels.Orders;
using ComputerStore.Models.ViewModels.Orders;
using ComputerStore.Service;
using System.Collections.Generic;
using System.Web.Mvc;
using System;
using ComputerStore.Models.ViewModels.Addresses;
using ComputerStore.Models.BindingModels.Addresses;

namespace ComputerStore.Web.Controllers
{
    [RoutePrefix("Orders")]
    [Authorize]
    public class OrdersController : Controller
    {
        private OrdersService service;
        private UserService userService;


        public OrdersController()
        {
            this.service = new OrdersService();
            this.userService = new UserService();
        }



        [Route("Add/{Id}")]
        [HttpPost]
        public ActionResult Add(int Id)
        {
            string userName = User.Identity.Name;
            if (this.ModelState.IsValid)
            {
                service.AddProductuToCurrentOrder(Id, userName);

                return RedirectToAction("Basket");
            }
            return View();

        }



        [Route("Basket")]
        [HttpGet]
        public ActionResult Basket()
        {
            string userName = User.Identity.Name;
            BasketVm vm = service.GetBasketVm(userName);

            return View(vm);
        }


        [HttpGet]
        [Route("DeleteItem/{productId}")]
        public ActionResult DeleteItem(int productId)
        {

            DeleteItemVm vm = service.GetDeleteItemVm(productId);

                 return View(vm);
        }


        [HttpPost]
        [Route("DeleteItem/{productId}")]
        public ActionResult DeleteItem([Bind(Include = "productId")]DeleteItemrBm bind)
        {
            if (this.ModelState.IsValid)
            {
                string userName = this.User.Identity.Name;

                service.DeleteProductFromBasket(bind, userName);

                return RedirectToAction("Basket", "Orders");
            }

            return this.View();
        }


        [Route("DeliveryAddress")]
        [HttpGet]
        public ActionResult DeliveryAddress()
        {
            string userName = User.Identity.Name;

            SecondStepDelAddressVm vm = service.SecondStepDelAddressVm(userName);

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
                userService.AddAddress(bind, userName);

                return this.RedirectToAction("DeliveryAddress");

            }

            return View();
        }


        [Route("Edit/{Id}")]
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            EditAddressVm vm = userService.GetEditAddressVm(Id);

            return View(vm);
        }

        [Route("Edit/{Id}")]
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id, City, Streat, PhoneNumber, PostCode")]EditAddressBM bind)
        {
            if (this.ModelState.IsValid)
            {
                userService.EditAddress(bind);

                return this.RedirectToAction("DeliveryAddress", "Orders");

            }

            return View();
        }




        [Route("OrderReview/{Id}")]
        [HttpGet]
        public ActionResult OrderReview(int Id)
        {
            string userName = User.Identity.Name;

            OrderReview vm = service.OrderReviewVm(Id, userName);

            return View(vm);
        }


        [Route("OrderReview/{Id}")]
        [HttpPost]
        public ActionResult OrderReview([Bind(Include = "AddressId")]ConfirmOrder bind)
        {
            string userName = this.User.Identity.Name;

            if (this.ModelState.IsValid)
            {

                service.CreateOrder(bind, userName);

                return RedirectToAction("ConfirmOrder");
            }


            return View();
        }



        [Route("ConfirmOrder")]
        [HttpGet]
        public ActionResult ConfirmOrder()
        {
            string userName = this.User.Identity.Name;

            ConfirmedOrderVm vm = service.GetOrderId(userName);

            return View(vm);
        }

      

    



    }
}