using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DenizWeb.Models;
using Microsoft.EntityFrameworkCore;


namespace DenizWeb.Controllers
{
    public class BlogController:Controller
    {
        private readonly VeriContext _context;

        public BlogController(VeriContext context)
        {
            _context = context;
        }


        public IActionResult Icerik(string text)
        {
            var blog = from Blog in _context.Blog where Blog.idName == text select Blog;
            var site = _context.Site.ToList();
            var sosyal = _context.Sosyal.ToList();
            var icerik = from Icerik in _context.Icerik where Icerik.Blog.idName == text select Icerik;
            var yorum = from Yorum in _context.Yorum where Yorum.Blog.idName == text where Yorum.onay == true  select Yorum;
            var usr = _context.User.ToList();
            var ban = _context.Ban.ToList();
            var Class = new Alldata();
            Class.Site = site;
            Class.Sosyal = sosyal;
            Class.Icerik = icerik.ToList();
            Class.Blog = blog.ToList();
            Class.User = usr;
            Class.Yorum = yorum.ToList();
            Class.Ban = ban;
            return View(Class);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Icerik([Bind("id,icerik,userId,blogId")] Yorum yorum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yorum);
                await _context.SaveChangesAsync();
                return Redirect("../Home/Blog");
            }
            return View(yorum);
        }

        public async Task<IActionResult> YorumDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorum = await _context.Yorum
                .Include(y => y.Blog)
                .Include(y => y.User)
                .FirstOrDefaultAsync(m => m.id == id);
            if (yorum == null)
            {
                return NotFound();
            }

            return View(yorum);
        }

        [HttpPost, ActionName("YorumDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YorumDeleteConfirmed(int id)
        {
            var yorum = await _context.Yorum.FindAsync(id);
            _context.Yorum.Remove(yorum);
            await _context.SaveChangesAsync();
            return Redirect("../../Home/Blog");
        }

    }
}
