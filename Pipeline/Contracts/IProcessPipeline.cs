using System;
namespace BetterPipeline
{
    public interface IProcessPipeline<T>
    {
        T Process(T input);
    }
}
