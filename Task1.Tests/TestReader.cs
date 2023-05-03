using Task1.Interfaces;

namespace Task1.Tests
{
    internal class TestReader : IReader
    {
        private readonly string _text;
        private int _position;

        public TestReader(string text)
        {
            _text = text;
            _position = 0;
        }

        public bool HasNext()
        {
            return _position < _text.Length;
        }

        public char ReadChar()
        {
            return _text[_position++];
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
