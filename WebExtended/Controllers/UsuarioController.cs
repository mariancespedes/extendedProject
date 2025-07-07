using Microsoft.AspNetCore.Mvc;
using WebExtended.DAL;

namespace WebExtended.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ExtendedwebContext _DbContext;
        public UsuarioController(ExtendedwebContext _context)
        {
            _DbContext = _context;
        }
        public IActionResult Index()
        {
            List<Usuario> lista = new List<Usuario>();
            return View(lista);
        }
    }
}
