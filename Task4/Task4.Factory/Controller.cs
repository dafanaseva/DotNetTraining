using Task4.Factory.Details;
using Task4.Factory.Executors;
using Task4.Factory.Observer;
using Task4.Factory.Warehouses;

namespace Task4.Factory;

internal sealed class Controller : IObserver
{
    private readonly Worker _worker;
    private readonly Warehouse<Car> _carsWarehouse;

    public Controller(Worker worker, Warehouse<Car> carsWarehouse)
    {
        _worker = worker;
        _carsWarehouse = carsWarehouse;

        _carsWarehouse.AddObserver(this);
    }

    public void Update(Item item)
    {
        for (var i = 0; i < _carsWarehouse.Capacity; ++i)
        {
            _worker.BuildCar();
        }
    }
}