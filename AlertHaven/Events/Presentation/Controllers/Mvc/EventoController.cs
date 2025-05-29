using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Events.Domain.Models;
using Events.Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoMapper;
using Events.Domain.Entities;
using Events.Application.Dto.Evento;

namespace Events.Presentation.Controllers.MVC;

public class EventoController : Controller
{
    private readonly IEventoService _service;
    private readonly IMapper _mapper;

    public EventoController(IEventoService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        var eventos = _service.ObterTodosOsEventos();

        return View(eventos);
    }

    public IActionResult Details(string? id)
    {
        var evento = _service.ObterEventoPorId(id ?? "");

        return View(evento);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Intensidades = ObterIntensidadeEventos();
        ViewBag.Tipos = ObterTiposEventos();

        return View();
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Create(PersistirEventoInputDTO dto)
    {
        if (ModelState.IsValid)
        { 
            _service.PersistirEvento(_mapper.Map<PersistirEventoInputDTO, EventoEntity>(dto));

            return RedirectToAction(nameof(Index));
        }
        return View(dto);
    }

    [HttpGet]
    public IActionResult Edit(string? id)
    {
        var iot = _service.ObterEventoPorId(id ?? "");

        ViewBag.Intensidades = ObterIntensidadeEventos();
        ViewBag.Tipos = ObterTiposEventos();

        return View(iot);
    }


    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Edit(EventoEntity entity)
    {
        if (ModelState.IsValid)
        {
            _service.AtualizarEvento(entity, entity.IdEvento);

            return RedirectToAction(nameof(Index));
        }
        return View();
    }


    [HttpGet]
    public IActionResult Delete(string? id)
    {
        var evento = _service.ObterEventoPorId(id ?? "");

        return View(evento);
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    [ActionName("Delete")]
    public IActionResult DeleteConfirmed(string id)
    {
        var evento = _service.DeletarEvento(id);

        if (evento is not null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View();
    }


    private IEnumerable<SelectListItem> ObterTiposEventos()
    {
        var listaTipos = new List<SelectListItem>
        {
            new SelectListItem("ALAGAMENTO", "ALAGAMENTO"),
            new SelectListItem("TEMPESTADE", "TEMPESTADE"),
            new SelectListItem("TORNADO", "TORNADO"),
            new SelectListItem("ONDA_DE_CALOR", "ONDA_DE_CALOR"),
            new SelectListItem("TERREMOTO", "TERREMOTO")
        };

        return listaTipos;
    }

    private IEnumerable<SelectListItem> ObterIntensidadeEventos()
    {
        var listaUnidades = new List<SelectListItem>
        {
            new SelectListItem("BAIXO", "BAIXO"),
            new SelectListItem("MEDIO", "MEDIO"),
            new SelectListItem("ALTO", "ALTO"),
            new SelectListItem("CRITICO", "CRITICO")
        };

        return listaUnidades;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
