# BetterPipeline

A library designed to make use of the pipeline pattern.

# Custom pipelines

You may extend the generic pipeline and override the process method defined

```C#
public class ProcessOrdersPipeline : Pipeline<OrdersCollection>
{
    public ProcessFilesPipeline()
    {
    }
    
    // you must override the Process method
    
}
```

# Creating stages

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
        // some logic to create an order

        return 0;
    }
}

// stage two
public class ProcessPayment : IStage<int>
{
    public int Execute(int input)
    {
        // some logic to process a payment

        return 0;
    }
}

// stage three
public class SendInvoice : IStage<int>
{
    public int Execute(int input)
    {
        // some logic to send an invoice

        return 0;
    }
}

```
# Putting it all together

```C#
Pipeline<int> pipeline = new ProcessOrdersPipeline();
// alternatively you may use the Register method to add your stages
pipeline.Pipe(new CreateOrder())
.Pipe(new ProcessPayment())
.Pipe(new SendInvoice());

pipeline.Process(0);
```

If you want to return a different type within a stage:
```C#
// A stage
public class SendInvoice : IMixedStage<bool,int>
{
    public bool Execute(int input)
    {
        // some logic to send an invoice

        return false;
    }
}
```

Note: If you wish to use a mixed stage, you must inherit from MixedPipeline.

# Getting Started

The pipeline runner conveniently implements the Process method
```C#
Pipeline<int> pipeline = new PipelineRunner<int>();
// using the Register method
pipeline.Register(new CreateOrder())
.Register(new ProcessPayment())
.Register(new SendInvoice());
// the result is determined by the last stage
pipeline.Process(0);
```

The aggregate pipeline runner works the same as the pipeline runner except that it uses the result from a previous stage. A mixed stage is not supported here.
```C#
Pipeline<int> pipeline = new AggregatePipelineRunner<int>();
// using the Register method
pipeline.Register(new CreateOrder())
.Register(new ProcessPayment())
.Register(new SendInvoice());
// the result is determined by the last stage
pipeline.Process(0);
```

The task pipeline runner implements a mixed pipeline where the input can be a different type than output. Again, this pipeline runner implements the process method.
```C#
TaskPipelineRunner<int> p = new TaskPipelineRunner<int>(3);
p.Pipe(new CreateOrderTask())
.Pipe(new ProcessPaymentTask())
.Pipe(new SendInvoiceTask());

p.Process(0);
```
# to-do
1. Support asynchronous processing
2. Allow for more arguments
3. Tests,Tests,Tests
