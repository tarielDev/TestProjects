using Microsoft.AspNetCore.Mvc;

namespace Translit.WebClient.Controllers
{
    public class TranslitController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TranslitController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string phrase)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7178"); // твой API

            var request = new { phrase = phrase };
            var response = await client.PostAsJsonAsync("api/translit", request);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadFromJsonAsync<ResponseDto>();
                ViewBag.Result = json?.Result;
            }
            else
            {
                ViewBag.Result = "Ошибка обращения к API";
            }

            return View();
        }

        public class ResponseDto
        {
            public string Result { get; set; }
        }
    }
}
