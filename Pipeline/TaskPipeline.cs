using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BetterPipeline
{
    public abstract class TaskPipeline<T>
    {
        public TaskPipeline()
        {
        }
        /// <summary>
        /// The stages.
        /// </summary>
        protected readonly IList<ITaskStage<T>> stages = new List<ITaskStage<T>>();

        /// <summary>
        /// Pipe the specified stage.
        /// </summary>
        /// <returns>The pipe.</returns>
        /// <param name="stage">Stage.</param>
        public TaskPipeline<T> Pipe(ITaskStage<T> stage)
        {
            stages.Add(stage);

            return this;
        }

        /// <summary>
        /// Register the specified stage.
        /// </summary>
        /// <returns>The register.</returns>
        /// <param name="stage">Stage.</param>
        public TaskPipeline<T> Register(ITaskStage<T> stage)
        {
            return Pipe(stage);
        }
    
        /// <summary>
        /// Process the specified input.
        /// </summary>
        /// <returns>The process.</returns>
        /// <param name="input">Input.</param>
        public abstract Task<T> Process(T input);

        /// <summary>
        /// Gets the stages.
        /// </summary>
        /// <returns>The stages.</returns>
        public IList<ITaskStage<T>> GetStages()
        {
            return stages;
        }
    }
}
