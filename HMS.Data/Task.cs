//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HMS.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Task
    {
        public int taskId { get; set; }
        public Nullable<int> LeadID { get; set; }
        public string Comments { get; set; }
        public Nullable<int> createdby { get; set; }
        public Nullable<System.DateTime> createdon { get; set; }
    }
}
