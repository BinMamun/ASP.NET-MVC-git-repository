//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Work_01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Work_01.Models.Metadata;


    public partial class Actors
    {
        public int ActorId { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public string Picture { get; set; }
        public int MovieId { get; set; }    
        public virtual Movies Movies { get; set; }
    }
}
