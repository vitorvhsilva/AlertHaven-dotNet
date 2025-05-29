using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Events.Domain.Models;
using Events.Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Events.Application.Dto.Alerta;
using AutoMapper;
using Events.Domain.Entities;

namespace Events.Presentation.Controllers.MVC;

public class AlertaController : Controller
{
    private readonly IAlertaService _service;
    private readonly IMapper _mapper;

    public AlertaController(IAlertaService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        var alertas = _service.ObterTodosOsAlertas();

        return View(alertas);
    }

    public IActionResult Details(string? id)
    {
        var alerta = _service.ObterAlertaPorId(id ?? "");

        return View(alerta);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Niveis = ObterNiveisAlerta();

        return View();
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Create(PersistirAlertaInputDTO dto)
    {
        if (ModelState.IsValid)
        {
            //Salva os dados no banco

            _service.PersistirAlerta(_mapper.Map<AlertaEntity>(dto));

            return RedirectToAction(nameof(Index));
        }
        return View(dto);
    }



    private IEnumerable<SelectListItem> ObterNiveisAlerta()
    {
        var listaNiveis = new List<SelectListItem>
        {
            new SelectListItem("BAIXO", "BAIXO"),
            new SelectListItem("MEDIO", "MEDIO"),
            new SelectListItem("ALTO", "ALTO"),
            new SelectListItem("CRITICO", "CRITICO")
        };

        return listaNiveis;

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
