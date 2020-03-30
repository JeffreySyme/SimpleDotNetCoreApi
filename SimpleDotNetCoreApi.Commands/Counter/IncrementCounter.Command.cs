using MediatR;

namespace SimpleDotNetCoreApi.Commands.Counter
{
    public partial class IncrementCounter
    {
        public class Command : IRequest<Response>
        {
            public int Value { get; set; }
        }

        public class CounterValue
        {
            public int Value { get; set; }
        }
    }
}
