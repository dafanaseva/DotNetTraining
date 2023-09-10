using System.Collections.Immutable;
using Task4.Factory.Details;

namespace Task4.Factory;

internal sealed class Car : ITem
{
    public Guid Id { get; set; }
    public Body Body { get;}
    public Engine Engine { get; }
    public ImmutableArray<Accessory> Accessories { get; }

    public Car(Body body, Engine engine, ImmutableArray<Accessory> accessories)
    {
        Body = body;
        Engine = engine;
        Accessories = accessories;
    }

}
