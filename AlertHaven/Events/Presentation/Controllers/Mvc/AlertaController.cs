using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Events.Domain.Models;
using Events.Application.Interfaces;

namespace Events.Presentation.Controllers.MVC;

public class AlertaController : Controller
{
    private readonly IAlertaService _service;

    public AlertaController(IAlertaService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        var alertas = _service.ObterTodosOsAlertas();

        return View(alertas);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
