using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TargetMvcApplication.Context;
using TargetMvcApplication.Models;

namespace TargetMvcApplication.Controllers
{
    public class ClassController : Controller
    {
        public ActionResult Index()
        {
            var context = new TargetMvcApplicationContext();
            return View(context.Classes);
        }

        public ActionResult Details(int id)
        {
            var context = new TargetMvcApplicationContext();
            var @class= context.Classes.Find(id);
            return View(@class);
        }
        
        public ActionResult Create()
        {
            return View();
        } 
        
        [HttpPost]
        public ActionResult Create(Class @class)
        {
            try
            {
                var context = new TargetMvcApplicationContext();
                context.Classes.Add(@class);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
