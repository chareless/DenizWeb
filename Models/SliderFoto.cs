using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DenizWeb.Models
{
    public class SliderFoto
    {
        [Key]
        public int sliderFotoId { get; set; }

        [Display(Name = "URL")]
        public string fotoUrl { get; set; }

        [Display(Name = "Başlık")]
        public string fotoBaslik { get; set; }

        [Display(Name = "Açıklama")]
        public string fotoAciklama { get; set; }
    }
}
