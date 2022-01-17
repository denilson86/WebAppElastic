using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppElastic.Models;
using Serilog;
using Serilog.Context;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace WebAppElastic.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly ILogger<LoggerService> _logger;

        public LoggerService(ILogger<LoggerService> logger)
        {
            _logger = logger;
        }


        public async Task<string> LogInformation(LoggerRequest request)
        {
            var date = DateTime.UtcNow;
            using (LogContext.PushProperty("ApplicationName", request.ApplicationName))
            using (LogContext.PushProperty("LogMessage", request.LogMessage))
            using (LogContext.PushProperty("Date", date))
            {
                await Task.Run(() => _logger.LogInformation($"Log Level: Information ApplicationName:{request.ApplicationName} LogMessage: {request.LogMessage} Date: {date}"));
            }

            return JsonConvert.SerializeObject(new
            {
                Log_Level_Information = new { ApplicationName = @Assembly.GetEntryAssembly().GetName().Name, LogMessage = request.LogMessage, Date = date.ToString() }
            });
        }

        public async Task<string> LogWarning(LoggerRequest request)
        {
            var date = DateTime.UtcNow;
            using (LogContext.PushProperty("ApplicationName", request.ApplicationName))
            using (LogContext.PushProperty("LogMessage", request.LogMessage))
            using (LogContext.PushProperty("Date", date))
            {
                await Task.Run(() => _logger.LogInformation($"Log Level: Warning ApplicationName:{request.ApplicationName} LogMessage: {request.LogMessage} Date: {date}"));
            }

            return JsonConvert.SerializeObject(new
            {
                Log_Level_Warning = new { ApplicationName = @Assembly.GetEntryAssembly().GetName().Name, LogMessage = request.LogMessage, Date = date.ToString() }
            });
        }

        public async Task<string> LogError(LoggerRequest request)
        {
            var date = DateTime.UtcNow;
            using (LogContext.PushProperty("ApplicationName", request.ApplicationName))
            using (LogContext.PushProperty("LogMessage", request.LogMessage))
            using (LogContext.PushProperty("InnerMessage", request.InnerMessage))
            using (LogContext.PushProperty("Stacktrace", request.Stacktrace))
            using (LogContext.PushProperty("Date", date))
            {
                await Task.Run(() => _logger.LogInformation($"Log Level: Error ApplicationName:{request.ApplicationName} LogMessage: {request.LogMessage} Date: {date}" +
                    $"InnerMessage: {request.InnerMessage} Stacktrace: {request.Stacktrace}"));
            }

            return JsonConvert.SerializeObject(new
            {
                Log_Level_Error = new { ApplicationName = @Assembly.GetEntryAssembly().GetName().Name, LogMessage = request.LogMessage, Date = date.ToString(),
                    InnerMessage = request.InnerMessage, Stacktrace = request.Stacktrace
                }
            });
        }
    }
}
