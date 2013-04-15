using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TargetMvcApplication.Models;
using TargetMvcApplication.Presentation.ApplicationServices;

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
                var service = new ClassService();
                service.add_student(id,student);
                return RedirectToAction("Details","Class",new{id});
            }
            catch
            {
                return View();
            }
        }
    }
}
