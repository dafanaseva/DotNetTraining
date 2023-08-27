using Task4.Factory.Details;

namespace Task4.Factory.Observer;

internal interface IObserver
{
    void Update(Item item);
}