using DentAssist.Models;
using DentAssist.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DentAssist.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context; // Inyectar el contexto

        public HomeController(
            ILogger<HomeController> logger,
            AppDbContext context) // Añadir como dependencia
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index() // Cambiar a async
        {
            var vm = new DashboardViewModel
            {
                PacientesCount = await _context.Pacientes.CountAsync(),
                OdontologosCount = await _context.Odontologos.CountAsync(),
                TurnosCount = await _context.Turnos.CountAsync(),
                PlanesCount = await _context.PlanesTratamiento.CountAsync()
            };
            return View("Dashboard", vm); // Pasar el modelo
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
