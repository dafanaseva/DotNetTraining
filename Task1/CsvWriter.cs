using Task1.Interfaces;

namespace Task1
{
    public class CsvWriter<T> : IWriter<T> where T : notnull
    {
        private  readonly string _output;

        public CsvWriter(string outputfileName)
        {
            _output = outputfileName + ".csv";
        }

        public void WriteAll(IEnumerable<T> data)
        {
            if (!data.Any()) return;

            if (!File.Exists(_output))
            {
                using var streamWriter = File.CreateText(_output);

                foreach (var item in data)
                {
                    var values = item.GetType()
                                     .GetProperties()
                                     .Select(t => t.GetValue(item))
                                     .Select(t => t?.ToString() ?? string.Empty)
                                     .ToArray();

                    streamWriter.WriteLine(string.Join(',', values.Where(t => !string.IsNullOrEmpty(t))));
                }
            }
            else
            {
                throw new ArgumentException("The file already exists");
            }
        }
    }
}
