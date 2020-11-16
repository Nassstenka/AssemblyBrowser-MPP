using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp
{
    public class ConvertNames
    {
        public static string GetTypeName(Type type)
        {
            string typeName = type.Name;
            if (type.IsGenericType)
            {
                typeName = typeName.Remove(typeName.IndexOf('`'));
                typeName += "<";
                Type[] genericArgs = type.GetGenericArguments();
                foreach (Type arg in genericArgs)
                {
                    typeName += GetTypeName(arg) + ",";
                }
                if (genericArgs.Length > 0)
                {
                    typeName = typeName.Remove(typeName.LastIndexOf(","));
                }
                typeName += ">";
            }
            return typeName;
        }
    }
    public class TypeConverter : IValueConverter
    {
        public object Convert(object obj, Type type, object param, CultureInfo culture)
        {
            Type typeInfo = (Type)obj;
            string result = "";
            if (typeInfo.IsPublic)
            {
                result += "public ";
            }
            else
            {
                result += "private ";
            }
            if (typeInfo.IsAbstract)
            {
                result += "abstract ";
            }
            if (typeInfo.IsSealed)
            {
                result += "sealed ";
            }
            if (typeInfo.IsClass)
            {
                result += "class ";
            }
            if (typeInfo.IsInterface)
            {
                result += "interface ";
            }
            result += ConvertNames.GetTypeName(type);
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Windows.DependencyProperty.UnsetValue;
        }
    }

    public class FieldConverter : IValueConverter
    {
        public object Convert(object obj, Type targetType, object param, CultureInfo culture)
        {
            string result = "";
            FieldInfo fieldInfo = (FieldInfo)obj;
            if (fieldInfo.IsPublic)
            {
                result += "public ";
            }
            else
            {
                result += "private ";
            }
            if (fieldInfo.IsStatic)
            {
                result += "static ";
            }
            result += ConvertNames.GetTypeName(fieldInfo.FieldType) + " " + fieldInfo.Name;
            return result;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Windows.DependencyProperty.UnsetValue;
        }
    }

    public class PropertyConverter : IValueConverter
    {
        public object Convert(object obj, Type targetType, object param, CultureInfo culture)
        {
            string result = "";
            PropertyInfo propertyInfo = (PropertyInfo)obj;
            result += ConvertNames.GetTypeName(propertyInfo.PropertyType) + " " + propertyInfo.Name;
            return result;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Windows.DependencyProperty.UnsetValue;
        }
    }
    public class ConvertMethod : IValueConverter
    {
        public object Convert(object obj, Type targetType, object param, CultureInfo culture)
        {
            MethodInfo methodInfo = (MethodInfo)obj;
            string result = "";
            if (methodInfo.IsPublic)
            {
                result += "public ";
            }
            else
            {
                result += "private ";
            }

            if (methodInfo.IsStatic)
            {
                result += "static ";
            }
            if (methodInfo.IsAbstract)
            {
                result += "abstract ";
            }
            if (methodInfo.IsVirtual)
            {
                result += "virtual ";
            }
            result += ConvertNames.GetTypeName(methodInfo.ReturnType) + " " + methodInfo.Name;
            result += "(";
            ParameterInfo[] parameters = methodInfo.GetParameters();
            foreach (ParameterInfo parameter in parameters)
            {
                result += ConvertNames.GetTypeName(parameter.ParameterType) + " " + parameter.Name + ",";
            }
            if (parameters.Length > 0)
            {
                result = result.Remove(result.LastIndexOf(","));
            }
            result += ")";
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Windows.DependencyProperty.UnsetValue;
        }
    }
}
