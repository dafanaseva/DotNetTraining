using System.Collections.Immutable;
using Task4.Factory.Details;
using Task4.Factory.Warehouses;

namespace Task4.Factory.Executors;

internal sealed class Worker
{
    private readonly Warehouse<Body> _bodyWarehouse;
    private readonly Warehouse<Engine> _enginesWarehouse;
    private readonly Warehouse<Accessory> _accessoryWarehouse;

    public Worker(Warehouse<Body> bodyWarehouse, Warehouse<Engine> enginesWarehouse, Warehouse<Accessory> accessoryWarehouse)
    {
        _bodyWarehouse = bodyWarehouse;
        _enginesWarehouse = enginesWarehouse;
        _accessoryWarehouse = accessoryWarehouse;
    }

    public Car BuildCar()
    {
        var accessory = _accessoryWarehouse.GetItem() ?? throw new NullReferenceException();
        var body = _bodyWarehouse.GetItem() ?? throw new NullReferenceException();
        var engine = _enginesWarehouse.GetItem() ??  throw new NullReferenceException();

        return new Car(body, engine, ImmutableArray.Create(new[] { accessory }));
    }
}