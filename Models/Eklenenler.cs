using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DenizWeb.Models
{
    public class Eklenenler
    {
        [Key]
        [Display(Name = "EklenenID")]
        public int id { get; set; }

        [Display(Name = "ID Name")]
        public string idName { get; set; }

        [Display(Name = "Başlık")]
        public string baslik { get; set; }

        [Display(Name = "Tarih")]
        public string tarih { get; set; }
    }
}
