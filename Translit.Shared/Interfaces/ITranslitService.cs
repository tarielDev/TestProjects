using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translit.Shared.Interfaces
{
    public interface ITranslitService
    {
        string Transliterate(string phrase);
    }
}
