using AutoMapper;
using ComputerStore.Models.BindingModels.DeskComputers;
using ComputerStore.Models.BindingModels.Notebook;
using ComputerStore.Models.BindingModels.Orders;
using ComputerStore.Models.EntityModels;
using ComputerStore.Models.EntityModels.Addresses;
using ComputerStore.Models.EntityModels.Orders;
using ComputerStore.Models.EntityModels.Products;
using ComputerStore.Models.ViewModels.Addresses;
using ComputerStore.Models.ViewModels.Comments;
using ComputerStore.Models.ViewModels.DeskComputers;
using ComputerStore.Models.ViewModels.Notebook;
using ComputerStore.Models.ViewModels.Orders;
using ComputerStore.Models.ViewModels.User;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ComputerStore.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            this.RegisterMaps();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterMaps()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<ApplicationUser, UserProfileVM>();
                expression.CreateMap<AddNotebookBm, Notebooks>();
                expression.CreateMap<AddDeskCompBM, DeskComputers>();
                expression.CreateMap<Notebooks, AllNotebooksVm>();
                expression.CreateMap<Notebooks, DetailsNotebookVm>();
                expression.CreateMap<DeskComputers, AllDescCompVM>();
                expression.CreateMap<DeskComputers, DetailsDescCompVM>();

                expression.CreateMap<Item, BuyProductVm>();
                expression.CreateMap<Item, DeleteItemVm>();
                expression.CreateMap<AddAddressBM, Address>();
                expression.CreateMap<Address, AddressVM>();
                expression.CreateMap<Address, EditAddressVm>();
                expression.CreateMap<Address, DeleteAddressVm>();
                expression.CreateMap<Address, DetailsAddressVm>();
                expression.CreateMap<OrderAddress, DetailsAddressVm>();
                expression.CreateMap<OrderAddress, AddressVM>();


                expression.CreateMap<Order, AllOrdersVm>();
                expression.CreateMap<Order, DetailsOrderVm>();
                expression.CreateMap<Order, DetailsStoreOrderVm>().ForMember(vm => vm.Buyer,
    configurationExpression =>
        configurationExpression.MapFrom(order1 => order1.Buyer.User));



                expression.CreateMap<Comment, CommentVm>();











            });
        }

    }
}
