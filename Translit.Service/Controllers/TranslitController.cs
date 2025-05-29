using Microsoft.AspNetCore.Mvc;
using Translit.Shared.Interfaces;
using Translit.Shared.Models;

namespace Translit.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TranslitController : Controller
    {

        private readonly ITranslitService _service;

        public TranslitController(ITranslitService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<TranslitResponse> Post([FromBody] TranslitRequest request)
        {
            var result = _service.Transliterate(request.Phrase);
            return Ok(new TranslitResponse { Result = result });
        }
    }
}
