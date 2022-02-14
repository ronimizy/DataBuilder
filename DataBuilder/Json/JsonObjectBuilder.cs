using System;
using System.Text;
using DataBuilder.Extensions;

namespace DataBuilder.Json
{
    internal class JsonObjectBuilder : IObjectBuilder
    {
        private readonly int _indentation;
        private readonly StringBuilder _builder;
        private bool _disposed;
        private bool _propertyAdded;

        public JsonObjectBuilder(StringBuilder builder, int indentation = 0)
        {
            _disposed = false;
            _propertyAdded = false;
            _indentation = indentation;
            _builder = builder;

            builder.AppendLine("{");
        }

        public void Dispose()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(IObjectBuilder));

            _builder.AppendLine();
            _builder.Append('\t', _indentation);
            _builder.Append('}');
            _disposed = true;
        }

        public void AddValueProperty<T>(string name, T value)
        {
            AddPropertyName(name);
            _builder.Append(value.ToJsonString());
        }

        public IObjectBuilder AddObjectProperty(string name)
        {
            AddPropertyName(name);
            return new JsonObjectBuilder(_builder, _indentation + 1);
        }

        public IArrayBuilder AddArrayProperty(string name)
        {
            AddPropertyName(name);
            return new JsonArrayBuilder(_builder, _indentation + 1);
        }

        private void AddPropertyName(string name)
        {
            if (_propertyAdded)
                _builder.AppendLine(",");

            _builder.Append('\t', _indentation + 1);
            _builder.Append($"\"{name}\" : ");
            _propertyAdded = true;
        }
    }
}