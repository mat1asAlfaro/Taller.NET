using Microsoft.AspNetCore.SignalR;
using tarea3a.Models;

namespace tarea3a.Hubs
{
  public class AuthHub : Hub
  {
    private readonly ILogger<AuthHub> _logger;

    public AuthHub(ILogger<AuthHub> logger)
    {
      _logger = logger;
    }

    public void Register(String first_name, String last_name, String email, String password)
    {
      _logger.LogInformation("SignalR user identification: " + Context.ConnectionId);

      User user = new User(first_name, last_name, email, password);

      if (user.ValidUser())
      {
        if (user.NeedVerification())
        {
          string userId = Context.ConnectionId;
          _logger.LogInformation($"URL VERIFICATION: https://localhost:7090/verify/user/{userId}");
        }
      }
    }

    public void SendVerificationOk()
    {
      if (Context.UserIdentifier is not null)
      {
        Clients.User(Context.UserIdentifier).SendAsync("VerificationOk", "");
      }
    }
  }
}