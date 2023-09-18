using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Multicars.Data;
using Multicars.Models.BD;
using Multicars.Models;

namespace Multicars.Controllers
{
    public class HomeController : Controller
    {

        public ApplicationDbContext db;
        public HomeController(ApplicationDbContext Db)
        {
            db = Db;
        }
        private readonly ILogger<HomeController> _logger;

        //LOGIN
        [HttpPost]
        public async Task<IActionResult> Register(Login model)
        {
            if (ModelState.IsValid)
            {
                db.login.Add(model);
                await db.SaveChangesAsync();
                await Response.WriteAsync("<script language='javascript'> alert('Sucessfull register!'); window.location.href='';</script>");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}