namespace ConsoleObfuscateID.AEPD.Enums
{/// <summary>
 /// Enum representing different types of identity documents.
 /// </summary>
    public enum IdentityDocument
    {
        /// <summary>
        /// Documento Nacional de Identidad (DNI).
        /// Example: DNI 12345678X => ***4567**.
        /// </summary>
        DNI,

        /// <summary>
        /// Número de Identificación de Extranjero (NIE).
        /// Example: NIE L1234567X => ****4567*.
        /// </summary>
        NIE,

        /// <summary>
        /// Passport number.
        /// Example: Passport ABC123456 => (NO ALPHABET) *****3456.
        /// </summary>
        PASSPORT,

        /// <summary>
        /// ID Card.
        /// Example: Identity Document XY12345678AB => *****4567***.
        /// </summary>
        IDCard,

        /// <summary>
        /// Another type of Identity Document.
        /// Example: Identity Document ABCD123XY => *****23XY.
        /// </summary>
        NationalID
    }
}
