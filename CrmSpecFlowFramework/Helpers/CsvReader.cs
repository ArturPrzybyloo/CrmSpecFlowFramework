namespace CrmSpecFlowFramework.Helpers;
using Syroot.Windows.IO;
using System.IO;

    public class CsvReader
    {
    private readonly string _filePath = KnownFolders.Downloads.Path + "\\Report-Project Profitability.csv";
        public List<string> LoadCsvFile()
        {

        // Wait for file exists
        for (var i = 0; i < 30; i++)
            {
                if (File.Exists(_filePath)) { break; }
                Thread.Sleep(1000);
            }

            // Wait for file will save it's content
            var length = new FileInfo(_filePath).Length;
            for (var i = 0; i < 30; i++)
            {
                Thread.Sleep(1000);
                var newLength = new FileInfo(_filePath).Length;
                if (newLength == length && length != 0) { break; }
                length = newLength;
            }

            // Open file and return as string list
            var reader = new StreamReader(File.OpenRead(_filePath));
            List<string> searchList = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                searchList.Add(line);
            }
            reader.Close();
            return searchList;
        }

        public void DeleteCsvFile()
        {
            File.Delete(_filePath);
        }
    }
