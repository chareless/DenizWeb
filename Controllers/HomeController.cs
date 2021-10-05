using DenizWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DenizWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly VeriContext _context;

        public HomeController(VeriContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var site = _context.Site.ToList();
            var beceri = _context.Beceriler.ToList();
            var okul = from Okul in _context.Okul orderby Okul.okulId descending select Okul;
            var slider = _context.SliderFoto.ToList();
            var sosyal = _context.Sosyal.ToList();
            var Class = new Alldata();
            Class.Site = site;
            Class.Okul = okul.ToList();
            Class.SliderFoto = slider;
            Class.Sosyal = sosyal;
            Class.Beceriler = beceri;
            return View(Class);
        }
        public IActionResult Blog()
        {
            var site = _context.Site.ToList();
            var blog = from Blog in _context.Blog orderby Blog.id descending select Blog;
            var sosyal = _context.Sosyal.ToList();
            var ekle = (_context.Eklenenler).Take(3);
            var blogicer =  _context.Blog.ToList();
            var Class = new Alldata();
            Class.Site = site;
            Class.Blog = blog.ToList();
            Class.Sosyal = sosyal;
            Class.Blog2 = blogicer;
            Class.Eklenen = ekle.ToList();
            return View(Class);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
