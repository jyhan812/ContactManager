using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DataEntity.Models;
using DataEntity;

namespace ContactManager.Controllers
{
    public class ContactModelsController : Controller
    {
        private ContactContext db = new ContactContext();


        public ViewResult Index()
        {
            return View(db.Contact.ToList());
        }


        // GET: Contact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactModel contactModel = db.Contact.Find(id);
            if (contactModel == null)
            {
                return HttpNotFound();
            }
            return View(contactModel);
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContactID,FirstName,LastName,Phone,Email,Street,City,State,PostalCode")] ContactModel contactModel)
        {
            if (ModelState.IsValid)
            {
                db.Contact.Add(contactModel);
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }

            return View(contactModel);
        }


        // GET: ContactModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ContactModel contactModel = db.Contact.Find(id);

            ContactDBEntities contactDBEntities = new ContactDBEntities();
            TempData["numberOfChanges"] = contactDBEntities.Audit_Retrieve(id).Select(s => s.numberOfChanges).ToList().FirstOrDefault();
            TempData["LastUpdateDateTime"] = contactDBEntities.Audit_Retrieve(id).Select(s => s.LastUpdateDateTime).ToList().FirstOrDefault();
           
            if (contactModel == null)
            {
                return HttpNotFound();
            }
            return View(contactModel);
        }

        // POST: ContactModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContactID,FirstName,LastName,Phone,Email,Street,City,State,PostalCode")] ContactModel contactModel)
        {
            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(contactModel).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");  
                }
            }            

            return View(contactModel);
        }

        // GET: ContactModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactModel contactModel = db.Contact.Find(id);
            if (contactModel == null)
            {
                return HttpNotFound();
            }
            return View(contactModel);
        }

        // POST: ContactModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactModel contactModel = db.Contact.Find(id);
            db.Contact.Remove(contactModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
