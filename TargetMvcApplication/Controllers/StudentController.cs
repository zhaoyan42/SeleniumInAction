using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TargetMvcApplication.Context;
using TargetMvcApplication.Models;

namespace TargetMvcApplication.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/Create

        public ActionResult Create(int id)
        {
            return View();
        } 

        //
        // POST: /Student/Create

        [HttpPost]
        public ActionResult Create(int id,Student student)
        {
            try
            {
                var context = new TargetMvcApplicationContext();
                context.Classes.Find(id).Students.Add(student);
                context.SaveChanges();
                return RedirectToAction("Index","Class");
            }
            catch
            {
                return View();
            }
        }
    }
}
