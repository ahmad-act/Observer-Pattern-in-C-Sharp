

namespace Observer_Pattern_in_C_Sharp;

/// <summary>
/// The NewsPublisher class implements the IObservable interface,
/// allowing subscribers to receive news updates.
/// </summary>
public class NewsPublisher : IObservable<string>
{
    // List to hold all the observers (subscribers). i.e. Users
    private List<IObserver<string>> observers = new List<IObserver<string>>();

    /// <summary>
    /// Subscribes an observer to the publisher.
    /// </summary>
    /// <param name="observer">The observer to subscribe.</param>
    /// <returns>An IDisposable for unsubscribing.</returns>
    public IDisposable Subscribe(IObserver<string> observer)
    {
        // Add the observer to the list if it's not already subscribed
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }

        // Return an Unsubscriber to allow unsubscription
        return new Unsubscriber(observers, observer);
    }

    /// <summary>
    /// Publishes a news article to all subscribed observers.
    /// </summary>
    /// <param name="news">The news article to publish.</param>
    public void PublishNews(string news)
    {
        // Notify all observers with the new news article
        foreach (var observer in observers)
        {
            observer.OnNext(news); // Notify observers of new news
        }
    }

    
    // Private class to handle unsubscription
    private class Unsubscriber : IDisposable
    {
        private List<IObserver<string>> _observers; // List of observers
        private IObserver<string> _observer; // The specific observer to be unsubscribed

        public Unsubscriber(List<IObserver<string>> observers, IObserver<string> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        /// <summary>
        /// Removes the observer from the list of observers.
        /// </summary>
        public void Dispose()
        {
            if (_observer != null && _observers.Contains(_observer))
            {
                _observers.Remove(_observer);
            }
        }
    }
}
