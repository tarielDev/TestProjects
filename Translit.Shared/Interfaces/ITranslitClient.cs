using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translit.Shared.Models;

namespace Translit.Shared.Interfaces
{
    public interface ITranslitClient
    {
        Task<TranslitResponse> TransliterateAsync(TranslitRequest request, CancellationToken cancellationToken = default);
    }
}
