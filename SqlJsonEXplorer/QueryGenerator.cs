using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlJsonEXplorer
{
    public class QueryGenerator
    {
        public string GetQueryForTable(SchemaMetaTable schema)
        {
            var query = @"
            declare @dmfa varchar(max)
            select @dmfa = [Value] from Test

	        SELECT * FROM OPENJSON(@dmfa)
	        WITH ("

           ;
           var selectorQuery =  Generate(schema.Name, schema.Columns);
            return query + selectorQuery + ")";
        }

        private string Generate(string baseName, IList<string> properties)
        {
            StringBuilder query = new StringBuilder();
            var count = 0;
            foreach (var property in properties)
            { count++;
                var delimitStr = count == properties.Count ? "'" : "',";
                query.AppendLine(property+@" varchar(max)'$." + baseName + "." + property + delimitStr);
            }
            query = query.Remove(query.Length - 1, 1);
            return query.ToString();
        }
    }
}
