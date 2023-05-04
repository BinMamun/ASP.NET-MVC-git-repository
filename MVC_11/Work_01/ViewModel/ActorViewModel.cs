using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Work_01.Models.MetaData;

namespace Work_01.ViewModel
{
    public class ActorViewModel
    {
        public int ActorId { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
        public HttpPostedFileBase Picture { get; set; }
        [Required]
        public int MovieId { get; set; }
    }
}