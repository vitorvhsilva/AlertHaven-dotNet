using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Events.Domain.Models;
using Events.Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Events.Application.Dto.Alerta;
using AutoMapper;
using Events.Domain.Entities;
using Events.Application.Dto.Iot;

namespace Events.Presentation.Controllers.MVC;

public class IotController : Controller
{
    private readonly IIotService _service;
    private readonly IMapper _mapper;

    public IotController(IIotService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        var iots = _service.ObterTodosOsIots();

        return View(iots);
    }

    public IActionResult Details(string? id)
    {
        var iot = _service.ObterIotPorId(id ?? "");

        return View(iot);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Tipos = ObterTiposIots();
        ViewBag.UnidadesMedidas = ObterUnidadeMedidas();
        ViewBag.Status = ObterStatusIot();

        return View();
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Create(PersistirIotInputDTO dto)
    {
        if (ModelState.IsValid)
        { 
            _service.PersistirIot(_mapper.Map<PersistirIotInputDTO, IotEntity>(dto));

            return RedirectToAction(nameof(Index));
        }
        return View(dto);
    }

    [HttpGet]
    public IActionResult Edit(string? id)
    {
        var iot = _service.ObterIotPorId(id ?? "");

        ViewBag.Tipos = ObterTiposIots();
        ViewBag.UnidadesMedidas = ObterUnidadeMedidas();
        ViewBag.Status = ObterStatusIot();

        return View(iot);
    }


    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Edit(IotEntity entity)
    {
        if (ModelState.IsValid)
        {
            _service.AtualizarIot(entity, entity.IdIot);

            return RedirectToAction(nameof(Index));
        }
        return View();
    }


    [HttpGet]
    public IActionResult Delete(string? id)
    {
        var iot = _service.ObterIotPorId(id ?? "");

        return View(iot);
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    [ActionName("Delete")]
    public IActionResult DeleteConfirmed(string id)
    {
        var iot = _service.DeletarIot(id);

        if (iot is not null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View();
    }


    private IEnumerable<SelectListItem> ObterTiposIots()
    {
        var listaTipos = new List<SelectListItem>
        {
            new SelectListItem("SENSOR_NIVEL_DE_AGUA", "SENSOR_NIVEL_DE_AGUA"),
            new SelectListItem("ANENOMETRO", "ANENOMETRO"),
            new SelectListItem("SISMOGRAFO", "SISMOGRAFO"),
            new SelectListItem("SENSOR_TEMPERATURA", "SENSOR_TEMPERATURA")
        };

        return listaTipos;
    }

    private IEnumerable<SelectListItem> ObterUnidadeMedidas()
    {
        var listaUnidades = new List<SelectListItem>
        {
            new SelectListItem("METROS", "METROS"),
            new SelectListItem("KM", "KM"),
            new SelectListItem("RICHTER", "RICHTER"),
            new SelectListItem("CELSIUS", "CELSIUS")
        };

        return listaUnidades;
    }

    private IEnumerable<SelectListItem> ObterStatusIot()
    {
        var status = new List<SelectListItem>
        {
            new SelectListItem("ATIVO", "ATIVO"),
            new SelectListItem("INATIVO", "INATIVO")
        };

        return status;

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
