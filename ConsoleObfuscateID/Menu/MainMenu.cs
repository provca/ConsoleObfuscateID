using ConsoleObfuscateID.AEPD;
using ConsoleObfuscateID.AEPD.Enums;

namespace ConsoleObfuscateID.Menu
{
    internal class MainMenu
    {
        /// <summary>
        /// Starts the main menu loop, allowing the user to select document types and input document numbers for obfuscation.
        /// </summary>
        public static void StartMenu()
        {
            while (true)
            {
                Console.Clear();

                // Display menu options
                Console.WriteLine("This is a simple application to offer identity documents according to the AEPD recommendations.");
                Console.WriteLine("Visit these links for more info:\n-https://www.aepd.es/documento/guia-basica-anonimizacion.pdf\n-https://www.pdpc.gov.sg/help-and-resources/2018/01/basic-anonymisation\n");
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. DNI\t\texample: [12345678X]\t[***4567**]");
                Console.WriteLine("2. NIE\t\texample: [L1234567X]\t[****4567*]");
                Console.WriteLine("3. PASSPORT\texample: [ABC123456]\t[*****3456]");
                Console.WriteLine("4. ID Card\texample: [XY12345678AB]\t[*****4567***]");
                Console.WriteLine("5. Other\texample: [ABCD123XY]\t[*****23XY]");
                Console.WriteLine("Press 'q' to quit.");

                string? input = Console.ReadLine();

                // Check for exit condition
                if (input == "q" || input == "Q")
                {
                    Console.WriteLine("Program finished.");
                    break;
                }

                // Validate the user's input
                if (!int.TryParse(input, out int option) || option < 1 || option > 5)
                {
                    Console.WriteLine("Invalid option, please try again.");
                    Console.ReadLine();
                    continue;
                }

                // Get the selected document type
                string documentType = SelectAnOption(option);

                Console.WriteLine($"Selected option is: {documentType}");
                Console.Write("Insert your document number: ");
                string? document = Console.ReadLine();

                // Validate the document number input
                if (string.IsNullOrEmpty(document))
                {
                    Console.WriteLine("Document number cannot be empty, press any key.");
                    Console.ReadLine();
                    continue;
                }

                // Obfuscate the document number
                Utilities_CheckDocumentsID obfuscated = new(documentType);
                string result = obfuscated.ObfuscateDocumentID(document);

                // Display the result
                Console.WriteLine($"Obfuscated document is: {result}\n");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Returns the document type name based on the selected menu option.
        /// </summary>
        /// <param name="option">The menu option selected by the user.</param>
        /// <returns>The name of the document type.</returns>
        private static string SelectAnOption(int option)
        {
            return option switch
            {
                1 => nameof(IdentityDocument.DNI),
                2 => nameof(IdentityDocument.NIE),
                3 => nameof(IdentityDocument.PASSPORT),
                4 => nameof(IdentityDocument.IDCard),
                5 => nameof(IdentityDocument.NationalID),
                _ => string.Empty,
            };
        }
    }

}
