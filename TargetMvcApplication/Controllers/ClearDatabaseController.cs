using System.Web.Mvc;
using ORM.NHibernate.ORM;

namespace TargetMvcApplication.Controllers
{
    public class ClearDatabaseController : Controller
    {
        //
        // GET: /ClearDatabase/

        public ActionResult Index()
        {
            SessionProvider.Instance.IsBuildSchema = true;
            SessionProvider.Instance.initilizae();
            return View();
        }

    }
}
