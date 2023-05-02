using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Work_01.Models.Metadata
{
    public enum Gender { Male= 1, Female}
    public class ActorType
    {
        public int ActorId { get; set; }
        [Required,StringLength(50)]
        public string Name { get; set; }
        [Required, EnumDataType(typeof(Gender))]
        public int Gender { get; set; }
        [Required, StringLength(150)]
        public string Picture { get; set; }
        [Required]
        public int MovieId { get; set; }
    }
}