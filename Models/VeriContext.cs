using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DenizWeb.Models
{
    public class VeriContext : IdentityDbContext<User>
    {
        public VeriContext(DbContextOptions<VeriContext> options) : base(options)
        {

        }
        public DbSet<Site> Site { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Yorum> Yorum { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Okul> Okul { get; set; }
        public DbSet<SliderFoto> SliderFoto { get; set; }
        public DbSet<Icerik> Icerik { get; set; }
        public DbSet<Sosyal> Sosyal { get; set; }
        public DbSet<Beceriler> Beceriler { get; set; }
        public DbSet<Ban> Ban { get; set; }
        public DbSet<Eklenenler> Eklenenler { get; set; }

    }
}
