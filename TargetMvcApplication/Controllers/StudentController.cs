﻿using System.Web.Mvc;
using Domain;
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
        public ActionResult Create(int id, Student student)
        {
            var service = new ClassService();
            service.add_student(id, student);
            return RedirectToAction("Details", "Class", new {id});
        }
    }
}