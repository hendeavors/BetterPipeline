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

# creating a stage

You must implement 

```C# 
IStage<T> 
```

```C#
// stage one
public class CreateOrder : IStage<int>
{
    public int Execute(int input)
    {
        int result = input + 1;

        return result;
    }
}

// stage two
public class ProcessPayment : IStage<int>
{
    public int Execute(int input)
    {
        int result = input + 1;

        return result;
    }
}

// stage three
public class SendInvoice : IStage<int>
{
    public int Execute(int input)
    {
        int result = input + 1;

        return result;
    }
}

```
