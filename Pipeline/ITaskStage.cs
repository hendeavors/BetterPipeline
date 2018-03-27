using System;
using System.Threading.Tasks;

namespace BetterPipeline
{
    public interface ITaskStage<T>
    {
        /// <summary>
        /// Execute the specified input.
        /// </summary>
        /// <returns>The execute.</returns>
        /// <param name="input">Input.</param>
        Task<T> Execute(T input);
    }
}
