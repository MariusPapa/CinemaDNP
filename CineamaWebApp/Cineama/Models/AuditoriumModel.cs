using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cineama.Models
{
    public class AuditoriumModel
    {
        [Key]
        public string id { get; set; }
        public int seats { get; set; }

    }
}