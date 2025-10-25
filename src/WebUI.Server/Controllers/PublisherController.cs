using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.Ports.Input;

namespace WebUI.Server.Controllers;

[Authorize]
public sealed class PublisherController(
    IPublisherService publisherService) : ControllerTemplate
{
    [HttpGet("{id}")]
    public async Task<ActionResult<DbUser>> GetPublisherByIdAsync(string id) =>
        HandleGenericResult(await publisherService.GetPublisherByIdAsync(id));

    [HttpPost]
    public async Task<ActionResult<DbUser>> CreatePublisherAsync(DbUser publisher) =>
        HandleResult(await publisherService.CreatePublisherAsync(publisher));

    [HttpPut]
    public async Task<ActionResult<DbUser>> UpdatePublisherAsync(DbUser publisher) =>
        HandleResult(await publisherService.UpdatePublisherAsync(publisher));

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePublisherByIdAsync(string id) =>
        HandleResult(await publisherService.DeletePublisherByIdAsync(id));
}
