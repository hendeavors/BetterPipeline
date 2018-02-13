# BetterPipeline

A library designed to make use of the pipeline pattern.

# custom pipelines

You may extend the generic pipeline and override the process method defined

```C#
public class ProcessFilesPipeline : Pipeline<FileInfo>
{
    public ProcessFilesPipeline()
    {
    }
    
    // override the Process method
    
}
```

#built in pipelines - the runner

```C#
PipelineRunner<int> pipeline = new PipelineRunner<int>();

pipeline.Register(new ConcreteStage())
.Register(new ConcreteStageTwo());

```
