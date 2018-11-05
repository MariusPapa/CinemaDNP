using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cineama.Models
{
   
    public class MovieModel
    {
      //  private static object sync = new object();
      //  private static int nextId;
      [Display(Name ="Title")]
        public string title { get; set; }
        [Display(Name = "Poster URL")]
        public string posterUrl { get; set; }
        [Display(Name = "Trailer URL")]
        public string trailer { get; set; }
        [Key]
        public int movieId { get; private set; }
        [Display(Name = "Director/s")]
        public string directors { get; set; }
        [Display(Name = "Stars")]
        public string actors { get; set; }
        [Display(Name = "Description")]

        public string description { get; set; }
       [Timestamp]
        public byte[] RowVersion { get; set; }

        /* public MovieModel()
         {
             lock (sync)
             {
                 this.movieId = ++nextId;
             }
         }
         */
    }

   

}