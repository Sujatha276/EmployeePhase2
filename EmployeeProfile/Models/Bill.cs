//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeProfile.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bill
    {
        public int Billid { get; set; }
        public Nullable<int> BenchTenure { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<decimal> CubicleCost { get; set; }
        public Nullable<decimal> FoodCost { get; set; }
        public Nullable<decimal> ProfitOrLoss { get; set; }
        public Nullable<decimal> TotalExpenses { get; set; }
        public Nullable<decimal> TotalSalaryTillNow { get; set; }
        public Nullable<decimal> TransportationCost { get; set; }
        public Nullable<int> EmpId { get; set; }
        public Nullable<decimal> Amount { get; set; }
    
        public virtual EmployeeDetail EmployeeDetail { get; set; }
    }
}