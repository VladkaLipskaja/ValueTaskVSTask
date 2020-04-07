# ValueTask vs Task
Benchmarking of ValueTask&lt;TResult> versus Task&lt;TResult> due to tradeoffs to using a ValueTask.

Since over the past year, [more](https://devblogs.microsoft.com/dotnet/understanding-the-whys-whats-and-whens-of-valuetask/ "more") and [more](https://ladeak.wordpress.com/2019/03/09/valuetask-vs-task/ "more") articles have appeared on the viability of using ValueTask<TResult>, so I decided to check this using [BenchmarkDotNet](https://benchmarkdotnet.org/ "BenchmarkDotNet"), using the typical (most common) design.

Where and how to use the ValueTask<TResult> can be found [here](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1?view=netcore-3.1 "here").

These metrics demonstrate the benefits that bring (or not), given that they are often used in this way. As a conclusion, I can say that the construction of the ValueTask is not useful for frivolous use, so you need to be especially careful about the choice. You can check it yourself, but I got the following results:

