//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace B_B_FINAL_EVE.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class District
    {
        public District()
        {
            this.Donors = new HashSet<Donor>();
            this.Requisitions = new HashSet<Requisition>();
            this.Thanas = new HashSet<Thana>();
        }
    
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
        public Nullable<bool> Status { get; set; }
    
        public virtual ICollection<Donor> Donors { get; set; }
        public virtual ICollection<Requisition> Requisitions { get; set; }
        public virtual ICollection<Thana> Thanas { get; set; }
    }
}
