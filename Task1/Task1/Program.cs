using Task1;

const int fileNameArgIndex = 1;
const string outPutFileNamePattern = "result_{0}.csv";

try
{
    if (Environment.GetCommandLineArgs().Length <= fileNameArgIndex)
    {
        throw new ArgumentException("Please pass a file name as a command line argument.");
    }

    var inputFileName = Environment.GetCommandLineArgs()[fileNameArgIndex];

    Console.WriteLine($"Start reading words from the file {inputFileName}.");

    using var streamReader = new StreamReader(inputFileName);
    var words = WordsBuilderHelper.ReadWords(streamReader).ToList();

    var outputFileName = string.Format(outPutFileNamePattern, Guid.NewGuid().ToString());

    using var streamWriter = File.CreateText(outputFileName);
    WordsBuilderHelper.WriteWords(words, streamWriter);

    Console.WriteLine($"The number of words found: {words.Count}");
    Console.WriteLine($"You can find results in the file with name: {outputFileName}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
finally
{
    Console.WriteLine("Press any key to exit.");
    Console.ReadLine();
}