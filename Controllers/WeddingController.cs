using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WeddingPlanner.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers
{
    public class WeddingController : Controller
    {
        private UserContext _context;

        public WeddingController(UserContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [Route("List")]
        public IActionResult List()
        {
            List<Wedding> weddings = _context.Weddings
                                        .Include(wed => wed.Guest)
                                        .ToList();
            ViewBag.weddings = weddings; 

            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            System.Console.WriteLine("leaving LISSSSSTTTT ******");
            return View("Index");
        }
        [HttpGet]
        [Route("addwedding")]
        public IActionResult AddDisplay(){
            return View("add");
        }
        [HttpPost]
        [Route("add")]
        public IActionResult Add(Wedding wedding){
            int UserId = (int)HttpContext.Session.GetInt32("UserId");
            wedding.CreatedAt = DateTime.Now;
            wedding.UpdatedAt = DateTime.Now;
            wedding.UserId = UserId;
            _context.Add(wedding);
            _context.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        [Route("delete/{WeddingId}")]
        public IActionResult Delete(int WeddingId){
            Wedding DelWed = _context.Weddings.SingleOrDefault(wedd => wedd.WeddingId == WeddingId);
            _context.Weddings.Remove(DelWed);
            _context.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        [Route("rsvp/{WeddingId}")]
        public IActionResult RSVP(int WeddingId){
            Guest newGuest = new Guest();
            newGuest.UserId = (int)HttpContext.Session.GetInt32("UserId");
            newGuest.WeddingId = WeddingId;
            _context.Add(newGuest);
            _context.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        [Route("unrsvp/{WeddingId}")]
        public IActionResult UnRSVP(int WeddingId){
            int UserId = (int)HttpContext.Session.GetInt32("UserId");
            Guest delguest = _context.Guests.SingleOrDefault(g => g.UserId == UserId && g.WeddingId == WeddingId);
            System.Console.WriteLine(delguest + "************************************************************************************************************************************");
            _context.Guests.Remove(delguest);
            _context.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        [Route("weddings/{WeddingId}")]
        public IActionResult Show(int WeddingId){
            List<Wedding> weddings = _context.Weddings.Where(w => w.WeddingId == WeddingId)
                                    .Include(wed => wed.Guest)
                                        .ThenInclude(g => g.User)
                                    .ToList();
            ViewBag.wedding = weddings[0];
            return View();
        }
        [HttpGet]
        [Route("maptest")]
        public IActionResult maptest(){
            return View();
        }
    }
}