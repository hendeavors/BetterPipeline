namespace BetterPipeline
{
    public interface IStage<T>
    {
        /// <summary>
        /// Execute the specified input.
        /// </summary>
        /// <returns>The execute.</returns>
        /// <param name="input">Input.</param>
        T Execute(T input);
    }
}