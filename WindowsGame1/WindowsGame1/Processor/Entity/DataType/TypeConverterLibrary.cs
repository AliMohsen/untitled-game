using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace TheGameOfForever.Processor.Entity.DataType
{
    public class TypeConverterLibrary
    {
        private static Dictionary<Type, ITypeConverter> types = new Dictionary<Type, ITypeConverter>();

        public static void addTypeConverter<T>(TypeConverter<T> converter)
        {
           types.Add(converter.getType(), converter);
        }

        public static TypeConverter<T> getTypeConverter<T>()
        {
            return (TypeConverter<T>) types[typeof(T)];
        }

        private static Type[] getTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes()
                .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
        }

        public static void instantiate()
        {
            Type[] typesInNameSpace = getTypesInNamespace(Assembly.GetExecutingAssembly(), 
                typeof(TypeConverterLibrary).Namespace);
            for (int i = 0; i < typesInNameSpace.Length; i++)
            {
                //typesInNameSpace[i].IsAssignableFrom(typeof(ITypeConverter)) &&
                if (!typesInNameSpace[i].IsInterface && !typesInNameSpace[i].Equals(typeof(TypeConverterLibrary))
                    && Attribute.GetCustomAttribute(typesInNameSpace[i], 
                    typeof(CompilerGeneratedAttribute)) == null)
                {
                    ITypeConverter typeConverter = (ITypeConverter) Activator.CreateInstance(typesInNameSpace[i]);
                    Type genericType = typeConverter.getType();
                    typeof(TypeConverterLibrary).GetMethod("addTypeConverter").MakeGenericMethod(genericType)
                        .Invoke(null, new object[] { Activator.CreateInstance(typesInNameSpace[i]) });
                }
            }

        }

    }
}
