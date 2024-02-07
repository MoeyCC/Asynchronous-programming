using System.Diagnostics;

namespace Asynchronous_Programming;
class Program
{
    static void Main(string[] args)
    {
        AsyncExample asyncExample = new AsyncExample();

        Stopwatch stopwatch = new Stopwatch();
        
        stopwatch.Start();
        asyncExample.ConcurrencyTest();    
        stopwatch.Stop();
        
        TimeSpan ts = stopwatch.Elapsed;
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        Console.WriteLine("RunTime " + elapsedTime);
    }
}
