using System.IO;

namespace SolidPrinciples.Refactored.Ocp
{
    internal class DocumentReader
    {
        internal string Read(string sourceFileName)
        {
            string input;
            using (var stream = File.OpenRead(sourceFileName))
            using (var reader = new StreamReader(stream))
            {
                input = reader.ReadToEnd();
            }

            return input;
        }
    }
}