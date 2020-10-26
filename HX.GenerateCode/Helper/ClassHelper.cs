using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HX.GenerateCode.Helper
{
    public static class ClassHelper
    {
        public static string GetClassName(this string procedureName)
        {
            var splitName = procedureName.Split('_');
            var className = "{0}Result";
            if (string.IsNullOrWhiteSpace(procedureName))
            {
                return string.Empty;
            }
            else if (procedureName.Length == 1)
            {
                return string.Format(className, procedureName.ToUpper());
            }
            else
            {
                if (splitName.Length > 0)
                {
                    var name = new StringBuilder();
                    foreach (var item in splitName)
                    {
                        if (item.Length > 0)
                        {
                            name.Append(char.ToUpper(item[0]) + item.Substring(1));
                        }
                    }

                    return string.Format(className, name.ToString());
                }
                else
                {
                    return string.Format(className, char.ToUpper(procedureName[0]) + procedureName.Substring(1));
                }
            }
        }

        public static List<string> GetFieldsFromDataTable(this DataTable dataTable)
        {
            var fields = new List<string>();
            foreach (DataColumn dataColumn in dataTable.Columns)
            {
                var ttype = dataColumn.DataType.Name.ToLower();

                if (ttype.Contains("guid"))
                {
                    ttype = "Guid?";
                }
                else if (ttype.Contains("uint"))
                {
                    ttype = "short?";
                }
                else if (ttype.Contains("int"))
                {
                    ttype = "int?";
                }
                else if (ttype == "datetime")
                {
                    ttype = "DateTime?";
                }
                else if (ttype != "string")
                {
                    ttype += "?";
                }

                fields.Add("public " + ttype + " " + dataColumn.ColumnName + " { get; set; }");
            }

            return fields;
        }
    }
}
