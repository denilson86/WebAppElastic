using System;

namespace WebAppElastic.Models
{
    public class LoggerRequest
    {
        public string ApplicationName { get; set; }
        public string LogMessage { get; set; }
        public string InnerMessage { get; set; }
        public string Stacktrace { get; set; }
    }
}
