using Application.Common.Models;
using Application.Synonyms.Models;
using Application.Synonyms;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.ExternalClients.Dictionary;
using Infrastructure.Mappers;
using Domain.DTOs;

namespace Web.Controllers
{
    public class SynonymController : Controller
    {
        private readonly ILogger<SynonymController> _logger;
        private SynonymService _synonymService;
        private IDictionaryApiService _dictionaryService;

        public SynonymController(SynonymService synonymService, IDictionaryApiService dictionaryService, ILogger<SynonymController> logger)
        {
            _synonymService = synonymService;
            _dictionaryService = dictionaryService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Synonym/{name}")]
        public async Task<IActionResult> Synonym(string name)
        {
            var result = await _synonymService.GetByName(name);

            if (result == null)
                return Redirect("Errors/404");

            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult<Response<SynonymResponse>>> Add(AddSynonymRequest request)
        {
            var wordDataDto = (await _dictionaryService.GetWordData(request.Name)).ToDto();
            var result = await _synonymService.Add(request, wordDataDto);

            return RedirectToAction("Synonym", new { name = result.Name });
        }


        // Ajax methods
        [HttpGet("Search")]
        public async Task<ActionResult<PaginatedResponse<List<SynonymResponse>>>> Search([FromQuery] SearchSynonymsRequest request)
        {
            request.IgnoreNumberOfResults = true;

            return Ok(await _synonymService.Search(request));
        }
    }
}
