using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DenizWeb.Models
{
    public class Icerik
    {
        [Key]
        public int icerikId { get; set; }

        [Display(Name = "ID Etiket")]
        public string idTag { get; set; }

        [Display(Name = "Başlık")]
        public string baslik { get; set; }

        [Display(Name = "Açıklama")]
        [AllowHtml]
        public string aciklama { get; set; }

        [Display(Name = "Ekleme Tarihi")]
        public string eklemeTarihi { get; set; }

        [Display(Name = "BlogID")]
        public int blogId { get; set; }

        [ForeignKey("blogId")]
        public Blog Blog { get; set; }
    }
}
