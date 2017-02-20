using MyRjWeb.dal;
using RjWeb.Areas.Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RjWeb.Areas.Security.Controllers
{
   
    public class UserController : Controller
    {
        private IList<UserModelView> User
        {
            get
            {
                if (Session["data"] == null)
                {
                    Session["data"]= new List<UserModelView>() {
                     new UserModelView {
                           Id= Guid.NewGuid(),
                           Name= "Roelyn Joy", 
                           Age= 21,
                           Gender= "Female"
                },
                    new  UserModelView{
                    Id= Guid.NewGuid(),
                    Name= "Kim Soo Hyun", 
                    Age= 28,
                    Gender=" Male"
                    }
                };
            }
                    return Session["data"] as List<UserModelView>;
        
           }
        }
        // GET: Security/User
        public ActionResult Index()
        {
            using (var db=new DatabaseContext())
            {
                var users= from user in db.Users.ToList()
                            select new UserModelView
                {
                    Id=user.Id,
                    Name=user.Name,
                    Age=user.Age,
                    Gender=user.Gender

                }; 
                return View(users);
            }
            
        }

        // GET: Security/User/Details/5
        public ActionResult Details(Guid id)
        {
            var m = User.FirstOrDefault(user => user.Id == id);
            return View(m);
        }

        // GET: Security/User/Create
        public ActionResult Create()
        {
            ViewBag.Gender = new List<SelectListItem> {
                new SelectListItem {
                    Value= "Male",
                    Text= "Boy"
                },
                new SelectListItem {
                    Value= "Female",
                    Text= "Girl"
                }
            };
            return View();
        }

        // POST: Security/User/Create
        [HttpPost]
        public ActionResult Create(UserModelView viewModel)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return View();
                // TODO: Add insert logic here
                using (var db = new DatabaseContext())
                {
                    db.Users.Add(new User
                    {

                        Id = Guid.NewGuid(),
                        Name = viewModel.Name,
                        Age = viewModel.Age,
                        Gender = viewModel.Gender


                    });
                    db.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Security/User/Edit/5
        public ActionResult Edit(Guid id)
        {
            var U = User.FirstOrDefault(user => user.Id == id);
            return View(U);
        }

        // POST: Security/User/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, UserModelView usermodelview)
        {
            try
            {
                // TODO: Add update logic here
                var U = User.FirstOrDefault(user => user.Id == id);
                U.Name = usermodelview.Name;
                U.Age = usermodelview.Age;
                U.Gender=usermodelview.Gender;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Security/User/Delete/5
        public ActionResult Delete(Guid id)
        {
            var U = User.FirstOrDefault(user => user.Id == id);
            return View(U);
        }

        // POST: Security/User/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                var U = User.FirstOrDefault(user => user.Id == id);
                User.Remove(U);
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
