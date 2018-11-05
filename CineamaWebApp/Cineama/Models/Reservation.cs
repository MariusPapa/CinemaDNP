using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cineama.Models
{
    public class Reservation
    {
        [Key]
        public int id { get; set; }
        public virtual ScreeningModel screening { get; set; }
        [Required]
        public int ScreeningModelId { get; set; }
        public virtual ApplicationUser user { get; set; }
        [Required]
        public string ApplicationUserId { get; set; }
    }
}