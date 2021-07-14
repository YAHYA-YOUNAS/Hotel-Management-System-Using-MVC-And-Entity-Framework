using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project__Hotel_Management_System.Models;

namespace Project__Hotel_Management_System.Controllers
{
    
    public class BookingsController : Controller
    {
        db_HotelManagementSystemEntities db = new db_HotelManagementSystemEntities();

        [Route("Bookings/Index")]
        public ActionResult Index()
        {
            var data = db.tbl_bookings.ToList();
            return View(data);

        }

        [Route("Bookings/Create")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("Bookings/Create")]
        [HttpPost]
        public ActionResult Create(tbl_bookings booking)
        {
            if (ModelState.IsValid == true)
            {
                db.tbl_bookings.Add(booking);
                int result = db.SaveChanges();
                if (result > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('New booking added successfully.')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["InsertMessage"] = "<script>alert('Booking Failed!')</script>";
                }
            }
            return View();
        }

        [Route("Bookings/Edit")]
        public ActionResult Edit(int id)
        {
            var row = db.tbl_bookings.Where(model => model.booking_id == id).FirstOrDefault();
            return View(row);
        }

        [Route("Bookings/Edit")]
        [HttpPost]
        public ActionResult Edit(tbl_bookings booking)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(booking).State = EntityState.Modified;
                int result = db.SaveChanges();
                if (result > 0)
                {
                    TempData["UpdateMessage"] = "<script>alert('Booking information is updated successfully.')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["UpdateMessage"] = "<script>alert('Booking failed!')</script>";
                }
            }
            return View();
        }

        [Route("Bookings/Delete")]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var deletedRow = db.tbl_bookings.Where(model => model.booking_id == id).FirstOrDefault();
                if (deletedRow != null)
                {
                    db.Entry(deletedRow).State = EntityState.Deleted;
                    int result = db.SaveChanges();
                    if (result > 0)
                    {
                        TempData["DeleteMessage"] = "<script>alert('Booking cancelled.')</script>";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["DeleteMessage"] = "<script>alert('Unable to cancel booking!')</script>";
                    }
                }
            }
            return View();
        }

        [Route("Bookings/Details")]

        public ActionResult Details(int id)
        {
            var row = db.tbl_bookings.Where(model => model.booking_id == id).FirstOrDefault();
            return View(row);
        }

	}
}