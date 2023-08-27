namespace Task4.Factory.Configuration;

internal sealed class FactoryConfig
{
    public int WarehouseEngineCapacity { get; set; } = 100;
    public int WarehouseBodyCapacity { get; set; } = 100;
    public int WarehouseAccessoryCapacity { get; set; } = 100;
    public int WarehouseCarCapacity { get; set; } = 100;

    public int AccessorySupplierCount { get; set; } = 5;

    public int WorkerCount { get; set; } = 10;
    public int DealerCount { get; set; } = 20;

    public bool LogSale { get; set; } = true;
}