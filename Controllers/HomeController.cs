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
        // GET: Home
<<<<<<< Updated upstream
=======
        //public ActionResult Login()
        //{
        //    return View();
        //}

        public ActionResult CreatePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePassword(Password ps)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    PasswordDBContext context = new PasswordDBContext();
                    bool check = context.AddPassword(ps);
                    Console.WriteLine(check);
                    if (check == true)
                    {
                        TempData["UserRegisteredMessage"] = "User Registered Successfully";
                        //clear model state would empty the data that was previously entered in form 
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        //public ActionResult ForgetPassword()
        //{
        //    return View();

        //}
>>>>>>> Stashed changes
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
