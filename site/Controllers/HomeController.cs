using System.Linq;
using System.Web.Mvc;
using DAL;
using NHibernate;
using NHibernate.Linq;

namespace site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISession session;

        public HomeController(ISession session)
        {
            this.session = session;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Project()
        {
            var projects = session.Query<Project>().ToArray();
            return View(projects);
        }
    }
}
