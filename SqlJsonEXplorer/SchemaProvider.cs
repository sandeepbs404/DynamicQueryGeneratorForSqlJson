using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace SqlJsonEXplorer
{
    public class SchemaProvider
    {
        public IList<SchemaMetaTable> GetSchemas()
        {
            return new List<SchemaMetaTable>()
            {
                new SchemaMetaTable
                {
                    Name = "Form",
                    Columns = new List<string>{ "Identification", "FormCreationDate", "FormCreationHour", "AttestationStatus", "TypeForm","FileName" },
                    Relations = new List<string>(),
                    Keys = new List<string>{}
                },
                 new SchemaMetaTable
                {
                    Name = "Reference",
                    Columns = new List<string>{ "ReferenceType", "ReferenceOrigin", "ReferenceNbr" },
                    Relations = new List<string>(),
                    Keys = new List<string>()
                },
                 new SchemaMetaTable
                {
                    Name = "EmployerDeclaration",
                    Columns = new List<string>{ "Quarter", "NOSSRegistrationNbr", "Trusteeship", "CompanyID", "NetOwedAmount", "System5","HolidayStartingDate", },
                    Relations = new List<string>{"Form" },
                    Keys = new List<string>{"Quarter", "NOSSRegistrationNbr", "CompanyID", "Quarter" }
                },
                 new SchemaMetaTable
                {
                    Name = "NaturalPerson",
                    Columns = new List<string>{ "NaturalPersonSequenceNbr", "INSS", "SIS", "WorkerName", "WorkerFirstName", "WorkerInitial"
                    , "WorkerBirthdate","WorkerBirthplaceCountry", "WorkerSex", "WorkerStreet", "WorkerHouseNbr", "WorkerPostBox", "WorkerZIPCode", "WorkerCity", "WorkerCountry", "Nationality", "NaturalPersonUserReference" },
                    Relations = new List<string>{"EmployerDeclaration" },
                    Keys = new List<string>{ "INSS" }
                }
            };
        }

        public object ExecuteQuery(string query)
        {
            List<object> objects = new List<object>();
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                objects = db.Query(query).AsList<object>();                
            }

            return objects;
        }
    }
}
