using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.Ports.Input;
using Domain.Models;

namespace WebUI.Server.Controllers;

[Authorize]
public sealed class SeriesController(
    ISeriesService seriesService) : ControllerTemplate
{
    [HttpGet]
    public async Task<ActionResult<List<Series>>> GetSeriesAsync() =>
        HandleGenericResult(await seriesService.GetSeriesAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Series>> GetSeriesByIdAsync(int id) =>
        HandleGenericResult(await seriesService.GetSeriesByIdAsync(id));

    [HttpPost]
    public async Task<ActionResult<Series>> CreateSeriesAsync(Series series) =>
        HandleResult(await seriesService.CreateSeriesAsync(series));

    [HttpPut]
    public async Task<ActionResult<Series>> UpdateSeriesAsync(Series series) =>
        HandleResult(await seriesService.UpdateSeriesAsync(series));

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteSeriesByIdAsync(int id) =>
        HandleResult(await seriesService.DeleteSeriesByIdAsync(id));
}
