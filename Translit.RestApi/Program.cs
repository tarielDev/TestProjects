using Translit.Service.Services;
using Translit.Shared.Interfaces;

namespace Translit.RestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<ITranslitService, TranslitService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/api/translit", () =>
            {
                var html = """
                    <html>
                    <head><meta charset="UTF-8"><title>Транслитерация</title></head>
                    <body>
                        <h1>Пример транслитерации в браузерной строке</h1>
                        <p>Чтобы использовать: добавьте <code>?phrase=ваша_фраза</code> к адресу</p>
                        <p>Например: <code>/api/translit/phrase?phrase=привет</code></p>
                    </body>
                    </html>
                """;
                return Results.Content(html, "text/html; charset=utf-8");
            });
            app.MapControllers();

            app.Run();
        }
    }
}
