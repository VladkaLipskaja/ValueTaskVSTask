using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace TaskVSValueTask
{
    [MemoryDiagnoser]
    [MinColumn, MaxColumn]
    public class TaskVSValueTask
    {
        private readonly IAsyncEnumerable<int> _collection;

        private const int Min = 0;
        private const int Max = 20;

        public TaskVSValueTask()
        {
            Random rand = new Random();
            _collection = Enumerable
                .Repeat(0, 100)
                .Select(i => rand.Next(Min, Max))
                .ToAsyncEnumerable();
        }

        [Benchmark]
        public async ValueTask<int> ValueTaskOnce()
        {
            // var number = await _collection.CountAsync();
            await Task.Delay(10);
            return 10;
        }

        [Benchmark]
        public async Task<int> TaskOnce()
        {
            // var number = await _collection.CountAsync();
            await Task.Delay(10);
            return 10;
        }

        [Benchmark]
        public async ValueTask<int> ValueTask100()
        {
            await Task.Run(async () =>
            {
                for (var i = 0; i < 100; i++)
                {
                    await V();
                }
            });
            return 10;
        }
        
        [Benchmark]
        public async Task<int> Task100()
        {
            await Task.Run(async () =>
            {
                for (var i = 0; i < 100; i++)
                {
                    await T();
                }
            });
            return 10;
        }
        
        private async ValueTask<int> V()
        {
            // var number = await _collection.CountAsync();
            await Task.Delay(10);
            return 10;
        }
        
        public async Task<int> T()
        {
            // var number = await _collection.CountAsync();
            await Task.Delay(10);
            return 10;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<TaskVSValueTask>();
        }
    }
}