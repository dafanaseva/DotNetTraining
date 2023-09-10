using Task4.Factory.Warehouses;

namespace Task4.Factory.Executors;

internal sealed class Dealer
{
    private readonly Warehouse<Car> _carWarehouse;
    private readonly TextWriter _textWriter;

    public Dealer(Warehouse<Car> carWarehouse, TextWriter textWriter)
    {
        _carWarehouse = carWarehouse;
        _textWriter = textWriter;
    }

    public void Run()
    {
        if (_carWarehouse.TryGetItem(out var car))
        {
            _textWriter.WriteLine($"The car is sold: {car.Id}");
        }
    }
}