//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataHelper
{
    using System;
    using System.Collections.Generic;
    
    public partial class base_risk
    {
        public int ID { get; set; }
        public string CLASS { get; set; }
        public Nullable<double> Risk { get; set; }
		  public System.Data.Entity.Spatial.DbGeometry geom { get; set; }
    }
}
