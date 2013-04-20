using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Processor.Entity.DataType
{
    public class Int32Converter : TypeConverter<int>, TestInterface
    {
        public string convertToStore(int item)
        {
            return item.ToString();
        }

        public int convertFromStore(string config)
        {
            return Convert.ToInt32(config);
        }


        public Type getType()
        {
            return typeof(int);
        }

        public string getTypeAsString()
        {
            return "int32";
        }
    }
}
