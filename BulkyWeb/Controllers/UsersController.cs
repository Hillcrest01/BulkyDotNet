using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BulkyWeb.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDBContext _db;

        public UsersController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Users> portalUsers = _db.PortalUsers.ToList();
            return View(portalUsers);
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Users obj)
        {
            if(obj.Email.ToLower() != null && obj.Email == obj.Password)
            {
                ModelState.AddModelError("", "Password cannot be same as the email address");
            }
            if (_db.PortalUsers.Any(x => x.Email == obj.Email))
            {
                ModelState.AddModelError("Email", "A user with this email address already exist");
            }

            if (ModelState.IsValid)
            {            
                _db.PortalUsers.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Users");
            }
            return View();
        }
        public IActionResult Edit(string email)
        {
            if(email == null || email == "")
            {
                return NotFound();
            }
            Users? userToEdit = _db.PortalUsers.Find(email);

            if(userToEdit == null)
            {
                return NotFound();
            }
            return View(userToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Users obj)
        {
            if (ModelState.IsValid)
            {
                _db.PortalUsers.Update(obj);
                _db.SaveChanges();
                RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string email)
        {
            if(email == null || email == "")
            {
                return NotFound();
            }
            Users? userToDelete = _db.PortalUsers.Find(email);
            if(userToDelete == null)
            {
                return NotFound();
            }
            return View(userToDelete);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(string email)
        {
            if(email == null || email == "")
            {
                return NotFound();
            }
            Users userToDelete = _db.PortalUsers.Find(email);
            _db.PortalUsers.Remove(userToDelete);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
