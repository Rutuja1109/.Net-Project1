using LibraryManagement.Data;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Controllers
{
    public class StudentController : Controller
    {

        private ApplicationDbContext _context = null;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var std = _context.StudentDetail.Select(s => new StudentDetails
            {
                Id=s.Id,
                Student_Id = s.Student_Id,
                StudentName = s.StudentName,
                Department = s.Department,
                EmailID = s.EmailID,
                Address = s.Address,
                
            }).ToList();
            return View(std);
          }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(StudentDetails user)
        {
            _context.StudentDetail.Add(user);
            _context.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var data = _context.StudentDetail.Where(x => x.Id == Id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(StudentDetails Model)
        {
            var data = _context.StudentDetail.Where(x => x.Student_Id == Model.Student_Id).FirstOrDefault();
            if (data != null)
            {
                data.Id = Model.Id;
                data.Student_Id = Model.Student_Id;
                data.StudentName = Model.StudentName;
                data.Department = Model.Department;
                data.EmailID = Model.EmailID;
                data.Address = Model.Address;
               
                //_context.SaveChanges();
                _context.SaveChanges();
            }



            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
            var data = _context.StudentDetail.Where(x => x.Student_Id == id).FirstOrDefault();
            _context.StudentDetail.Remove(data);
            _context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }
        public IActionResult Details(int id)
        {
            Models.StudentDetails emp = _context.StudentDetail.Where(x => x.Id == id).Single();
            return View(emp);

        }
       
    }
}
