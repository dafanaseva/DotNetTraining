namespace Task1.Interfaces
{
    public interface IReader : IDisposable
    {
        public bool HasNext();
        public char ReadChar();
    }
}
