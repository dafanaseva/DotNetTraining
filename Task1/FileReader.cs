using Task1.Interfaces;

namespace Task1
{
    public class FileReader : IReader
    {
        private readonly StreamReader _reader;

        public FileReader(string inputFileName)
        {
            _reader = new StreamReader(inputFileName);
        }

        public void Dispose()
        {
            _reader.Dispose();
        }

        public bool HasNext()
        {
            return _reader.Peek() >= 0;
        }

        public char ReadChar()
        {
            return (char)_reader.Read();
        }
    }
}
