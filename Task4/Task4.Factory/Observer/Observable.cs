using Task4.Factory.Details;

namespace Task4.Factory.Observer;

internal class Observable : IObservable
{
    private readonly List<IObserver> _observers = new();

    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify(Item item)
    {
        foreach (var observer in _observers)
        {
            observer.Update(item);
        }
    }
}