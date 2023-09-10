using Task4.Factory.Details;
using Task4.Factory.Observer;

namespace Task4.Factory.Warehouses;

internal sealed class Warehouse<T> : Observable where T : ITem
{
    private const int MinItemsCount = 0;
    private const int MaxItemsCount = 100;

    private readonly Queue<T> _items;

    public int Capacity { get; }

    public Warehouse(int capacity)
    {
        if (capacity is <= MinItemsCount or >= MaxItemsCount)
        {
            throw new ArgumentException();
        }

        Capacity = capacity;

        _items = new Queue<T>();
    }

    public bool TryGetItem(out T result)
    {
        if (_items.Count > 0)
        {
            result = _items.Dequeue();
            return true;
        }

        result = default!;
        return false;
    }

    public void PutItem(T item)
    {
        if (_items.Count >= Capacity)
        {
            return;
        }

        _items.Enqueue(item);

        Notify(item);
    }
}