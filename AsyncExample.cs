namespace Asynchronous_Programming;

public class AsyncExample
{
    private class DataStore { public int Value { get; set; } }
    
    private DataStore store = new DataStore();
    
    public void ConcurrencyTest()
    {
        var thread1 = new Thread(IncrementTheValue);
        var thread2 = new Thread(IncrementTheValue);
        
        thread1.Start();
        thread2.Start();
        
        thread1.Join(); // Wait for the thread to finish executing
        thread2.Join();
        
        Console.WriteLine($"Final value: {store.Value}");
    }
    
    private void IncrementTheValue()
    {
        store.Value++;
    }
}