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
    
    public partial class route
    {
        public int id { get; set; }
        public string place { get; set; }
        public Nullable<int> cost { get; set; }
        public int idtrip { get; set; }
    
        public virtual trip trip { get; set; }
    }
}