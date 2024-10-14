using Microsoft.AspNetCore.Mvc;
using SpendSmart.Models;
using System.Diagnostics;

namespace SpendSmart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SpendSmartDbContext _context;

        public HomeController(ILogger<HomeController> logger, SpendSmartDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Depenses()
        {
            var allDepenses = _context.Depenses.ToList();
            var totalDepenses = allDepenses.Sum(x => x.Prix);
            ViewBag.Depenses = totalDepenses;
            return View(allDepenses);
        }
        public IActionResult CreateEditDepense(int? id)
        {
            if (id!=null)
            {
                var depenseDB = _context.Depenses.SingleOrDefault(depense => depense.Id == id);
                return View(depenseDB);
            }
            return View();
        }
        public IActionResult DeleteDepense(int id)
        {
            var depenseDB = _context.Depenses.SingleOrDefault(depense=> depense.Id == id);
            _context.Depenses.Remove(depenseDB);
            _context.SaveChanges();
            return RedirectToAction("Depenses");
        }
        public IActionResult CreateEditDepenseForm(Depense model)
        {
            if (model.Id == 0)
            {
                _context.Depenses.Add(model);
            }else
            {
                _context.Depenses.Update(model);
            }
            _context.SaveChanges();
            return RedirectToAction("Depenses");

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
