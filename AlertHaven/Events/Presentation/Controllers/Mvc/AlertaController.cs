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
            _service.PersistirAlerta(_mapper.Map<AlertaEntity>(dto));

            return RedirectToAction(nameof(Index));
        }
        return View(dto);
    }

    [HttpGet]
    public IActionResult Edit(string? id)
    {
        var alerta = _service.ObterAlertaPorId(id ?? "");

        ViewBag.Niveis = ObterNiveisAlerta();

        return View(alerta);
    }


    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Edit(AtualizarAlertaInputDTO dto)
    {
        if (ModelState.IsValid)
        {
            var entity = _mapper.Map<AlertaEntity>(dto);
            _service.AtualizarAlerta(entity, entity.IdAlerta);

            return RedirectToAction(nameof(Index));
        }
        return View(dto);
    }


    [HttpGet]
    public IActionResult Delete(string? id)
    {
        var alerta = _service.ObterAlertaPorId(id ?? "");

        return View(alerta);
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    [ActionName("Delete")]
    public IActionResult DeleteConfirmed(string id)
    {
        var clientes = _service.DeletarAlerta(id);

        if (clientes is not null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View();
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
