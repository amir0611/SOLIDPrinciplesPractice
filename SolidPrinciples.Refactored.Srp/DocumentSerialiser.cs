using Newtonsoft.Json;

namespace SolidPrinciples.Refactored.Srp
{
    internal class DocumentSerialiser
    {
        internal string Serialise(Document doc)
        {
            return JsonConvert.SerializeObject(doc);
        }
    }
}