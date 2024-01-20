using System;
using System.Collections.Generic;
using System.Linq;
using Repository_CodeFirst;
using UI_MVC_ProjectDB.Models;
using LibrarieModele;
using NivelAccessDate;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;

namespace UI_MVC_ProjectDB.Controllers
{
    public class UsersController : Controller
    {
        private PDFtoWordConverterDatabaseVersion2Context db = new PDFtoWordConverterDatabaseVersion2Context();
        // GET: Users
        public ActionResult Index()
        {
            /*try
            {*/
                List<USER> users = db.USERS.ToList();
                List<UserViewModel> usersViewModel = new List<UserViewModel>();
                foreach (USER user in users)
                {
                    UserViewModel userViewModel = new UserViewModel()
                    {
                        USER_ID = user.USER_ID,
                        USERNAME = user.USERNAME,
                        PASSWORD = user.PASSWORD,
                        EMAIL = user.EMAIL,
                        PHONE = user.PHONE,
                        REGISTRATION_DATE = user.REGISTRATION_DATE,
                        LAST_LOGIN_DATE = user.LAST_LOGIN_DATE
                    };
                    usersViewModel.Add(userViewModel);
                }
                return View(usersViewModel);
            /*}
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                //throw; // rethrow the exception for better debugging
            }*/
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER user = db.USERS.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            UserViewModel userViewModel = new UserViewModel()
            {
                USER_ID = user.USER_ID,
                USERNAME = user.USERNAME,
                PASSWORD = user.PASSWORD,
                EMAIL = user.EMAIL,
                PHONE = user.PHONE,
                REGISTRATION_DATE = user.REGISTRATION_DATE,
                LAST_LOGIN_DATE = user.LAST_LOGIN_DATE
            };
            return View(userViewModel);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            UserViewModel model = new UserViewModel();
            return View(model);
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                USER user = new USER()
                {
                    USER_ID = userViewModel.USER_ID,
                    USERNAME = userViewModel.USERNAME,
                    PASSWORD = userViewModel.PASSWORD,
                    EMAIL = userViewModel.EMAIL,
                    PHONE = userViewModel.PHONE,
                    REGISTRATION_DATE = userViewModel.REGISTRATION_DATE,
                    LAST_LOGIN_DATE = userViewModel.LAST_LOGIN_DATE
                };
                db.USERS.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userViewModel);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER user = db.USERS.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            UserViewModel userViewModel = new UserViewModel()
            {
                USER_ID = user.USER_ID,
                USERNAME = user.USERNAME,
                PASSWORD = user.PASSWORD,
                EMAIL = user.EMAIL,
                PHONE = user.PHONE,
                REGISTRATION_DATE = user.REGISTRATION_DATE,
                LAST_LOGIN_DATE = user.LAST_LOGIN_DATE
            };
            return View(userViewModel);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "USER_ID,USERNAME,PASSWORD,EMAIL,PHONE,REGISTRATION_DATE,LAST_LOGIN_DATE")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                USER user = new USER()
                {
                    USER_ID = userViewModel.USER_ID,
                    USERNAME = userViewModel.USERNAME,
                    PASSWORD = userViewModel.PASSWORD,
                    EMAIL = userViewModel.EMAIL,
                    PHONE = userViewModel.PHONE,
                    REGISTRATION_DATE = userViewModel.REGISTRATION_DATE,
                    LAST_LOGIN_DATE = userViewModel.LAST_LOGIN_DATE
                };
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER user = db.USERS.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            UserViewModel userViewModel = new UserViewModel()
            {
                USER_ID = user.USER_ID,
                USERNAME = user.USERNAME,
                PASSWORD = user.PASSWORD,
                EMAIL = user.EMAIL,
                PHONE = user.PHONE,
                REGISTRATION_DATE = user.REGISTRATION_DATE,
                LAST_LOGIN_DATE = user.LAST_LOGIN_DATE
            };
            return View(userViewModel);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USER user = db.USERS.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            db.USERS.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
