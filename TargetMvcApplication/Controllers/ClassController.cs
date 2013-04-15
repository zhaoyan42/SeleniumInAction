using System.Web.Mvc;
using TargetMvcApplication.Models;
using TargetMvcApplication.Presentation.ApplicationServices;

namespace TargetMvcApplication.Controllers
{
    public class ClassController : Controller
    {
        public ActionResult Index()
        {
            var service = new ClassService();
            return View(service.get_all_classes());
        }

        public ActionResult Details(int id)
        {
            var service = new ClassService();
            var @class = service.get_class(id);
            return View(@class);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Class @class)
        {
            var service = new ClassService();
            service.create_class(@class);

            return RedirectToAction("Index");
        }
    }
}