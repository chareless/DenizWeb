using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DenizWeb.Models
{
    public class Ban
    {
        [Key]
        [Display(Name = "BanID")]
        public int id { get; set; }

        [Display(Name = "Ban Durumu (Null/Banlı/Af)")]
        public string durum { get; set; }

        [Display(Name = "Banlandığı Tarih")]
        [DataType(DataType.Date)]
        public DateTime banTarihi { get; set; }

        [Display(Name = "UserId")]
        public string userId { get; set; }

        [ForeignKey("userId")]
        public User User { get; set; }
    }
}
