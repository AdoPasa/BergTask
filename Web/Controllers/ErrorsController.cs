using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ErrorsController : Controller
    {
        private readonly ILogger<ErrorsController> _logger;

        public ErrorsController(ILogger<ErrorsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Errors/404")]
        public IActionResult NotFound()
        {
            return View();
        }

        [HttpGet("Errors/Synonym/{message}")]
        public IActionResult SynonymError(string message)
        {
            return View("Synonym", message);
        }

        [HttpGet("Errors/{errorCode}")]
        public IActionResult GeneralError(string errorCode)
        {
            return View("GeneralError", errorCode);
        }
    }
}
