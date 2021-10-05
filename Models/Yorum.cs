using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DenizWeb.Models
{
    public class Yorum
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "İçerik")]
        [AllowHtml]
        public string icerik { get; set; }

        [Display(Name = "Yorum Onayı")]
        public bool onay { get; set; }

        [Display(Name = "UserId")]
        public string userId { get; set; }

        [Display(Name = "BlogId")]
        public int blogId { get; set; }

        [ForeignKey("userId")]
        public User User { get; set; }

        [ForeignKey("blogId")]
        public Blog Blog { get; set; }
    }
}