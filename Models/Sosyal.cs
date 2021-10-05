using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DenizWeb.Models
{
    public class Sosyal
    {
        [Key]
        public int sosyalId { get; set; }

        [Display(Name = "URL")]
        public string sosyalUrl { get; set; }

        [Display(Name = "Medya Türü")]
        public string sosyalTur { get; set; }

        [Display(Name = "Bilgi")]
        public string sosyalInfo { get; set; }

        [Display(Name = "Footer")]
        public string sosyalFooter { get; set; }
    }
}
