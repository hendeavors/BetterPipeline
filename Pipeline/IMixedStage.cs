using System;
namespace BetterPipeline
{
    public interface IMixedStage<T,K>
    {
        /// <summary>
        /// Execute the specified input.
        /// </summary>
        /// <returns>The execute.</returns>
        /// <param name="input">Input.</param>
        T Execute(K input);
    }
}
