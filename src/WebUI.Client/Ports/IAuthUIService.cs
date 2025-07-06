namespace WebUI.Client.Ports;

public interface IAuthUIService
{
    Task<bool> IsUserAuthenticatedAsync();
}
