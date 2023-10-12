using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo
{
    public class ClassHelper
    {
        public static string GetPropertiesAndValues(object obj, int indentLevel = 0)
        {
            if (obj == null)
                return string.Empty;

            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            StringBuilder result = new StringBuilder();

            string className = type.Name;
            string indentation = new string(' ', indentLevel * 2);
            result.AppendLine($"{indentation}{className} (ClassName)");
            result.AppendLine($"{indentation}---------");

            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(obj);

                if (property.PropertyType.IsPrimitive || property.PropertyType == typeof(string))
                {
                    result.AppendLine($"{indentation}{property.Name} = {value}");
                }
                else if (value is IEnumerable enumerable)
                {
                    result.AppendLine($"{indentation}{property.PropertyType.Name} =>");
                    int index = 1;
                    foreach (var item in enumerable)
                    {
                        result.AppendLine($"{indentation}  {index}:");

                        string itemString = GetPropertiesAndValues(item, indentLevel + 1);
                        result.AppendLine(itemString);
                        index++;
                    }
                }
                else
                {
                    result.AppendLine($"{indentation}{property.Name} =>");
                    result.Append(GetPropertiesAndValues(value, indentLevel + 1).TrimEnd());
                }
            }

            return result.ToString();
        }
    }

}
