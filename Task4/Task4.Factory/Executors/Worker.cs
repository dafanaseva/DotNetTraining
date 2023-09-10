using System.Collections.Immutable;
using Task4.Factory.Details;
using Task4.Factory.Exceptions;
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
        if (!_accessoryWarehouse.TryGetItem(out var accessory))
        {
            throw new FailedGetITemException(nameof(accessory));
        }
        if (!_bodyWarehouse.TryGetItem(out var body))
        {
            throw new FailedGetITemException(nameof(body));
        }

        if (!_enginesWarehouse.TryGetItem(out var engine))
        {
            throw new FailedGetITemException(nameof(engine));
        }

        return new Car(body, engine, ImmutableArray.Create(new[] { accessory }));
    }
}