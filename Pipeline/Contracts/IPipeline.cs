using System;
using System.Threading.Tasks;

namespace BetterPipeline
{
    public interface IPipeline<T>
    {
        T Process(T input);

        IPipeline<T> Pipe(IStage<T> stage);

        IPipeline<T> Register(IStage<T> stage);
    }
}
