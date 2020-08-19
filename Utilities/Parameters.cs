namespace Utilities
{
    public class Parameters
    {
        public string CamelCaseName;
        public string LowerCamelCaseName;
        public string DashName;
        public string TitleCaseName;
        public Column[] DbColumns;
    }

    public class Column {
        public string ColumnName;
        public string DataType;
	}
}
