using Task4.Factory.Details;
using Task4.Factory.Warehouses;

namespace Task4.Factory.Executors;

internal sealed class Supplier<T> where T : ITem, new()
{
    private readonly Warehouse<T> _warehouse;
    private readonly TextWriter _textWriter;

    public Supplier(Warehouse<T> warehouse, TextWriter textWriter)
    {
        _warehouse = warehouse;
        _textWriter = textWriter;
    }

    public void Supply()
    {
        var item = new T();
        _warehouse.PutItem(item);

        _textWriter.WriteLine($"The item is supplied: {item}");
    }
}