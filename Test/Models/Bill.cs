//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bill
    {
        public int BillID { get; set; }
        public int CustomerID { get; set; }
        public System.DateTime Date { get; set; }
        public int Amount { get; set; }
        public Nullable<int> Balance { get; set; }
        public Nullable<int> Net_Balance { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
