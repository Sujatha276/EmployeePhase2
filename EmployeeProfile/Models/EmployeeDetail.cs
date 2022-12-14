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
    
    public partial class EmployeeDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmployeeDetail()
        {
            this.Bills = new HashSet<Bill>();
            this.ClientMasters = new HashSet<ClientMaster>();
            this.AsignClienttoEmps = new HashSet<AsignClienttoEmp>();
        }
    
        public int EmpId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public Nullable<long> Phoneno { get; set; }
        public string Worklocation { get; set; }
        public Nullable<int> Employee_Designation_FK { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public Nullable<int> SubDepartmentId { get; set; }
        public string LancesoftID { get; set; }
        public Nullable<int> EmployeeTypeId { get; set; }
        public Nullable<int> ReportingManagerId { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public Nullable<int> Pincode { get; set; }
        public Nullable<bool> Active_Status { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string Vertical { get; set; }
        public string Gender { get; set; }
        public string Address_status { get; set; }
        public Nullable<bool> Working_internal { get; set; }
        public Nullable<System.DateTime> Joiningdate { get; set; }
        public Nullable<System.DateTime> Dateofbirth { get; set; }
        public Nullable<decimal> Salary { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientMaster> ClientMasters { get; set; }
        public virtual Department Department { get; set; }
        public virtual Designation Designation { get; set; }
        public virtual Employee_Type Employee_Type1 { get; set; }
        public virtual Login Login { get; set; }
        public decimal Lead_p_l { get; set; }
        public virtual SubDepartment SubDepartment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AsignClienttoEmp> AsignClienttoEmps { get; set; }
    }
}
