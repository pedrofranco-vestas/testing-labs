using System;

using Vestas.TurbineSwRollout.Common.RetryPolicy.Models;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var e = new ErrorModel
            {
                Category = ErrorCategory.Exception
            };

            Console.WriteLine($"Hello World! Category={e.Category}");
        }
    }
}
