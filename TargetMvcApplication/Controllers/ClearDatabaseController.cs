using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TargetMvcApplication.Context;

namespace TargetMvcApplication.Controllers
{
    public class ClearDatabaseController : Controller
    {
        //
        // GET: /ClearDatabase/

        public ActionResult Index()
        {
            Database.Delete("TargetMvcApplicationContext");
            var context = new TargetMvcApplicationContext();
            context.Database.Initialize(true);
            return View();
        }

    }
}
