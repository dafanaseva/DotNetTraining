using Task1;

try
{
    if (Environment.GetCommandLineArgs().Length <= 1)
    {
        throw new ArgumentException("Please enter file name");
    }

    var fileName = Environment.GetCommandLineArgs()[1];

    if (!File.Exists(fileName))
    {
        throw new ArgumentException("File does not exist");
    }

    using var reader = new FileReader(fileName);

    var service = new StatisticsService(reader, new CsvWriter<WordStatistics>($"results_{Guid.NewGuid()}"));

    service.PrintStatistics();

    Console.ReadLine();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.ReadLine();
}