using System.IO;

namespace Infrastructure.Helpers
{
    public static class FileHelper
    {
        public static StreamReader ReadFromFile(string filePath)
        {
            var path = Directory.GetCurrentDirectory() + filePath;

            FileStream fileStream = new FileStream(path, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }
    }
}
