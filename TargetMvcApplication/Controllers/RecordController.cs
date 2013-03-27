using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TargetMvcApplication.Context;
using TargetMvcApplication.Models;

namespace TargetMvcApplication.Controllers
{
    public class RecordController : Controller
    {
        public ActionResult Index()
        {
            var context = new TargetMvcApplicationContext();
            return View(context.Records);
        }
        
        public ActionResult Create()
        {
            return View();
        } 
        
        [HttpPost]
        public ActionResult Create(Record record)
        {
            try
            {
                var context = new TargetMvcApplicationContext();
                context.Records.Add(record);
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
