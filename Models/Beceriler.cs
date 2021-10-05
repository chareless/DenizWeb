using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DenizWeb.Models
{
    public class Beceriler
    {
        [Key]
        [Display(Name = "BeceriID")]
        public int id { get; set; }

        [Display(Name = "Beceri")]
        public string beceri { get; set; }

        [Display(Name = "Açıklama")]
        [AllowHtml]
        public string aciklama { get; set; }
    }
}
