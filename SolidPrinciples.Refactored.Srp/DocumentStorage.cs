using System.IO;

namespace SolidPrinciples.Refactored.Srp
{
    internal class DocumentStorage
    {
        internal void PersistDocument(string targetFileName, string serializedDoc)
        {
            using (var stream = File.Open(targetFileName, FileMode.Create, FileAccess.Write))
            using (var sw = new StreamWriter(stream))
            {
                sw.Write(serializedDoc);
                sw.Close();
            }
        }
    }
}