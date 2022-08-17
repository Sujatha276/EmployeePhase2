using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeProfile.Models;

namespace EmployeeProfile.Controllers
{
    [Authorize]
    public class EmployeeDetailsController : Controller
    {
       
        private Employee_PortalEntities db = new Employee_PortalEntities();

        // GET: EmployeeDetails
        public ActionResult Index()
        {
            var employeeDetails = db.EmployeeDetails.Include(e => e.Department).Include(e => e.Designation).Include(e => e.Employee_Type1).Include(e => e.Login).Include(e => e.SubDepartment);
            return View(employeeDetails.ToList());
        }

        // GET: EmployeeDetails/Details/5
        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            //EmployeeDetail obj = new EmployeeDetail();
            //var employee_details = db.EmployeeDetails.Where(x => x.EmpId == id).FirstOrDefault();
            //if (employee_details != null)
            //{
            //    obj.Firstname = employee_details.Firstname;
            //    obj.Lastname = employee_details.Lastname;
            //    obj.Email = employee_details.Email;
            //    obj.Phoneno = employee_details.Phoneno;
            //    obj.Dateofbirth = employee_details.Dateofbirth;
            //    obj.EmployeeTypeId = employee_details.EmployeeTypeId;
            //    obj.Employee_Designation_FK = employee_details.Employee_Designation_FK;
            //    obj.Joiningdate = employee_details.Joiningdate;
            //    obj.Active_Status = employee_details.Active_Status;
            //    obj.Address_status = employee_details.Address_status;
            //    obj.City = employee_details.City;
            //    obj.Country = employee_details.Country;
            //    obj.Salary = employee_details.Salary;
            //    obj.Working_internal = employee_details.Working_internal;
            //    obj.Worklocation = employee_details.Worklocation;
            //    obj.DepartmentId = employee_details.DepartmentId;

            //    obj.SubDepartmentId = employee_details.SubDepartmentId;
            //    obj.LancesoftID = employee_details.LancesoftID;
            //    obj.Vertical = employee_details.Vertical;
            //    obj.ReportingManagerId = employee_details.ReportingManagerId;
            //    obj.State = employee_details.State;
            //    obj.Street = employee_details.Street;
            //    obj.Pincode = employee_details.Pincode;
            //    obj.Gender = employee_details.Gender;

            //    //obj.master_emp_detail2 = employee_details.master_emp_detail2;
            //    //obj.master_emp_detail3 = employee_details.master_emp_detail3;





            //}
            //Bill _empbills = employee_details.Bills.FirstOrDefault();
            ////AddEmployee empsal =empsal.Salary.Value()/*Where(x => x.emp_id == id).*/FirstOrDefault();


            //AsignClienttoEmp asign = employee_details.AsignClienttoEmps.Where(x => x.EmpId == id).FirstOrDefault();
            //DateTime Jd = DateTime.Parse(obj.Joiningdate.ToString());
            //decimal Salary = (employee_details.Salary.Value);

            //int tenure = (DateTime.Parse(DateTime.Now.ToString()) - Jd).Days / 30;
            //decimal paidtillnow = (Salary * tenure);
            //DateTime p1 = (asign != null ? asign.POS.Value : DateTime.Now);
            //DateTime p2 = (asign != null ? asign.POE.Value : DateTime.Now);
            //int Ctenure = ((p2.Year - p1.Year) * 12) + p2.Month - p1.Month;
            //int btenure = tenure - Ctenure;
            //decimal bench_exp = Salary;
            //decimal bench_expenes = 0;
            //if (_empbills  != null)
            //{
            //    bench_expenes = btenure * (_empbills.FoodCost.Value + _empbills.TransportationCost.Value + _empbills.CubicleCost.Value);
            //}
            //decimal Clientsal = Ctenure * (asign != null ? asign.ClientSalary.Value : 0);
            //if (obj.Salary != null && obj.Salary > 0 && tenure > 0)
            //{
            //    obj.TotalSalaryTillNow = paidtillnow;
            //}
            //obj.Tenure = tenure;
            //obj.BenchTenure = btenure;
            ////employee_details.Totalexpences = bench_expenes; //employee salary on bench including expenes
            //obj.TotalSalaryTillNow = paidtillnow + bench_expenes;
            //decimal Profit_loss = Clientsal - (paidtillnow + bench_expenes);
            //obj.ProfitOrLoss = Profit_loss;


            ////if (obj.Salary != null && obj.Salary > 0 && tenure > 0)
            ////{
            ////    decimal leadTotal = (obj.Salary != null ? obj.Salary.Value : 0) * (obj.EmpId = 6);
            ////    obj.Lead_p_l = leadTotal - (obj.supervisor_fk = 6);


            ////}


            ////if (empsal.salary1 != null && empsal.salary1 > 0 && tenure > 0)
            ////{
            ////    decimal ManagerTotal = (empsal.salary1 != null ? empsal.salary1.Value : 0) * (obj.desg_fk = 6);
            ////    decimal ManagerTol = (empsal.salary1 != null ? empsal.salary1.Value : 0) * (obj.desg_fk = 5);
            ////    obj.Manager_P_L = ManagerTol + ManagerTotal;
            ////    obj.Manager_p_l = (ManagerTol + ManagerTotal) - (obj.desg_fk = 4);
            ////}







            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetail);
        }
        
        // GET: EmployeeDetails/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName");
            ViewBag.Employee_Designation_FK = new SelectList(db.Designations, "DesignationId", "DesignationName");
            ViewBag.EmployeeTypeId = new SelectList(db.Employee_Type, "EmployeeTypeid", "EmployeeType");
            ViewBag.ReportingManagerId = new SelectList(db.Logins, "ID", "Name");
            ViewBag.SubDepartmentId = new SelectList(db.SubDepartments, "SDepartmentId", "Name");
            return View();
        }

        // POST: EmployeeDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpId,Firstname,Lastname,Email,Phoneno,Worklocation,Employee_Designation_FK,DepartmentId,SubDepartmentId,LancesoftID,EmployeeTypeId,ReportingManagerId,Country,State,City,Street,Pincode,Active_Status,CreatedDate,CreatedBy,Vertical,Gender,Address_status,Working_internal,Joiningdate,Dateofbirth,Salary")] EmployeeDetail employeeDetail)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeDetails.Add(employeeDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", employeeDetail.DepartmentId);
            ViewBag.Employee_Designation_FK = new SelectList(db.Designations, "DesignationId", "DesignationName", employeeDetail.Employee_Designation_FK);
            ViewBag.EmployeeTypeId = new SelectList(db.Employee_Type, "EmployeeTypeid", "EmployeeType", employeeDetail.EmployeeTypeId);
            ViewBag.ReportingManagerId = new SelectList(db.Logins, "ID", "Name", employeeDetail.ReportingManagerId);
            ViewBag.SubDepartmentId = new SelectList(db.SubDepartments, "SDepartmentId", "Name", employeeDetail.SubDepartmentId);
            return View(employeeDetail);
        }

        // GET: EmployeeDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", employeeDetail.DepartmentId);
            ViewBag.Employee_Designation_FK = new SelectList(db.Designations, "DesignationId", "DesignationName", employeeDetail.Employee_Designation_FK);
            ViewBag.EmployeeTypeId = new SelectList(db.Employee_Type, "EmployeeTypeid", "EmployeeType", employeeDetail.EmployeeTypeId);
            ViewBag.ReportingManagerId = new SelectList(db.Logins, "ID", "Name", employeeDetail.ReportingManagerId);
            ViewBag.SubDepartmentId = new SelectList(db.SubDepartments, "SDepartmentId", "Name", employeeDetail.SubDepartmentId);
            return View(employeeDetail);
        }

        // POST: EmployeeDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpId,Firstname,Lastname,Email,Phoneno,Worklocation,Employee_Designation_FK,DepartmentId,SubDepartmentId,LancesoftID,EmployeeTypeId,ReportingManagerId,Country,State,City,Street,Pincode,Active_Status,CreatedDate,CreatedBy,Vertical,Gender,Address_status,Working_internal,Joiningdate,Dateofbirth,Salary")] EmployeeDetail employeeDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", employeeDetail.DepartmentId);
            ViewBag.Employee_Designation_FK = new SelectList(db.Designations, "DesignationId", "DesignationName", employeeDetail.Employee_Designation_FK);
            ViewBag.EmployeeTypeId = new SelectList(db.Employee_Type, "EmployeeTypeid", "EmployeeType", employeeDetail.EmployeeTypeId);
            ViewBag.ReportingManagerId = new SelectList(db.Logins, "ID", "Name", employeeDetail.ReportingManagerId);
            ViewBag.SubDepartmentId = new SelectList(db.SubDepartments, "SDepartmentId", "Name", employeeDetail.SubDepartmentId);
            return View(employeeDetail);
        }

        // GET: EmployeeDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetail);
        }

        // POST: EmployeeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(id);
            db.EmployeeDetails.Remove(employeeDetail);
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
