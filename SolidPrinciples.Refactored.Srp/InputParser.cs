using System.Xml.Linq;

namespace SolidPrinciples.Refactored.Srp
{
    internal class InputParser
    {
        internal Document Parse(string input)
        {
            var xdoc = XDocument.Parse(input);
            var doc = new Document
            {
                Title = xdoc.Root.Element("title").Value,
                Text = xdoc.Root.Element("text").Value
            };
            return doc;
        }
    }
}