// See https://aka.ms/new-console-template for more information

using System;
using ApiRateLimiter;

class Program
{


    static async Task Main(string[] args)
    {
        TokenBucketRateLimiter rateLimiter = new TokenBucketRateLimiter(5, TimeSpan.FromSeconds(10));
        string[] customers = { "Alice", "Bob" };

        Console.WriteLine("##### Demo #####");
        for (int i = 1; i <= 8; i++)
        {
            foreach (var customer in customers)
            {
                var result = rateLimiter.CheckRequest(customer);
                Console.WriteLine($"Customer: {customer}, RequestNo:{i} Result: {result.ToString()}");
            }

            await Task.Delay(TimeSpan.FromMilliseconds(500));
        }
    }
}
