using Grpc.Net.Client;
using System.Text;
using Translit.Service.Grpc;
using static Translit.Service.Grpc.Translit;

namespace Translit.ConsoleClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            using var channel = GrpcChannel.ForAddress("https://localhost:7041");
            var client = new TranslitClient(channel);

            Console.WriteLine("Введите фразу для транслитерации (пустая строка = выход):");
            while (true)
            {
                Console.Write("> ");
                var phrase = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(phrase)) break;

                Console.WriteLine($"Введено: {phrase}");
                var response = await client.TransliterateAsync(new TranslitRequest { Phrase = phrase });
                Console.WriteLine($"Транслитерация: {response.Result}");

            }
        }
    }
}
