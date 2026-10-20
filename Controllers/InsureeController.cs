using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CarInsurance.Models;

namespace CarInsurance.Controllers
{
    public class InsureeController : Controller
    {
        private readonly InsuranceEntities db = new InsuranceEntities();

        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(400);
            var insuree = db.Insurees.Find(id);
            if (insuree == null) return HttpNotFound();
            return View(insuree);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                insuree.Quote = CalculateQuote(insuree);
                db.Insurees.Add(insuree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insuree);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(400);
            var insuree = db.Insurees.Find(id);
            if (insuree == null) return HttpNotFound();
            return View(insuree);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                insuree.Quote = CalculateQuote(insuree);
                db.Entry(insuree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insuree);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(400);
            var insuree = db.Insurees.Find(id);
            if (insuree == null) return HttpNotFound();
            return View(insuree);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var insuree = db.Insurees.Find(id);
            if (insuree == null) return HttpNotFound();
            db.Insurees.Remove(insuree);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Admin()
        {
            return View(db.Insurees.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList());
        }

        private decimal CalculateQuote(Insuree insuree)
        {
            decimal quote = 50m;
            DateTime today = DateTime.Today;
            int age = today.Year - insuree.DateOfBirth.Year;
            if (insuree.DateOfBirth.Date > today.AddYears(-age)) age--;

            if (age <= 18) quote += 100m;
            else if (age <= 25) quote += 50m;
            else quote += 25m;

            if (insuree.CarYear < 2000 || insuree.CarYear > 2015) quote += 25m;

            if (string.Equals(insuree.CarMake, "Porsche", StringComparison.OrdinalIgnoreCase))
            {
                quote += 25m;
                if (string.Equals(insuree.CarModel, "911 Carrera", StringComparison.OrdinalIgnoreCase))
                    quote += 25m;
            }

            quote += insuree.SpeedingTickets * 10m;
            if (insuree.DUI) quote *= 1.25m;
            if (insuree.CoverageType) quote *= 1.50m;

            return Math.Round(quote, 2, MidpointRounding.AwayFromZero);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}
