namespace Task1.Interfaces
{
    public interface IWriter<T>
    {
        void WriteAll(IEnumerable<T> data);
    }
}
