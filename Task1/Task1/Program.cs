using Task1;

try
{
    if (Environment.GetCommandLineArgs().Length <= 1)
    {
        throw new ArgumentException("Please enter file name");
    }

    var fileName = Environment.GetCommandLineArgs()[1];

    using var streamReader = new StreamReader(fileName);
    var words = WordsBuilderHelper.ReadWords(streamReader).ToList();

    using var streamWriter = File.CreateText($"result_{Guid.NewGuid().ToString()}.csv");
    WordsBuilderHelper.WriteWords(words, streamWriter);

    Console.WriteLine($"Words found:{words.Count}");

    Console.ReadLine();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
    Console.ReadLine();
}