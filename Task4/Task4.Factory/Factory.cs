using Task4.Factory.Configuration;
using Task4.Factory.Details;
using Task4.Factory.Executors;
using Task4.Factory.Warehouses;

namespace Task4.Factory;

public sealed class Factory
{
    private readonly Warehouse<Body> _bodyWarehouse;
    private readonly Warehouse<Engine> _enginesWarehouse;
    private readonly Warehouse<Accessory> _accessoryWarehouse;

    private readonly Warehouse<Car> _carWarehouse;
    private readonly Supplier<Engine> _engineSupplier;
    private readonly Supplier<Body> _bodySupplier;
    private readonly List<Supplier<Accessory>> _accessorySuppliers;

    private readonly List<Dealer> _dealers;

    private readonly Worker _worker;

    private readonly TextWriter _textWriter;

    public Factory(TextWriter textWriter, FactoryConfig config)
    {
        _textWriter = textWriter;

        _bodyWarehouse = new Warehouse<Body>(config.WarehouseBodyCapacity);
        _enginesWarehouse = new Warehouse<Engine>(config.WarehouseEngineCapacity);
        _accessoryWarehouse = new Warehouse<Accessory>(config.WarehouseAccessoryCapacity);
        _carWarehouse = new Warehouse<Car>(config.WarehouseCarCapacity);

        _engineSupplier = new Supplier<Engine>(_enginesWarehouse, textWriter);
        _bodySupplier = new Supplier<Body>(_bodyWarehouse, textWriter);
        _accessorySuppliers = new List<Supplier<Accessory>>();

        _worker = new Worker(_bodyWarehouse, _enginesWarehouse, _accessoryWarehouse);
        _dealers = new List<Dealer>();

        for (var i = 0; i < config.DealerCount; i++)
        {
            _dealers.Add(new Dealer(_carWarehouse, _textWriter));
        }
    }

    public void Start()
    {
        _textWriter.WriteLine("Start factory");
    }

    public void Stop()
    {
        _textWriter.WriteLine("Stop factory");
    }
}