using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cineama.Models
{
    public class ScreeningModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        public DateTime playDate { get; set; }
        
        public virtual MovieModel movie { get; set; }
        [Required]
        public int  MovieTitle { get; set; }
        
        public virtual AuditoriumModel Auditorium { get; set; }
        [Required]
        public string AuditoriumId { get; set; }

    }
}