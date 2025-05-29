using Grpc.Core;
using Translit.Service.Grpc;
using Translit.Shared.Interfaces;
using static Translit.Service.Grpc.Translit;

namespace Translit.Service.GrpcServices
{
    public class TranslitGrpcService : TranslitBase
    {
        private readonly ITranslitService _service;

        public TranslitGrpcService(ITranslitService service)
        {
            _service = service;
        }

        public override Task<TranslitResponse> Transliterate(TranslitRequest request, ServerCallContext context)
        {
            var result = _service.Transliterate(request.Phrase);
            return Task.FromResult(new TranslitResponse { Result = result });
        }

    }
}
