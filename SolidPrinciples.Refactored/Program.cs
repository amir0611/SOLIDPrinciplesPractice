using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml.Linq;

namespace SolidPrinciples.Refactored
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Input Documents\\Document1.xml");
            var targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Output Documents\\Document1.json");

            string input = GetInput(sourceFileName);
            Document doc = GetDocument(input);
            string serializedDoc = SerialiseDocumentObject(doc);

            PersistDocument(targetFileName, serializedDoc);
        }

        private static void PersistDocument(string targetFileName, string serializedDoc)
        {
            using (var stream = File.Open(targetFileName, FileMode.Create, FileAccess.Write))
            using (var sw = new StreamWriter(stream))
            {
                sw.Write(serializedDoc);
                sw.Close();
            }
        }

        private static string SerialiseDocumentObject(Document doc)
        {
            return JsonConvert.SerializeObject(doc);
        }

        private static Document GetDocument(string input)
        {
            var xdoc = XDocument.Parse(input);
            var doc = new Document
            {
                Title = xdoc.Root.Element("title").Value,
                Text = xdoc.Root.Element("text").Value
            };
            return doc;
        }

        private static string GetInput(string sourceFileName)
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
