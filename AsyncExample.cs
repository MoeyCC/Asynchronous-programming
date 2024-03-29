using System.Net;

namespace Asynchronous_Programming;

public class AsyncExample
{
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