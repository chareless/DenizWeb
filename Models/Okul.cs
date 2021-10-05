using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DenizWeb.Models
{
    public class Okul
    {
        [Key]
        public int okulId { get; set; }

        [Display(Name = "Okul Adı")]
        public string okulAd { get; set; }

        [Display(Name = "Okul Tarihi")]
        public string okulTarih { get; set; }

        [Display(Name = "Okul Türü")]
        public string okulTur { get; set; }

        [Display(Name = "Okul Bilgileri")]
        public string okulInfo { get; set; }
    }
}
