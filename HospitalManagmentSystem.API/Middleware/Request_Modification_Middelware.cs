namespace HospitalManagmentSystem.API.Middleware
{
    public class Request_Modification_Middelware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<Request_Modification_Middelware> _logger;

        public Request_Modification_Middelware(RequestDelegate next ,ILogger<Request_Modification_Middelware> logger)
        {
          _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            _next.Invoke(context);
            _logger.LogWarning("Request_Modification Middleware Ended");
        }
    }
}
