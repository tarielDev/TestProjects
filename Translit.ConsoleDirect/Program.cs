using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Translit.Service.Services;
using Translit.Shared.Interfaces;


namespace Translit.ConsoleDirect;

class Program
{
    static void Main(string[] args)
    {
        // Настраиваем DI
        var services = new ServiceCollection();
        ConfigureServices(services);
        var provider = services.BuildServiceProvider();

        // Получаем сервис транслитерации
        var translitService = provider.GetRequiredService<ITranslitService>();

        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Введите фразу для транслитерации (пустая строка = выход):");

        while (true)
        {
            Console.Write("> ");
            var phrase = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(phrase)) break;

            Console.WriteLine($"Введено: {phrase}");
            var result = translitService.Transliterate(phrase);
            Console.WriteLine($"Транслитерация: {result}");
        }

    }

    // Этот метод РЕГИСТРИРУЕТ нужные зависимости в DI-контейнере
    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<ITranslitService, TranslitService>();
    }
}
