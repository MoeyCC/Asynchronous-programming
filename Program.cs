using System.Diagnostics;

namespace Asynchronous_Programming;
class Program
{
    static async Task Main(string[] args)
    {
        AsyncExample asyncExample = new AsyncExample();
        
        Stopwatch stopWatch = new Stopwatch();

        stopWatch.Start();        
        int result = await asyncExample.CountNonExistentWordsAsync();
        stopWatch.Stop();

        TimeSpan ts = stopWatch.Elapsed;
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        Console.WriteLine("RunTime " + elapsedTime);
        Console.WriteLine(result);
    }
}
