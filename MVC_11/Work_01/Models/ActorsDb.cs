using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Work_01.Models.Metadata;

namespace Work_01.Models
{
    [MetadataType(typeof(ActorType))]
    public partial class Actors
    {
    }
}