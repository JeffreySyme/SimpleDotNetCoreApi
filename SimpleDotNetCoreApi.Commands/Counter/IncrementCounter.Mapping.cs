using AutoMapper;
using SimpleDotNetCoreApi.Shared.Services;

namespace SimpleDotNetCoreApi.Commands.Counter
{
    public partial class IncrementCounter
    {
        public class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Command, CounterValue>();
                CreateMap<CounterValue, Response>();
            }
        }
    }
}
