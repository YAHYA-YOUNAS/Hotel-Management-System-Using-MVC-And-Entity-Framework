using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project__Hotel_Management_System.Models;
using System.Data.Entity;

namespace Project__Hotel_Management_System.Controllers
{
    public class RoomsController : Controller
    {
        db_HotelManagementSystemEntities db = new db_HotelManagementSystemEntities();

        [Route("Rooms/Index")]
        public ActionResult Index()
        {
            var data = db.tbl_rooms.ToList();
            return View(data);
        }

        [Route("Rooms/Add")]
        public ActionResult Add()
        {
            return View();
        }

        [Route("Rooms/Add")]
        [HttpPost]
        public ActionResult Add(tbl_rooms room)
        {
            if (ModelState.IsValid == true)
            {
                db.tbl_rooms.Add(room);
                int result = db.SaveChanges();
                if (result > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('New room added successfully.')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["InsertMessage"] = "<script>alert('Unable to add new room!')</script>";
                }
            }
            return View();
        }

        [Route("Rooms/Edit")]
        public ActionResult Edit(int id)
        {
            var row = db.tbl_rooms.Where(model => model.room_id == id).FirstOrDefault();
            return View(row);
        }

        [Route("Rooms/Edit")]
        [HttpPost]
        public ActionResult Edit(tbl_rooms room)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(room).State = EntityState.Modified;
                int result = db.SaveChanges();
                if (result > 0)
                {
                    TempData["UpdateMessage"] = "<script>alert('Room information is updated successfully.')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["UpdateMessage"] = "<script>alert('Unable to modify room information!')</script>";
                }
            }
            return View();
        }

        [Route("Rooms/Delete")]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var deletedRow = db.tbl_rooms.Where(model => model.room_id == id).FirstOrDefault();
                if (deletedRow != null)
                {
                    db.Entry(deletedRow).State = EntityState.Deleted;
                    int result = db.SaveChanges();
                    if (result > 0)
                    {
                        TempData["DeleteMessage"] = "<script>alert('Room deleted successfully.')</script>";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["DeleteMessage"] = "<script>alert('Unable to delete room!')</script>";
                    }
                }
            }
            return View();
        }

        [Route("Rooms/Details")]
        public ActionResult Details(int id)
        {
            var row = db.tbl_rooms.Where(model => model.room_id == id).FirstOrDefault();
            return View(row);
        }
	}
}