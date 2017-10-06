using System;
using System.IO;

namespace SolidPrinciples.Refactored.Srp
{
    internal class FormatConverter
    {
        private readonly DocumentReader myDocumentReader;
        private readonly InputParser myInputParser;
        private readonly DocumentSerialiser myDocumentSerialiser;
        private readonly DocumentStorage myDocumentStorage;

        public FormatConverter()
        {
            myDocumentReader = new DocumentReader();
            myInputParser = new InputParser();
            myDocumentSerialiser = new DocumentSerialiser();
            myDocumentStorage = new DocumentStorage();
        }

        internal bool ConvertFormat(string sourceFileName, string targetFileName)
        {
            string input;
            try
            {
                input = myDocumentReader.Read(sourceFileName);
            }
            catch (FileNotFoundException)
            {
                return false;
            }

            var doc = myInputParser.Parse(input);
            var serializedDoc = myDocumentSerialiser.Serialise(doc);

            try
            {
                myDocumentStorage.PersistDocument(serializedDoc, targetFileName);
            }
            catch (AccessViolationException)
            {
                return false;
            }

            return true;
        }
    }
}