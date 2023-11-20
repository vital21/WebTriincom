using Microsoft.AspNetCore.Mvc;
using WebTriinkom.Models;
using Microsoft.EntityFrameworkCore;

namespace WebTriinkom.Controllers
{
    public class RegistrationController : Controller
    {
        readonly ApplicationContext db;
        
        public RegistrationController(ApplicationContext context)
        {
            db = context;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
           
                db.Users.Add(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
        
        }
        public async Task<IActionResult> Index()
        {
            var users = await db.Users.ToListAsync();
            return View(users);
        }

    }
}
