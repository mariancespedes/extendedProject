using Microsoft.AspNetCore.Mvc;
using WebExtended.DAL;

namespace WebExtended.Controllers
{
    public class EventoController : Controller
    {
        private readonly ExtendedwebContext _DbContext;
        public EventoController(ExtendedwebContext _context)
        {
            _DbContext = _context;
        }
        public IActionResult Index()
        {
            List<Evento> lista= _DbContext.Eventos.ToList();
            return View(lista);
        }
        [HttpGet]
        public IActionResult Eventos(int idEvento)
        {
            Evento _evento= new Evento();
            if (idEvento != 0)
            {
                _evento = _DbContext.Eventos.Find(idEvento);
            }
            return View(_evento);
        }
        [HttpPost]
        public IActionResult Eventos(Evento modelEvento)
        {
            if (modelEvento.IdEvento==0)
            {
                _DbContext.Eventos.Add(modelEvento);
            }
            else
            {
                _DbContext.Eventos.Update(modelEvento);
            }
            _DbContext.SaveChanges();
                return RedirectToAction("Index","Evento");
        }
    }
}
