using System.Collections.Generic;
using System.Linq;
using Repository_CodeFirst;
using UI_MVC_ProjectDB.Models;
using LibrarieModele;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Web.Mvc;
using System.Net;

namespace UI_MVC_ProjectDB.Controllers
{
    public class UploadedFilesController : Controller
    {
        private PDFtoWordConverterDatabaseVersion2Context db = new PDFtoWordConverterDatabaseVersion2Context();

        // GET: UploadedFiles
        public ActionResult Index()
        {
            List<UPLOADED_FILE> uploadedFiles = db.UPLOADED_FILES.ToList();
            List<UploadedFileViewModel> uploadedFilesViewModel = new List<UploadedFileViewModel>();
            foreach (UPLOADED_FILE uploadedFile in uploadedFiles)
            {
                UploadedFileViewModel uploadedFileViewModel = new UploadedFileViewModel()
                {
                    FILE_ID = uploadedFile.FILE_ID,
                    USER_ID = uploadedFile.USER_ID,
                    FILE_NAME = uploadedFile.FILE_NAME,
                    FILE_LOCATION = uploadedFile.FILE_LOCATION,
                    UPLOAD_DATE = uploadedFile.UPLOAD_DATE
                };
                uploadedFilesViewModel.Add(uploadedFileViewModel);
            }
            return View(uploadedFilesViewModel);
        }

        // GET: UploadedFiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UPLOADED_FILE uploadedFile = db.UPLOADED_FILES.Find(id);
            if (uploadedFile == null)
            {
                return HttpNotFound();
            }
            UploadedFileViewModel uploadedFileViewModel = new UploadedFileViewModel()
            {
                FILE_ID = uploadedFile.FILE_ID,
                USER_ID = uploadedFile.USER_ID,
                FILE_NAME = uploadedFile.FILE_NAME,
                FILE_LOCATION = uploadedFile.FILE_LOCATION,
                UPLOAD_DATE = uploadedFile.UPLOAD_DATE
            };
            return View(uploadedFileViewModel);
        }

        // GET: UploadedFiles/Create
        public ActionResult Create()
        {
            UploadedFileViewModel model = new UploadedFileViewModel();
            return View(model);
        }

        // POST: UploadedFiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UploadedFileViewModel uploadedFileViewModel)
        {
            if (ModelState.IsValid)
            {
                UPLOADED_FILE uploadedFile = new UPLOADED_FILE()
                {
                    FILE_ID = uploadedFileViewModel.FILE_ID,
                    USER_ID = uploadedFileViewModel.USER_ID,
                    FILE_NAME = uploadedFileViewModel.FILE_NAME,
                    FILE_LOCATION = uploadedFileViewModel.FILE_LOCATION,
                    UPLOAD_DATE = uploadedFileViewModel.UPLOAD_DATE
                };
                db.UPLOADED_FILES.Add(uploadedFile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uploadedFileViewModel);
        }

        // GET: UploadedFiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UPLOADED_FILE uploadedFile = db.UPLOADED_FILES.Find(id);
            if (uploadedFile == null)
            {
                return HttpNotFound();
            }
            UploadedFileViewModel uploadedFileViewModel = new UploadedFileViewModel()
            {
                FILE_ID = uploadedFile.FILE_ID,
                USER_ID = uploadedFile.USER_ID,
                FILE_NAME = uploadedFile.FILE_NAME,
                FILE_LOCATION = uploadedFile.FILE_LOCATION,
                UPLOAD_DATE = uploadedFile.UPLOAD_DATE
            };
            return View(uploadedFileViewModel);
        }

        // POST: UploadedFiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.\
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FILE_ID, USER_ID, FILE_NAME, FILE_LOCATION, UPLOAD_DATE")] UploadedFileViewModel uploadedFileViewModel)
        {
            if (ModelState.IsValid)
            {
                UPLOADED_FILE uploadedFile = new UPLOADED_FILE()
                {
                    FILE_ID = uploadedFileViewModel.FILE_ID,
                    USER_ID = uploadedFileViewModel.USER_ID,
                    FILE_NAME = uploadedFileViewModel.FILE_NAME,
                    FILE_LOCATION = uploadedFileViewModel.FILE_LOCATION,
                    UPLOAD_DATE = uploadedFileViewModel.UPLOAD_DATE
                };
                db.Entry(uploadedFile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uploadedFileViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: UploadedFiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UPLOADED_FILE uploadedFile = db.UPLOADED_FILES.Find(id);
            if (uploadedFile == null)
            {
                return HttpNotFound();
            }
            UploadedFileViewModel uploadedFileViewModel = new UploadedFileViewModel()
            {
                FILE_ID = uploadedFile.FILE_ID,
                USER_ID = uploadedFile.USER_ID,
                FILE_NAME = uploadedFile.FILE_NAME,
                FILE_LOCATION = uploadedFile.FILE_LOCATION,
                UPLOAD_DATE = uploadedFile.UPLOAD_DATE
            };
            return View(uploadedFileViewModel);
        }

        // POST: UploadedFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UPLOADED_FILE uploadedFile = db.UPLOADED_FILES.Find(id);
            if (uploadedFile == null)
            {
                return HttpNotFound();
            }
            db.UPLOADED_FILES.Remove(uploadedFile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
