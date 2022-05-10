using LibraryManagement.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Models;
namespace LibraryManagement.Controllers
{
    public class IssueBookController : Controller
    {
        private ApplicationDbContext _context = null;
        public IssueBookController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var std = _context.IssueBook.Select(s => new Issue_Books
            {
                id = s.id,
                Student_Id = s.Student_Id,
                BookNo = s.BookNo,
                BookName = s.BookName,
                IssueDate = s.IssueDate,
                DueDate= s.DueDate,

            }).ToList();
            return View(std);

        }


        /*   public ActionResult Details(int id)
           {
               var data1 = _context.IssueBook.Where(x=>x.id==id).Select(x => x.BookNo);
               int n = Convert.ToInt32(data1);
               var data = _context.AddBook.Where(x => x.BookNo == n).Select(x => x.Quantity - 1);

               _context.SaveChanges();
               _context.AddBooks emp = _context.AddBook.Where(x => x.BookNo == id).Single();
               return View(emp);
               //Where(x => x.BookNo == id )
              // return View(data);
           }*/



        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Issue_Books user)
        {
            //var issuebook = _context.IssueBook.Where(x => x.id == id).FirstOrDefault();

            //  var n = _context.IssueBook.Select(x => x.BookNo);
            /* var s = _context.StudentDetail.Select(x => x.Student_Id);
             int flag = 1;*/

            // int n1 = Convert.ToInt32(n);
            /* foreach(var v1 in _context.StudentDetail)
              {
                  var x1 = _context.StudentDetail.Select(x => x.Student_Id);
                  if(s==x1)
                  {
                      flag = 0;
                      break;
                  }

              }
              foreach (var v in _context.AddBook) 
              {
                  var x2 = _context.AddBook.Select(x=>x.BookNo);
                   if(n== x2 )
                  {
                      _context.IssueBook.Add(user);
                      //_context.SaveChanges();
                      _context.SaveChanges();
                      return View();
                  }
              }
              //ViewBag.Message("Book not exist");*/
            //return RedirectToAction("Index");

            /*var book = _context.AddBook.Find(user.BookNo);
            if(book!=null)
            {*/


            _context.IssueBook.Add(user);
            _context.SaveChanges();
            return View();
            //  }
            //  return RedirectToAction("Index");


        }
        public ActionResult Delete(int id)
        {
            var data = _context.IssueBook.Where(x => x.id == id).FirstOrDefault();
            _context.IssueBook.Remove(data);
            _context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.IssueBook.Where(x => x.id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Issue_Books Model)
        {
            var data = _context.IssueBook.Where(x => x.id == Model.id).FirstOrDefault();
            if (data != null)
            {
                data.id = Model.id;
                data.Student_Id = Model.Student_Id;
                data.BookNo = Model.BookNo;
                data.BookName = Model.BookName;
                data.IssueDate = Model.IssueDate;
                data.DueDate = Model.DueDate;


                //_context.SaveChanges();
                _context.SaveChanges();

            }
            return RedirectToAction("index");
        }
        public IActionResult Details(int id)
        {
            Models.Issue_Books emp = _context.IssueBook.Where(x => x.id== id).Single();
            return View(emp);

        }
        public IActionResult DecreaseCount(int id)
        {

            var bookIssue = _context.IssueBook.Where(x => x.id == id).FirstOrDefault();
            var books = (from b in _context.AddBook where b.BookNo.Equals(bookIssue.BookNo) select b).First();

            if (books.AvailableQuantity > 0)
            {
                books.AvailableQuantity = books.AvailableQuantity - 1;
                _context.SaveChanges();
            }
            return RedirectToAction("index");



          
          //  return RedirectToAction("index");
        }


    }
}




   
       



 
       
    

