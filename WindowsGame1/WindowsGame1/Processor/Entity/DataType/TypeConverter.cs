using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Processor.Entity.DataType
{
    public interface ITypeConverter 
    {
        Type getType();
        String getTypeAsString();
    }

    public interface TypeConverter<T> : ITypeConverter
    {
        String convertToStore(T item);
        T convertFromStore(String config);
    }
}
