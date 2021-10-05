using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DenizWeb.Models
{
    public class Site
    {
        [Key]
        public int MyId { get; set; }

        [Display(Name = "İsim")]
        public string isim { get; set; }

        [Display(Name = "Meslek")]
        public string meslek { get; set; }

        [Display(Name = "Profil Resmi (URL)")]
        public string profileFotoUrl { get; set; }

        [Display(Name = "Arkaplan Resmi (URL)")]
        public string backFotoUrl { get; set; }

        [Display(Name = "Hakkımda")]
        [AllowHtml]
        public string hakkımda { get; set; }

        [Display(Name = "Doğum Tarihi")]
        public string dogumTarihi { get; set; }

        [Display(Name = "Doğum Yeri")]
        public string dogumYeri { get; set; }

        [Display(Name = "Eğitim Durumu")]
        public string egitimDurumu { get; set; }

        [Display(Name = "Eğitim Bölümü")]
        public string egitimBolumu { get; set; }

        [Display(Name = "Diller")]
        public string diller { get; set; }

        [Display(Name = "Adres")]
        public string adres { get; set; }

        [Display(Name = "Adres (URL)")]
        public string adresUrl { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Email (URL)")]
        public string emailUrl { get; set; }

        [Display(Name = "SliderFoto(URL)")]
        public string sliderFotoUrl { get; set; }

        [Display(Name = "SliderFoto Başlık")]
        public string sliderFotoBaslik { get; set; }

        [Display(Name = "SliderFoto Açıklama")]
        public string sliderFotoAciklama { get; set; }

        [Display(Name ="FormSpreeURL")]
        public string formUrl { get; set; }
    }
}
