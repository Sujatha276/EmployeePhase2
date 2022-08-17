using EmployeeProfile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeProfile.Controllers
{
    public class LeadDashboardController : Controller
    {
        
        public Employee_PortalEntities db = new Employee_PortalEntities();
        public ActionResult Index()
        {
            var user = TempData["UserId"] as Login;
            var data = db.EmployeeDetails.Where(x => x.ReportingManagerId == user.ID).ToList();
            return View(data);
        }

        public ActionResult Details(int Id)
        {
            AsignClienttoEmp obj1 = new AsignClienttoEmp();
            GetAllEployeedetails model = new GetAllEployeedetails();
            List<AsignClienttoEmp> lObj = new List<AsignClienttoEmp>();
            List<Bill> lObj1 = new List<Bill>();
            model.eployeeDetails = db.EmployeeDetails.Where(x => x.EmpId == Id).FirstOrDefault();
            var clientDetails = db.AsignClienttoEmps.Where(x => x.EmpId == Id).ToList();
            lObj = clientDetails;
            var billDetails = db.Bills.Where(x => x.EmpId == Id).ToList();
            lObj1 = billDetails;
            model.clientDetails = lObj;


            List<AddCalculationDetails> obj = new List<AddCalculationDetails>();
            var Bill_details = db.Bills.Where(x => x.EmpId == Id).FirstOrDefault();
            var employeeDetails = db.EmployeeDetails.Where(x => x.EmpId == Id).FirstOrDefault();
            var AsignClienttoEmp = db.AsignClienttoEmps.Where(x => x.EmpId == Id).FirstOrDefault();

        


            foreach (var item in clientDetails)
            {
                int btenure = 0;
                int tenure = 0;
                int Ctenure = 0;
                DateTime JD = DateTime.Parse(employeeDetails.Joiningdate.Value.ToString());

                tenure = (DateTime.Parse(DateTime.Now.ToString()) - JD).Days / 30;
                decimal paidtillnow = (Convert.ToDecimal(employeeDetails.Salary) * tenure);
                DateTime p1 = (clientDetails != null ? item.POS.Value : DateTime.Now);
                DateTime p2 = (clientDetails != null ? item.POE.Value : DateTime.Now);
                //int Ctenure = ((p2.Year - p1.Year) * 12) + p2.Month - p1.Month;
                int TotalCtenure = 0;
                if (employeeDetails.EmpId == AsignClienttoEmp.EmpId)
                {
                    Ctenure = ((p2.Year - p1.Year) * 12) + p2.Month - p1.Month;
                    TotalCtenure = TotalCtenure + Ctenure;

                }
                btenure = tenure - TotalCtenure;

                decimal bench_exp = Convert.ToDecimal(employeeDetails.Salary);
                decimal bench_expenes = 0;

                if (Bill_details != null)
                {
                    bench_expenes = btenure * (Bill_details.FoodCost.Value + Bill_details.TransportationCost.Value + Bill_details.CubicleCost.Value);
                }
                decimal Clientsal = TotalCtenure * (clientDetails != null ? Convert.ToDecimal(item.ClientBilling) : 0);
                if (employeeDetails.Salary != null && employeeDetails.Salary > 0 && tenure > 0)
                {
                    decimal Total = paidtillnow;
                }

                decimal Profit_loss = Clientsal - (paidtillnow + bench_expenes);


                obj.Add(new AddCalculationDetails
                {
                    CubicleCost = Bill_details.CubicleCost,
                    FoodCost = Bill_details.FoodCost,
                    TransportationCost = Bill_details.TransportationCost,
                    Salary = Convert.ToDecimal(employeeDetails.Salary),
                    Joiningdate = employeeDetails.Joiningdate,
                    POE = item.POE,
                    POS = item.POS,
                    bench_expenes = bench_expenes,
                    Tenure = tenure,
                    BenchTenure = btenure,
                    //employee_details.Totalexpences = bench_expenes; //employee salary on bench including expenes
                    TotalSalaryTillNow = paidtillnow + bench_expenes,
                    ProfitOrLoss = Profit_loss


                });
                //if (employeeDetails.Salary != null && employeeDetails.Salary > 0 && tenure > 0)
                //{
                //    decimal leadTotal = (employeeDetails.Salary != null ? employeeDetails.Salary.Value : 0) * (employeeDetails.EmpId = 3);
                //    obj.Add(new AddCalculationDetails
                //    {
                //        Lead_p_l = leadTotal - employeeDetails.ReportingManagerId == User.IsInRole("LEAD")



                //    }) ;
                if (employeeDetails.Salary != null && employeeDetails.Salary > 0 && tenure > 0)
                {
                    decimal leadTotal = (employeeDetails.Salary != null ? employeeDetails.Salary.Value : 0) * (employeeDetails.EmpId = 3);
                    employeeDetails.Lead_p_l = Convert.ToDecimal(leadTotal - (employeeDetails.ReportingManagerId = 3));


                }




                //if (empsal.salary1 != null && empsal.salary1 > 0 && tenure > 0)
                //{
                //    decimal ManagerTotal = (empsal.salary1 != null ? empsal.salary1.Value : 0) * (obj.desg_fk = 6);
                //    decimal ManagerTol = (empsal.salary1 != null ? empsal.salary1.Value : 0) * (obj.desg_fk = 5);
                //    obj.Manager_P_L = ManagerTol + ManagerTotal;
                //    obj.Manager_p_l = (ManagerTol + ManagerTotal) - (obj.desg_fk = 4);
                //}
                //return View();



            }
            model.billDetails = obj;



            return View(model);


        }
        public ActionResult Manager()
        {
            Manager mag = new Manager();
            
            var user = TempData["UserId"] as Login;
            var data = db.EmployeeDetails.Where(x => x.ReportingManagerId == user.ID).ToList();
            
            return View(data);
        }
        
        public ActionResult Welcome()
        {
            return View();
        }

    }
}
    
