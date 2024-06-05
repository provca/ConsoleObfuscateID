using ConsoleObfuscateID.AEPD.Enums;
using System.Text;

namespace ConsoleObfuscateID.AEPD
{
    /// <summary>
    /// Utility class for checking and obfuscating document IDs.
    /// </summary>
    public class Utilities_CheckDocumentsID
    {
        private int _start = 0;
        private int _end = 0;
        private int _length = 9;

        /// <summary>
        /// Initializes a new instance of the <see cref="Utilities_CheckDocumentsID"/> class with the specified document type.
        /// </summary>
        /// <param name="documentType">The type of document for which to perform checks.</param>
        public Utilities_CheckDocumentsID(string documentType)
        {
            // Initialize the object with the specified document type.
            SetDocumentType(documentType);
        }

        /// <summary>
        /// Obfuscates the specified raw document ID.
        /// </summary>
        /// <param name="rawDocument">The raw document ID to obfuscate.</param>
        /// <returns>The obfuscated document ID if it has the correct lenght otherwise returns the raw document.</returns>
        public string ObfuscateDocumentID(string rawDocument)
        {
            StringBuilder sb = new(ClearDocument(rawDocument));

            if (sb.Length == _length)
            {
                for (int i = 0; i < _length; i++)
                {
                    if (i < _start || i > _end)
                        sb[i] = '*';
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Cleans the raw document string by trimming whitespace, converting to uppercase, and removing dashes and spaces.
        /// </summary>
        /// <param name="rawDocument">The raw document ID to clean.</param>
        private static string ClearDocument(string rawDocument) => rawDocument.Trim().ToUpper().Replace("-", string.Empty).Replace(" ", string.Empty);

        /// <summary>
        /// Sets the document type and updates the start, end, and length based on the specified document type.
        /// </summary>
        /// <param name="documentType">The type of the document.</param>
        /// <exception cref="ArgumentException">Thrown when the document type is invalid.</exception>
        private void SetDocumentType(string documentType)
        {
            switch (documentType)
            {
                // Set the start, end, and length based on the document type.
                case nameof(IdentityDocument.DNI):
                    _start = 3;
                    _end = 6;
                    break;
                case nameof(IdentityDocument.NIE):
                    _start = 4;
                    _end = 7;
                    break;
                case nameof(IdentityDocument.PASSPORT):
                case nameof(IdentityDocument.IDCard):
                case nameof(IdentityDocument.NationalID):
                    _start = 5;
                    _end = 8;
                    _length = documentType == nameof(IdentityDocument.IDCard) ? 12 : _length;
                    break;
                default:
                    throw new ArgumentException("Invalid document type.");
            }
        }
    }
}
