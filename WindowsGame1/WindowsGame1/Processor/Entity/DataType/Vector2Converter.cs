using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Processor.Entity.DataType
{
    public  class Vector2Converter : TypeConverter<Vector2>
    {
        public string convertToStore(Vector2 item)
        {
            return getTypeAsString() + "(" + item.X.ToString() + "," + item.Y.ToString() + ")";
        }

        public Vector2 convertFromStore(string config)
        {
            config = config.TrimStart(getTypeAsString().ToCharArray());
            config = config.TrimEnd(')');
            config = config.TrimStart('(');
            String[] xy = config.Split(',');
            float x = Convert.ToSingle(xy[0]);
            float y = Convert.ToSingle(xy[1]);
            return new Vector2(x, y);
        }

        public Type getType()
        {
            return typeof(Vector2);
        }

        public string getTypeAsString()
        {
            return "Vector2";
        }
    }
}
