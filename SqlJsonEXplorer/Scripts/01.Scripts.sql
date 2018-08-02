
/****** Object:  Table [dbo].[Test]    Script Date: 02-08-2018 06:25:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Test](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Value] [varchar](max) NULL,
 CONSTRAINT [PK_Test] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


INSERT INTO [dbo].[Test]
           ([Name]
           ,[Value])
     VALUES
           ('Test'
           ,'{
   "@noNamespaceSchemaLocation": "DmfAOriginal_20174.xsd",
   "Form": {
      "Identification": "DMFA",
      "FormCreationDate": "2018-01-26",
      "FormCreationHour": "20:08:18.834",
      "AttestationStatus": "0",
      "TypeForm": "SU",
      "Reference": {
         "ReferenceType": "1",
         "ReferenceOrigin": "1",
         "ReferenceNbr": "20180126.00057"
      },
      "EmployerDeclaration": {
         "Quarter": "20174",
         "NOSSRegistrationNbr": "174566534",
         "Trusteeship": "0",
         "CompanyID": "0476286826",
         "NetOwedAmount": "000000005273403",
         "System5": "0",
         "HolidayStartingDate": "2018-06-01",
         "NaturalPerson": [
            {
               "NaturalPersonSequenceNbr": "0000001",
               "INSS": "58090740782",
               "NaturalPersonUserReference": "XAZ1AY4072VP6     N2"
            }]
		}
	}
}');



