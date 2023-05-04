using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Work_01.Models.MetaData
{
    public class MovieType
    {
        public int MovieId { get; set; }
        [Required, StringLength(50)]
        public string Title { get; set; }
        [Required, DataType(DataType.Date), Display(Name ="Release Date"), DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}")]
        public System.DateTime ReleaseDate { get; set; }
        [Required, Display(Name ="IMDB Rating")]
        public double ImdbRating { get; set; }
        [Required, Display(Name = "Rotten Tomato Rating")]
        public int RottenTomatoFreshness { get; set; }
    }
}