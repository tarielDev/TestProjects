using Translit.Shared.Interfaces;

namespace Translit.Service.Services
{
    public class TranslitService : ITranslitService
    {
        private static readonly Dictionary<char, string> _map = new()
        {
            ['а'] = "a", ['б'] = "b", ['в'] = "v",['г'] = "g", ['д'] = "d",
            ['е'] = "e", ['ё'] = "yo", ['ж'] = "zh", ['з'] = "z", ['и'] = "i",
            ['й'] = "y", ['к'] = "k", ['л'] = "l", ['м'] = "m", ['н'] = "n",
            ['о'] = "o", ['п'] = "p", ['р'] = "r",['с'] = "s", ['т'] = "t",
            ['у'] = "u", ['ф'] = "f", ['х'] = "kh",['ц'] = "ts", ['ч'] = "ch",
            ['ш'] = "sh",['щ'] = "shch",['ъ'] = "", ['ы'] = "y", ['ь'] = "",
            ['э'] = "e", ['ю'] = "yu", ['я'] = "ya"
        };

        public string Transliterate(string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase))
                return string.Empty;

            var result = new List<string>();

            foreach (var ch in phrase.ToLowerInvariant())
            {
                result.Add(_map.TryGetValue(ch, out var latin) ? latin : ch.ToString());
            }

            return string.Join("", result);
        }
    }
}
