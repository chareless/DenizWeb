using DenizWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DenizWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        

        private readonly VeriContext _context;

        public AdminController(VeriContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var site = _context.Site.ToList();
            var okul = _context.Okul.ToList();
            var slider = _context.SliderFoto.ToList();
            var sosyal = _context.Sosyal.ToList();
            var beceriler = _context.Beceriler.ToList();
            var Class = new Alldata();
            Class.Site = site;
            Class.Okul = okul;
            Class.SliderFoto = slider;
            Class.Sosyal = sosyal;
            Class.Beceriler = beceriler;
            return View(Class);
        }

        // GET: Sites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.Site
                .FirstOrDefaultAsync(m => m.MyId == id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // GET: Sites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MyId,isim,meslek,profileFotoUrl,backFotoUrl,hakkımda,dogumTarihi,dogumYeri,egitimDurumu,egitimBolumu,diller,adres,adresUrl,email,emailUrl,sliderFotoUrl,sliderFotoBaslik,sliderFotoAciklama,formUrl")] Site site)
        {
            if (ModelState.IsValid)
            {
                _context.Add(site);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(site);
        }

        // GET: Sites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.Site.FindAsync(id);
            if (site == null)
            {
                return NotFound();
            }
            return View(site);
        }

        // POST: Sites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MyId,isim,meslek,profileFotoUrl,backFotoUrl,hakkımda,dogumTarihi,dogumYeri,egitimDurumu,egitimBolumu,diller,adres,adresUrl,email,emailUrl,sliderFotoUrl,sliderFotoBaslik,sliderFotoAciklama,formUrl")] Site site)
        {
            if (id != site.MyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(site);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiteExists(site.MyId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(site);
        }

        // GET: Sites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.Site
                .FirstOrDefaultAsync(m => m.MyId == id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // POST: Sites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var site = await _context.Site.FindAsync(id);
            _context.Site.Remove(site);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiteExists(int id)
        {
            return _context.Site.Any(e => e.MyId == id);
        }

        //OKUL BİLGİLERİ


        public IActionResult OkulCreate()
        {
            return View();
        }

        // POST: Okuls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OkulCreate([Bind("okulId,okulAd,okulTarih,okulTur,okulInfo")] Okul okul)
        {
            if (ModelState.IsValid)
            {
                _context.Add(okul);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(okul);
        }
        // GET: Okuls/Details/5
        public async Task<IActionResult> OkulDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var okul = await _context.Okul
                .FirstOrDefaultAsync(m => m.okulId == id);
            if (okul == null)
            {
                return NotFound();
            }

            return View(okul);
        }

        // GET: Okuls/Create


        // GET: Okuls/Edit/5
        public async Task<IActionResult> OkulEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var okul = await _context.Okul.FindAsync(id);
            if (okul == null)
            {
                return NotFound();
            }
            return View(okul);
        }

        // POST: Okuls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OkulEdit(int id, [Bind("okulId,okulAd,okulTarih,okulTur,okulInfo")] Okul okul)
        {
            if (id != okul.okulId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(okul);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OkulExists(okul.okulId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(okul);
        }

        // GET: Okuls/Delete/5
        public async Task<IActionResult> OkulDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var okul = await _context.Okul
                .FirstOrDefaultAsync(m => m.okulId == id);
            if (okul == null)
            {
                return NotFound();
            }

            return View(okul);
        }

        // POST: Okuls/Delete/5
        [HttpPost, ActionName("OkulDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OkulDeleteConfirmed(int id)
        {
            var okul = await _context.Okul.FindAsync(id);
            _context.Okul.Remove(okul);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OkulExists(int id)
        {
            return _context.Okul.Any(e => e.okulId == id);
        }


        //SOSYAL MEDYA BİLGİLERİ



        // GET: Sosyals/Details/5
        public async Task<IActionResult> SosyalDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sosyal = await _context.Sosyal
                .FirstOrDefaultAsync(m => m.sosyalId == id);
            if (sosyal == null)
            {
                return NotFound();
            }

            return View(sosyal);
        }

        // GET: Sosyals/Create
        public IActionResult SosyalCreate()
        {
            return View();
        }

        // POST: Sosyals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SosyalCreate([Bind("sosyalId,sosyalUrl,sosyalTur,sosyalInfo,sosyalFooter")] Sosyal sosyal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sosyal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sosyal);
        }

        // GET: Sosyals/Edit/5
        public async Task<IActionResult> SosyalEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sosyal = await _context.Sosyal.FindAsync(id);
            if (sosyal == null)
            {
                return NotFound();
            }
            return View(sosyal);
        }

        // POST: Sosyals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SosyalEdit(int id, [Bind("sosyalId,sosyalUrl,sosyalTur,sosyalInfo,sosyalFooter")] Sosyal sosyal)
        {
            if (id != sosyal.sosyalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sosyal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SosyalExists(sosyal.sosyalId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sosyal);
        }

        // GET: Sosyals/Delete/5
        public async Task<IActionResult> SosyalDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sosyal = await _context.Sosyal
                .FirstOrDefaultAsync(m => m.sosyalId == id);
            if (sosyal == null)
            {
                return NotFound();
            }

            return View(sosyal);
        }

        // POST: Sosyals/Delete/5
        [HttpPost, ActionName("SosyalDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SosyalDeleteConfirmed(int id)
        {
            var sosyal = await _context.Sosyal.FindAsync(id);
            _context.Sosyal.Remove(sosyal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SosyalExists(int id)
        {
            return _context.Sosyal.Any(e => e.sosyalId == id);
        }

        //SLİDER BİLGİLERİ



        // GET: SliderFotoes/Details/5
        public async Task<IActionResult> SliderDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sliderFoto = await _context.SliderFoto
                .FirstOrDefaultAsync(m => m.sliderFotoId == id);
            if (sliderFoto == null)
            {
                return NotFound();
            }

            return View(sliderFoto);
        }

        // GET: SliderFotoes/Create
        public IActionResult SliderCreate()
        {
            return View();
        }

        // POST: SliderFotoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SliderCreate([Bind("sliderFotoId,fotoUrl,fotoBaslik,fotoAciklama")] SliderFoto sliderFoto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sliderFoto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sliderFoto);
        }

        // GET: SliderFotoes/Edit/5
        public async Task<IActionResult> SliderEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sliderFoto = await _context.SliderFoto.FindAsync(id);
            if (sliderFoto == null)
            {
                return NotFound();
            }
            return View(sliderFoto);
        }

        // POST: SliderFotoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SliderEdit(int id, [Bind("sliderFotoId,fotoUrl,fotoBaslik,fotoAciklama")] SliderFoto sliderFoto)
        {
            if (id != sliderFoto.sliderFotoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sliderFoto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SliderFotoExists(sliderFoto.sliderFotoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sliderFoto);
        }

        // GET: SliderFotoes/Delete/5
        public async Task<IActionResult> SliderDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sliderFoto = await _context.SliderFoto
                .FirstOrDefaultAsync(m => m.sliderFotoId == id);
            if (sliderFoto == null)
            {
                return NotFound();
            }

            return View(sliderFoto);
        }

        // POST: SliderFotoes/Delete/5
        [HttpPost, ActionName("SliderDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SliderDeleteConfirmed(int id)
        {
            var sliderFoto = await _context.SliderFoto.FindAsync(id);
            _context.SliderFoto.Remove(sliderFoto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SliderFotoExists(int id)
        {
            return _context.SliderFoto.Any(e => e.sliderFotoId == id);
        }

        //BECERİ BİLGİLERİ//

        // GET: Becerilers/Details/5
        public async Task<IActionResult> BeceriDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beceriler = await _context.Beceriler
                .FirstOrDefaultAsync(m => m.id == id);
            if (beceriler == null)
            {
                return NotFound();
            }

            return View(beceriler);
        }

        // GET: Becerilers/Create
        public IActionResult BeceriCreate()
        {
            return View();
        }

        // POST: Becerilers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BeceriCreate([Bind("id,beceri,aciklama")] Beceriler beceriler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beceriler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(beceriler);
        }

        // GET: Becerilers/Edit/5
        public async Task<IActionResult> BeceriEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beceriler = await _context.Beceriler.FindAsync(id);
            if (beceriler == null)
            {
                return NotFound();
            }
            return View(beceriler);
        }

        // POST: Becerilers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BeceriEdit(int id, [Bind("id,beceri,aciklama")] Beceriler beceriler)
        {
            if (id != beceriler.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beceriler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BecerilerExists(beceriler.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(beceriler);
        }

        // GET: Becerilers/Delete/5
        public async Task<IActionResult> BeceriDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beceriler = await _context.Beceriler
                .FirstOrDefaultAsync(m => m.id == id);
            if (beceriler == null)
            {
                return NotFound();
            }

            return View(beceriler);
        }

        // POST: Becerilers/Delete/5
        [HttpPost, ActionName("BeceriDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BeceriDeleteConfirmed(int id)
        {
            var beceriler = await _context.Beceriler.FindAsync(id);
            _context.Beceriler.Remove(beceriler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BecerilerExists(int id)
        {
            return _context.Beceriler.Any(e => e.id == id);
        }



        //BLOG BİLGİLERİ//


        // GET: Blogs
        public async Task<IActionResult> Blog()
        {
            return View(await _context.Blog.ToListAsync());
        }

        // GET: Blogs/Details/5
        public async Task<IActionResult> BlogDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog
                .FirstOrDefaultAsync(m => m.id == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // GET: Blogs/Create
        public IActionResult BlogCreate()
        {
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BlogCreate([Bind("id,idName,blogTur,baslik,altBaslik,aciklama,fotoUrl,eklemeTarihi,degistirmeTarihi,surum,boyut")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Blog));
            }
            return View(blog);
        }

        // GET: Blogs/Edit/5
        public async Task<IActionResult> BlogEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BlogEdit(int id, [Bind("id,idName,blogTur,baslik,altBaslik,aciklama,fotoUrl,eklemeTarihi,degistirmeTarihi,surum,boyut")] Blog blog)
        {
            if (id != blog.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(blog.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Blog));
            }
            return View(blog);
        }

        // GET: Blogs/Delete/5
        public async Task<IActionResult> BlogDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog
                .FirstOrDefaultAsync(m => m.id == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("BlogDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BlogDeleteConfirmed(int id)
        {
            var blog = await _context.Blog.FindAsync(id);
            _context.Blog.Remove(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Blog));
        }

        private bool BlogExists(int id)
        {
            return _context.Blog.Any(e => e.id == id);
        }


        //İÇERİK BİLGİLERİ//



        // GET: Iceriks
        public async Task<IActionResult> Icerik()
        {
            var veriContext = _context.Icerik.Include(i => i.Blog);
            return View(await veriContext.ToListAsync());
        }

        // GET: Iceriks/Details/5
        public async Task<IActionResult> IcerikDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var icerik = await _context.Icerik
                .Include(i => i.Blog)
                .FirstOrDefaultAsync(m => m.icerikId == id);
            if (icerik == null)
            {
                return NotFound();
            }

            return View(icerik);
        }

        // GET: Iceriks/Create
        public IActionResult IcerikCreate()
        {
            ViewData["blogId"] = new SelectList(_context.Blog, "id", "id");
            return View();
        }

        // POST: Iceriks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IcerikCreate([Bind("icerikId,idTag,baslik,aciklama,eklemeTarihi,blogId")] Icerik icerik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(icerik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Icerik));
            }
            ViewData["blogId"] = new SelectList(_context.Blog, "id", "id", icerik.blogId);
            return View(icerik);
        }

        // GET: Iceriks/Edit/5
        public async Task<IActionResult> IcerikEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var icerik = await _context.Icerik.FindAsync(id);
            if (icerik == null)
            {
                return NotFound();
            }
            ViewData["blogId"] = new SelectList(_context.Blog, "id", "id", icerik.blogId);
            return View(icerik);
        }

        // POST: Iceriks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IcerikEdit(int id, [Bind("icerikId,idTag,baslik,aciklama,eklemeTarihi,blogId")] Icerik icerik)
        {
            if (id != icerik.icerikId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(icerik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IcerikExists(icerik.icerikId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Icerik));
            }
            ViewData["blogId"] = new SelectList(_context.Blog, "id", "id", icerik.blogId);
            return View(icerik);
        }

        // GET: Iceriks/Delete/5
        public async Task<IActionResult> IcerikDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var icerik = await _context.Icerik
                .Include(i => i.Blog)
                .FirstOrDefaultAsync(m => m.icerikId == id);
            if (icerik == null)
            {
                return NotFound();
            }

            return View(icerik);
        }

        // POST: Iceriks/Delete/5
        [HttpPost, ActionName("IcerikDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IcerikDeleteConfirmed(int id)
        {
            var icerik = await _context.Icerik.FindAsync(id);
            _context.Icerik.Remove(icerik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Icerik));
        }

        private bool IcerikExists(int id)
        {
            return _context.Icerik.Any(e => e.icerikId == id);
        }


        //YORUMLAR//



        // GET: Yorums
        public async Task<IActionResult> Yorum()
        {
            var veriContext = _context.Yorum.Include(y => y.Blog).Include(y => y.User);
            return View(await veriContext.ToListAsync());
        }

        // GET: Yorums/Details/5
        public async Task<IActionResult> YorumDetails(int? id)
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

        // GET: Yorums/Delete/5
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

        // POST: Yorums/Delete/5
        [HttpPost, ActionName("YorumDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YorumDeleteConfirmed(int id)
        {
            var yorum = await _context.Yorum.FindAsync(id);
            _context.Yorum.Remove(yorum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Yorum));
        }

        // GET: Yorums/Edit/5
        public async Task<IActionResult> YorumOnayla(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorum = await _context.Yorum.FindAsync(id);
            if (yorum == null)
            {
                return NotFound();
            }
            ViewData["blogId"] = new SelectList(_context.Blog, "id", "id", yorum.blogId);
            ViewData["userId"] = new SelectList(_context.User, "Id", "Id", yorum.userId);
            return View(yorum);
        }

        // POST: Yorums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YorumOnayla(int id, [Bind("id,icerik,onay,userId,blogId")] Yorum yorum)
        {
            if (id != yorum.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yorum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YorumExists(yorum.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Yorum));
            }
            ViewData["blogId"] = new SelectList(_context.Blog, "id", "id", yorum.blogId);
            ViewData["userId"] = new SelectList(_context.User, "Id", "Id", yorum.userId);
            return View(yorum);
        }

        private bool YorumExists(int id)
        {
            return _context.Yorum.Any(e => e.id == id);
        }



        //USER İŞLEMLERİ//



        public IActionResult UserBan()
        {
            ViewData["userId"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: Bans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserBan([Bind("id,durum,banTarihi,userId")] Ban ban)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ban);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Ban));
            }
            ViewData["userId"] = new SelectList(_context.User, "Id", "Id", ban.userId);
            return View(ban);
        }

        public async Task<IActionResult> UserUnban(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ban = await _context.Ban.FindAsync(id);
            if (ban == null)
            {
                return NotFound();
            }
            ViewData["userId"] = new SelectList(_context.User, "Id", "Id", ban.userId);
            return View(ban);
        }

        // POST: Bans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserUnban(int id, [Bind("id,durum,banTarihi,userId")] Ban ban)
        {
            if (id != ban.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ban);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BanExists(ban.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Ban));
            }
            ViewData["userId"] = new SelectList(_context.User, "Id", "Id", ban.userId);
            return View(ban);
        }

        public async Task<IActionResult> Ban()
        {
            var veriContext = _context.Ban.Include(b => b.User);
            return View(await veriContext.ToListAsync());
        }



        // GET: Bans/Delete/5
        public async Task<IActionResult> BanDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ban = await _context.Ban
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.id == id);
            if (ban == null)
            {
                return NotFound();
            }

            return View(ban);
        }

        // POST: Bans/Delete/5
        [HttpPost, ActionName("BanDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BanDeleteConfirmed(int id)
        {
            var ban = await _context.Ban.FindAsync(id);
            _context.Ban.Remove(ban);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Ban));
        }

        private bool BanExists(int id)
        {
            return _context.Ban.Any(e => e.id == id);
        }


        // GET: Users
        public IActionResult Users()
        {
            var user = _context.User.ToList();
            var ban = _context.Ban.ToList();
            var Class = new Alldata();
            Class.User = user;
            Class.Ban = ban;
            return View(Class);
        }


        //EKLENEN İŞLEMLERİ//



        // GET: Eklenenlers
        public async Task<IActionResult> Eklenenler()
        {
            return View(await _context.Eklenenler.ToListAsync());
        }

        // GET: Eklenenlers/Details/5
        public async Task<IActionResult> EklenenDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eklenenler = await _context.Eklenenler
                .FirstOrDefaultAsync(m => m.id == id);
            if (eklenenler == null)
            {
                return NotFound();
            }

            return View(eklenenler);
        }

        // GET: Eklenenlers/Create
        public IActionResult EklenenCreate()
        {
            return View();
        }

        // POST: Eklenenlers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EklenenCreate([Bind("id,idName,baslik,tarih")] Eklenenler eklenenler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eklenenler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Eklenenler));
            }
            return View(eklenenler);
        }

        // GET: Eklenenlers/Edit/5
        public async Task<IActionResult> EklenenEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eklenenler = await _context.Eklenenler.FindAsync(id);
            if (eklenenler == null)
            {
                return NotFound();
            }
            return View(eklenenler);
        }

        // POST: Eklenenlers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EklenenEdit(int id, [Bind("id,idName,baslik,tarih")] Eklenenler eklenenler)
        {
            if (id != eklenenler.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eklenenler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EklenenlerExists(eklenenler.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Eklenenler));
            }
            return View(eklenenler);
        }

        // GET: Eklenenlers/Delete/5
        public async Task<IActionResult> EklenenDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eklenenler = await _context.Eklenenler
                .FirstOrDefaultAsync(m => m.id == id);
            if (eklenenler == null)
            {
                return NotFound();
            }

            return View(eklenenler);
        }

        // POST: Eklenenlers/Delete/5
        [HttpPost, ActionName("EklenenDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EklenenDeleteConfirmed(int id)
        {
            var eklenenler = await _context.Eklenenler.FindAsync(id);
            _context.Eklenenler.Remove(eklenenler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Eklenenler));
        }

        private bool EklenenlerExists(int id)
        {
            return _context.Eklenenler.Any(e => e.id == id);
        }
    }
}
