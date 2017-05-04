using System.Web.Mvc;

namespace ComputerStore.Web.Areas.Store
{
    public class StoreAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Store";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.Routes.MapMvcAttributeRoutes();
            context.MapRoute(
                "Store_default",
                "Store/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}