using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SolidPrinciples.Refactored.Ocp
{
    internal interface IDocumentSerialiser
    {
        string Serialise(Document document);
    }
    internal class JsonDocumentSerialiser : IDocumentSerialiser
    {
        public string Serialise(Document document)
        {
            return JsonConvert.SerializeObject(document);
        }
    }

    internal class CamelCaseJsonSerializer : IDocumentSerialiser
    {
        public string Serialise(Document document)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            return JsonConvert.SerializeObject(document, settings);
        }
    }
}