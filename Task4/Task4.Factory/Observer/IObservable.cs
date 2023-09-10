using Task4.Factory.Details;

namespace Task4.Factory.Observer;

internal interface IObservable
{
    void AddObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void Notify(ITem item);
}