using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppElastic.Models;
using WebAppElastic.Services;

namespace WebAppElastic.Controllers
{
    [Route("/v1/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoggerService _loggerService;

        public LoginController(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        /// <summary>
        /// Log Information register
        /// </summary>
        /// <param name="logInformation"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("info/")]
        public async Task<IActionResult> LoInformation([FromBody] LoggerRequest logInformation)
        {

            if (logInformation == null)
                return BadRequest();

            return Ok($"{await _loggerService.LogInformation(logInformation)}");
        }

        /// <summary>
        /// Log Warning register
        /// </summary>
        /// <param name="logWarning"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("warning/")]
        public async Task<IActionResult> LogWarning([FromBody] LoggerRequest logWarning)
        {

            if (logWarning == null)
                return BadRequest();

            return Ok($"{await _loggerService.LogWarning(logWarning)}");
        }

        /// <summary>
        /// Log Error register
        /// </summary>
        /// <param name="logError"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("error/")]
        public async Task<IActionResult> LogError([FromBody] LoggerRequest logError)
        {

            if (logError == null)
                return BadRequest();

            return Ok($"{await _loggerService.LogWarning(logError)}");
        }
    }
}
