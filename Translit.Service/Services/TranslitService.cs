using Grpc.Core;
using System.Text;
using Translit.Service.Grpc;
using Translit.Shared.Interfaces;

namespace Translit.Service.Services
{
    public class TranslitService : ITranslitService
    {
        private static readonly Dictionary<char, string> _map = new()
        {
            ['А'] = "A",['Б'] = "B",['В'] = "V",['Г'] = "G",['Д'] = "D",['Е'] = "E",['Ё'] = "E",['Ж'] = "Zh",
            ['З'] = "Z",['И'] = "I",['Й'] = "Y",['К'] = "K",['Л'] = "L",['М'] = "M",['Н'] = "N",['О'] = "O",
            ['П'] = "P",['Р'] = "R",['С'] = "S",['Т'] = "T",['У'] = "U",['Ф'] = "F",['Х'] = "Kh",['Ц'] = "Ts",
            ['Ч'] = "Ch",['Ш'] = "Sh",['Щ'] = "Shch",['Ъ'] = "",['Ы'] = "Y",['Ь'] = "",['Э'] = "E",['Ю'] = "Yu",
            ['Я'] = "Ya",['а'] = "a",['б'] = "b",['в'] = "v",['г'] = "g",['д'] = "d",['е'] = "e",['ё'] = "e",
            ['ж'] = "zh",['з'] = "z",['и'] = "i",['й'] = "y",['к'] = "k",['л'] = "l",['м'] = "m",['н'] = "n",
            ['о'] = "o",['п'] = "p",['р'] = "r",['с'] = "s",['т'] = "t",['у'] = "u",['ф'] = "f",['х'] = "kh",
            ['ц'] = "ts",['ч'] = "ch",['ш'] = "sh",['щ'] = "shch",['ъ'] = "",['ы'] = "y",['ь'] = "",['э'] = "e",['ю'] = "yu",['я'] = "ya"
        };

        public string Transliterate(string phrase)
        {
            Console.WriteLine($"[Service] Входная фраза: {phrase}");

            var result = new StringBuilder();
            foreach (var c in phrase)
            {
                if (_map.TryGetValue(c, out var latin))
                    result.Append(latin);
                else
                    result.Append(c);
            }
            var output = result.ToString();
            Console.WriteLine($"[Service] Результат: {output}");
            return output;
        }
    }
}
