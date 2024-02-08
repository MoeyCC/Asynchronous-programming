using System.Net;

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
        //Thread.Sleep(1);
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
        //Thread.Sleep(1);
        lock(store1)
        {
            lock(store2)
            {
                store2.Value = store1.Value;
            }
        }
    }

    public async Task<int> CountNonExistentWordsAsync()
    {
        Task<string> articleTask = new WebClient().DownloadStringTaskAsync(
            @"https://msdn.microsoft.com/en-gb/library/mt674882.aspx");
        Task<string> wordsTask = new WebClient().DownloadStringTaskAsync(
            @"https://github.com/dwyl/english-words");
        
        string article = await articleTask;
        string words = await wordsTask; 
        
        HashSet<string> wordList = new HashSet<string>(words.Split('\n'));

        var nonExistentWords = 0;
        
        foreach (string word in article.Split('\n', ' '))
            {
                if (!wordList.Contains(word)) nonExistentWords++;
            }
        
        return nonExistentWords;
    }
}