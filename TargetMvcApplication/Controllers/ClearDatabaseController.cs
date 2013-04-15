using System.Web.Mvc;
using Arch.Repositories.NHibernate;

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
