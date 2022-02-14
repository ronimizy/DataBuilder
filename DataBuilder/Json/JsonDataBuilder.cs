using System;
using System.Text;

namespace DataBuilder.Json
{
    public class JsonDataBuilder : IDataBuilder
    {
        public IArrayBuilder BuildArray(StringBuilder stringBuilder, int indentationLevel = 0)
        {
            if (indentationLevel < 0)
                throw new ArgumentException(nameof(indentationLevel));

            return new JsonArrayBuilder(stringBuilder, indentationLevel);
        }

        public IObjectBuilder BuildObject(StringBuilder stringBuilder, int indentationLevel = 0)
        {
            if (indentationLevel < 0)
                throw new ArgumentException(nameof(indentationLevel));

            return new JsonObjectBuilder(stringBuilder, indentationLevel);
        }
    }
}