using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DenizWeb.Models
{
    public class Alldata
    {
        public List<Site> Site { get; set; }
        public List<Okul> Okul { get; set; }
        public List<Yorum> Yorum { get; set; }
        public List<Blog> Blog { get; set; }
        public List<Icerik> Icerik { get; set; }
        public List<Sosyal> Sosyal { get; set; }
        public List<User> User { get; set; }
        public List<SliderFoto> SliderFoto { get; set; }
        public List <Beceriler> Beceriler { get; set; }
        public List <Ban> Ban { get; set; }

        public List<Blog> Blog2 { get; set; }

        public List<Eklenenler> Eklenen { get; set; }
        
        public Eklenenler eklenenler { get; set; }
        public Blog blog2 { get; set; }
    

        public Site site { get; set; }
        public Okul okul { get; set; }
        public Yorum yorum { get; set; }
        public Blog blog { get; set; }
        public Icerik icerik { get; set; }
        public Sosyal sosyal { get; set; }
        public User user { get; set; }
        public SliderFoto sliderfoto { get; set; }
        public Beceriler beceriler { get; set; }
        public Ban ban { get; set; }
    }
}
