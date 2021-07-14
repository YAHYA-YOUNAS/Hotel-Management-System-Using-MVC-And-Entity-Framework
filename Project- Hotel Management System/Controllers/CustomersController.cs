using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project__Hotel_Management_System.Models;
using System.Data.Entity;

namespace Project__Hotel_Management_System.Controllers
{
    public class CustomersController : Controller
    {
        db_HotelManagementSystemEntities db = new db_HotelManagementSystemEntities();

        [Route("Customers/Index")]
        public ActionResult Index()
        {
            var data = db.tbl_customers.ToList();
            return View(data);
        }

        [Route("Customers/Add")]
        public ActionResult Add()
        {
            return View();
        }

        [Route("Customers/Add")]
        [HttpPost]
        public ActionResult Create(tbl_customers customer)
        {
            if (ModelState.IsValid == true)
            {
                db.tbl_customers.Add(customer);
                int result = db.SaveChanges();
                if (result > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('New customer added successfully.')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["InsertMessage"] = "<script>alert('Unable to add new customer!')</script>";
                }
            }
            return View();
        }

        [Route("Customers/Edit")]
        public ActionResult Edit(int id)
        {
            var row = db.tbl_customers.Where(model => model.customer_id == id).FirstOrDefault();
            return View(row);
        }

        [Route("Customers/Edit")]
        [HttpPost]
        public ActionResult Edit(tbl_customers customer)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(customer).State = EntityState.Modified;
                int result = db.SaveChanges();
                if (result > 0)
                {
                    TempData["UpdateMessage"] = "<script>alert('Customer information updated successfully.')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["UpdateMessage"] = "<script>alert('Unable to update customer information!')</script>";
                }
            }
            return View();
        }

        [Route("Customers/Delete")]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var deletedRow = db.tbl_customers.Where(model => model.customer_id == id).FirstOrDefault();
                if (deletedRow != null)
                {
                    db.Entry(deletedRow).State = EntityState.Deleted;
                    int result = db.SaveChanges();
                    if (result > 0)
                    {
                        TempData["DeleteMessage"] = "<script>alert('Customer information deleted successfully.')</script>";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["DeleteMessage"] = "<script>alert('Unable to delete customer information!')</script>";
                    }
                }
            }
            return View();
        }

        [Route("Customers/Details")]
        public ActionResult Details(int id)
        {
            var row = db.tbl_customers.Where(model => model.customer_id == id).FirstOrDefault();
            return View(row);
        }

	}
}