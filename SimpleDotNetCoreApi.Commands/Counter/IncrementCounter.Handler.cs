using AutoMapper;
using MediatR;

namespace SimpleDotNetCoreApi.Commands.Counter
{
    public partial class IncrementCounter
    {
        public class Handler : RequestHandler<Command, Response>
        {
            private readonly IMapper _mapper;
            public Handler(IMapper mapper)
            {
                _mapper = mapper;
            }

            protected override Response Handle(Command request)
            {
                var counterValue = _mapper.Map<CounterValue>(request);

                counterValue.Value += 1;

                return _mapper.Map<Response>(counterValue);
            }
        }
    }
}
