//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeSplit
{
    using System;
    using System.Collections.Generic;
    
    public partial class member
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phonenumber { get; set; }
        public Nullable<int> collectedmoney { get; set; }
        public Nullable<int> idtrip { get; set; }
    
        public virtual trip trip { get; set; }
    }
}
