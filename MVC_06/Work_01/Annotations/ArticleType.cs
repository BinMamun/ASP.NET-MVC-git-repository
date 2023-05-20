using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Work_01.Annotations
{
    public class ArticleType
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Title { get; set; }
        [Required, DataType(DataType.Date), Display(Name ="Publish Date"),
            DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PublishDate { get; set; }
        [Required, Display(Name= "Total read")]
        public int TotalRead { get; set; }
    }
}