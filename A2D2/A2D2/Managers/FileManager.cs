using System.IO;

namespace A2D2
{
    static class FileManager
    {
        public static void Write(string message, string path)
        {
            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(message);
            }
        }

        public static byte[] ReadWav(string path)
        {
            return File.ReadAllBytes(path);
        }
    }
}
