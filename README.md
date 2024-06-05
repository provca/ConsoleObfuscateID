# ConsoleObfuscateID
Net 8.0 library that enables the anonymization of identification numbers according to the recommendations of the Spanish Data Protection Agency (AEPD).

## Detailed Description
The AEPD has provided criteria to follow for anonymizing the DNI (National Identity Document) or equivalent document in public administrations. These criteria can also be used by data controllers or processors in private entities.

When it is necessary to include the DNI or an equivalent identification document in publications, it should be anonymized as follows:

The digits occupying the fourth, fifth, sixth, and seventh positions of the document format (numbered from left to right) will be published, and alphabetical characters will be omitted.
Alphabetical characters and numerical digits not selected for publication will be replaced with an asterisk (*) in each position.

Examples:
+ For a DNI 12345678X, it will be published as +++4567++.
+ For an NIE L1234567X, since alphabetical characters are omitted, it will be published as ++++4567+.
+ For a Passport ABC123456, since alphabetical characters are omitted and there are only six digits, it will be published as ++++++3456.
+ For an Identification Document XY12345678AB, it will be published as +++++4567+++.
+ For an Identification Document ABCD123XY, the publication would be +++++23XY.

## Files System Structure of library
```
ObfuscateID/
└── AEPD/
    ├── Enums/
    │   └── IdentityDocument.cs
    │
    └── Utilities_CheckDocumentsID.cs
```
## Files System Structure of App
```
ConsoleObfuscateID/
└── AEPD/
│   ├── Enums/
│   │   └── IdentityDocument.cs
│   │
│   ├── Utilities_CheckDocumentsID.cs
│   │
│   └── Menu/
│       └── MainMenu.cs
|
└── Program.cs
```
## Implementation
You only need to use the AEPD folder in your project.
All identification options are in the enum `Enum/IdentityDocument.cs`.
All parameterizations of the identification options are found in the class `Utilities_CheckDocumentsID.cs`.

If you need to add more identification options, you should:
+ Add the option in `IdentityDocument.cs`.
+ Add the case in the method `SetDocumentType(string)` of the class `Utilities_CheckDocumentsID.cs`.
+  Add the parameterization (if necessary) in `SetDocumentType(string)`.

## Example
```
string documentType = nameof(IdentityDocument.DNI);
string document = "12345678A";
Utilities_CheckDocumentsID obfuscated = new(documentType);
string result = obfuscated.ObfuscateDocumentID(document);
```

> [!TIP]
> `Utilities_CheckDocumentsID.cs` class adds `ClearDocument(string)` to clean the raw document string by trimming whitespace, converting to uppercase, and removing dashes and spaces.






