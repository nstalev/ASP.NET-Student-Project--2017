using System.Web.Mvc;

namespace ComputerStore.Web.Controllers
{
    [RouteArea("Info")]
    public class InfoController : Controller
    {

        [Route("About")]
        public ActionResult About()
        {

            return View();
        }

        [Route("Contacts")]
        //[ActionName("Контакти")]
        public ActionResult Contacts()
        {

            return View();
        }

        [Route("Payment")]
        public ActionResult Payment()
        {
            return View();
        }

        [Route("Shiping")]
        public ActionResult Shiping()
        {
            return View();
        }

        [Route("GeneralTerms")]
        public ActionResult GeneralTerms()
        {
            return View();
        }

        [Route("Services")]
        public ActionResult Services()
        {
            return View();
        }
        
    }
}