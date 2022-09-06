using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAutomapperTests.Helpers;
public static class ObjectToDictionaryHelper
{
    public static IDictionary<string, object> ToDictionary(this object source)
    {
        return source.ToDictionary<object>();
    }

    public static IDictionary<string, T> ToDictionary<T>(this object source)
    {
          var dictionary = new Dictionary<string, T>();
          foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
          {
              AddPropertyToDictionary<T>(property, source, dictionary);
          }
          return dictionary;
    }

    private static void AddPropertyToDictionary<T>(PropertyDescriptor property, object source, Dictionary<string, T> dictionary)
    {
        var value = property.GetValue(source) ?? throw new ArgumentNullException();
        if (IsOfType<T>(value))
        {
            dictionary.Add(property.Name, (T)value);
        }
       
    }

    private static bool IsOfType<T>(object value)
    {
        return value is T;
    }
}
