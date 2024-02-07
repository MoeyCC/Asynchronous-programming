namespace Asynchronous_Programming;

public class AsyncExample
{
    private class DataStore { public int Value { get; set; } }
    
    private DataStore store1 = new DataStore(){ Value = 2};
    private DataStore store2 = new DataStore(){ Value = 3};
    
    public void ConcurrencyTest()
    {
        var thread1 = new Thread(IncrementStore2Value);
        var thread2 = new Thread(IncrementStore1Value);
        
        thread1.Start();
        thread2.Start();
        
        thread1.Join(); // Wait for the thread to finish executing
        thread2.Join();
        
        Console.WriteLine($"Final value Store1: {store1.Value}");
        Console.WriteLine($"Final value Store2: {store2.Value}");

    }
    
    private void IncrementStore1Value()
    {
        lock(store2)
        {
            lock(store1)
            {
                store1.Value = store2.Value;
            }
        }
    }

    private void IncrementStore2Value()
    {
        lock(store1)
        {
            lock(store2)
            {
                store2.Value = store1.Value;
            }
        }
    }
}