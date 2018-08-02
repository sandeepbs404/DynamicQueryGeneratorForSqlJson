using System.Collections.Generic;

namespace SqlJsonEXplorer
{
    public class SchemaMetaTable
    {
        public string Name;
        public IList<string> Columns;
        public IList<string> Keys;
        public IList<string> Relations;
        public SchemaMetaTable()
        {
            Columns = new List<string>();
            Keys = new List<string>();
            Relations = new List<string>();
        }
    }
}
