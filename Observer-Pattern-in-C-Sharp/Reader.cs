
namespace Observer_Pattern_in_C_Sharp;


/// <summary>
/// The User class implements the IObserver interface,
/// allowing the reader to receive updates from the NewsPublisher.
/// </summary>
public class Reader : IObserver<string>
{
    public string UserName { get; private set; }
    private IDisposable unsubscriber;


    /// <summary>
    /// Initializes a new instance of the User class.
    /// </summary>
    /// <param name="name">The name of the reader.</param>
    public Reader(string name)
    {
        UserName = name; // Initialize the reader name
    }

    /// <summary>
    /// Subscribes the reader to a news publisher.
    /// </summary>
    /// <param name="publisher">The news publisher to subscribe to.</param>
    public void Subscribe(NewsPublisher publisher)
    {
        unsubscriber = publisher.Subscribe(this); // Subscribe to the publisher
    }

    /// <summary>
    /// Called when a new news article is published.
    /// </summary>
    /// <param name="news">The news article that was published.</param>
    public void OnNext(string news)
    {
        Console.WriteLine($"[{UserName}] New article published: {news}"); // Print the new article
    }

    /// <summary>
    /// Called when an error occurs during publishing.
    /// </summary>
    /// <param name="error">The exception that occurred.</param>
    public void OnError(Exception error)
    {
        Console.WriteLine($"[{UserName}] An error occurred: {error.Message}"); // Print the error message
    }

    /// <summary>
    /// Called when there will be no more news updates.
    /// </summary>
    public void OnCompleted()
    {
        Console.WriteLine($"[{UserName}] News updates have completed."); // Notify that updates are done
    }

    /// <summary>
    /// Unsubscribes the reader from the news publisher.
    /// </summary>
    public void Unsubscribe()
    {
        unsubscriber.Dispose(); // Dispose of the unsubscriber
    }
}
