namespace HospitalManagmentSystem.API.Middleware
{
    public class LoggingMiddelware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddelware> _logger;

        public LoggingMiddelware( RequestDelegate next, ILogger<LoggingMiddelware> logger)
        {
           _next = next;
            _logger = logger;
        }

        public async Task  InvokeAsync(HttpContext context)
        { 
         _next.Invoke(context);
            _logger.LogWarning("Logging Middleware Ended");
        }
    }
}
