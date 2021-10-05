using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DenizWeb.Models
{
    public class Blog
    {
        [Key]
        [Display(Name = "BlogID")]
        public int id { get; set; }

        [Display(Name = "ID Name")]
        public string idName { get; set; }

        [Display(Name = "Blog Türü")]
        public string blogTur { get; set; }

        [Display(Name = "Başlık")]
        public string baslik { get; set; }

        [Display(Name = "Alt Başlık")]
        public string altBaslik { get; set; }

        [Display(Name = "Açıklama")]
        [AllowHtml]
        public string aciklama { get; set; }

        [Display(Name = "Foto URL")]
        public string fotoUrl { get; set; }

        [Display(Name = "Ekleme Tarihi")]
        public string eklemeTarihi { get; set; }

        [Display(Name = "Değiştirme Tarihi")]
        public string degistirmeTarihi { get; set; }

        [Display(Name = "Sürüm")]
        public string surum { get; set; }

        [Display(Name = "Boyut")]
        public string boyut { get; set; }
        public ICollection<Icerik> icerik { get; set; }
        public ICollection<Yorum> yorumlar { get; set; }
    }
}
