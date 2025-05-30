using Microsoft.AspNetCore.Mvc;
using Translit.Shared.Interfaces;

namespace Translit.RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TranslitController : ControllerBase
    {
        private readonly ITranslitService _service;

        public TranslitController(ITranslitService service)
        {
            _service = service;
        }



        // Этот метод можно вызывать из браузера
        [HttpGet("transliterate")]
        public ActionResult<string> Transliterate([FromQuery] string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase))
                return BadRequest("Пустая фраза");

            var result = _service.Transliterate(phrase);
            return Ok(result);
        }


    }
}
