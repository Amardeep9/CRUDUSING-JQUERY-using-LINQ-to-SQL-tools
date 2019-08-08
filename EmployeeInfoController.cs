using CrudUsingJQueryUpdated.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudUsingJQueryUpdated.Controllers
{
    public class EmployeeInfoController : Controller
    {
        JQueryCrudDataContext db = new JQueryCrudDataContext();
        public ActionResult Index() //Record Select  
        {
            List<EmployeeData> EmployeeDatas = db.EmployeeDatas.OrderByDescending(x => x.EmpID).ToList<EmployeeData>();
            return View(EmployeeDatas);
        }
        [HttpGet]
        public PartialViewResult Create()   //Insert PartialView  
        {
            return PartialView(new CrudUsingJQueryUpdated.Models.EmployeeInfo());
        }
        [HttpPost]
        public JsonResult Create(CrudUsingJQueryUpdated.EmployeeData Emp) // Record Insert  
        {
            JQueryCrudDataContext db = new JQueryCrudDataContext();
            db.EmployeeDatas.InsertOnSubmit(Emp);
            db.SubmitChanges();
            return Json(Emp, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public PartialViewResult Edit(Int32 empid)  // Update PartialView  
        {
            JQueryCrudDataContext db = new JQueryCrudDataContext();
            EmployeeData emp = db.EmployeeDatas.Where(x => x.EmpID == empid).FirstOrDefault();
            EmployeeInfo empinfo = new EmployeeInfo();

            empinfo.EmailId = emp.EmpID.ToString();
            empinfo.EmpName = emp.EmpName;
            empinfo.Contact = emp.Contact;
            empinfo.EmailId = emp.EmailId;

            return PartialView(empinfo);
        }

        [HttpPost]
        public JsonResult Edit(CrudUsingJQueryUpdated.EmployeeData employee)  // Record Update 
        {

            JQueryCrudDataContext db = new JQueryCrudDataContext();
            EmployeeData empdt = db.EmployeeDatas.Where(x => x.EmpID == employee.EmpID).FirstOrDefault();


            empdt.EmpName = employee.EmpName;
            empdt.Contact = employee.Contact;
            empdt.EmailId = employee.EmailId;
            db.SubmitChanges();

            return Json(empdt, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(Int32 empid)
        {
            EmployeeData emp = db.EmployeeDatas.Where(x => x.EmpID == empid).FirstOrDefault();
            db.EmployeeDatas.DeleteOnSubmit(emp);
            db.SubmitChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}