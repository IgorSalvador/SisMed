using Microsoft.AspNetCore.Mvc;
using SisMed.Models.Contexts;
using SisMed.Models.Entities;
using SisMed.Models.ViewModels.Medicos;

namespace SisMed.Controllers
{
    public class MedicosController : Controller
    {
        private readonly SisMedContext _context;
        private const int TAMANHO_PAGINA = 10;

        public MedicosController(SisMedContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index(string filtro, int pagina = 1)
        {
            List<ListarMedicoViewModel> medicos = new List<ListarMedicoViewModel>();

            if(filtro == null)
            {
                medicos = _context.Medicos.Select(x => new ListarMedicoViewModel
                {
                    Id = x.Id,
                    CRM = x.CRM,
                    Nome = x.Nome,
                    IsActive = x.IsActive
                }).ToList();
            }
            else
            {
                medicos = _context.Medicos.Where(x => x.Nome.Contains(filtro) || x.CRM.Contains(filtro)).Select(x => new ListarMedicoViewModel
                {
                    Id = x.Id,
                    CRM = x.CRM,
                    Nome = x.Nome,
                    IsActive = x.IsActive
                }).ToList();
            }

            ViewBag.Filtro = filtro ?? string.Empty;
            ViewBag.NumeroPagina = pagina;
            ViewBag.TotalPaginas = Math.Ceiling((decimal)medicos.Count() / TAMANHO_PAGINA);

            return View(medicos.Skip((pagina - 1) * TAMANHO_PAGINA).Take(TAMANHO_PAGINA));
        }
    }
}
