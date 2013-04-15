using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using TargetMvcApplication.Repositories.NHibernate;

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
