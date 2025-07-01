using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.Ports.Input;

namespace WebUI.Server.Controllers;

[Authorize]
public sealed class AddressesController(
    IAddressService addressService) : ControllerTemplate
{
    private readonly IAddressService addressService = addressService;

    [HttpGet]
    public async Task<ActionResult<Address>> GetAddress() =>
        HandleGenericResult(await addressService.GetAddressAsync());

    [HttpPost]
    public async Task<ActionResult<Address>> AddOrUpdateAddress(Address request) =>
        HandleResult(await addressService.UpdateOrCreateAddressAsync(request));
}
