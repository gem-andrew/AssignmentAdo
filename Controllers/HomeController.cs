using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssignmentAdo.Models;
namespace AssignmentAdo.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Login()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult Login(Login lp)
        //{

        //    if (ModelState.IsValid == true)
        //    {
        //        LoginDBContext context = new LoginDBContext();
        //        bool check = context.CheckLogin(lp);
        //        if (check == true)
        //        {
        //            TempData["LoginMessage"] = "Logged-In Successfully.";
        //            //clear model state would empty the data that was previously entered in form 
        //            //ModelState.Clear();
        //            return RedirectToAction("Index");
        //        }
        //        return View();
        //    }
        //}
        public ActionResult CreatePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePassword(Password ps)
        {
            if (ps.pass != ps.confirmPass)
            {
                ViewBag.Message = "Password does not match";
                return View(ps);
            }
            {
                if (ModelState.IsValid == true)
                {
                    PasswordDBContext context = new PasswordDBContext();
                    bool check = context.AddPassword(ps);
                    if (check == true)
                    {
                        TempData["PasswordCreationMessage"] = "User Registered Successfully.";
                        //clear model state would empty the data that was previously entered in form 
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
        }
        public ActionResult ForgetPassword()
        {
            return View();

        }
        public ActionResult Index()
        {
            UserDBContext db = new UserDBContext();
            List<User> obj = db.GetUsers();
            return View(obj);
        }

        public ActionResult Create() //only for generating view
        {
            return View();
        }
        //to store form data in databse table
        [HttpPost]
        public ActionResult Create(User us)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    UserDBContext context = new UserDBContext();
                    bool check = context.AddUser(us);
                    if (check == true)
                    {
                        TempData["InsertionMessage"] = "Data Inserted Successfully.";
                        //clear model state would empty the data that was previously entered in form 
                        ModelState.Clear();
                        return RedirectToAction("CreatePassword");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            UserDBContext context = new UserDBContext();
            var row = context.GetUsers().Find(model => model.id == id); //if we find the id in getuser we get that row and add it to var row
            return View(row); //pass this row to create view of edit
        }
        [HttpPost]
        public ActionResult Edit(int id, User us)
        {
            if (ModelState.IsValid == true)
            {
                UserDBContext context = new UserDBContext();
                bool check = context.UpdateUser(us);
                if (check == true)
                {
                    TempData["UpdationMessage"] = "Data Updated Successfully.";
                    //clear model state would empty the data that was previously entered in form 
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            UserDBContext context = new UserDBContext();
            var row = context.GetUsers().Find(model => model.id == id);
            return View(row);
        }
        public ActionResult Delete(int id)
        {
            UserDBContext context = new UserDBContext();
            var row = context.GetUsers().Find(model => model.id == id);
            return View(row);
        }
        [HttpPost]
        public ActionResult Delete(int id,User us)
        {
            UserDBContext context = new UserDBContext();
            bool check = context.DeleteUser(id);
            if (check == true)
            {
                TempData["DeletionMessage"] = "Data Deleted Successfully.";
                //clear model state would empty the data that was previously entered in form 
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            return View();
        }



    }
}
