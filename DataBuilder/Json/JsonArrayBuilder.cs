using System;
using System.Text;
using DataBuilder.Extensions;

namespace DataBuilder.Json
{
    internal class JsonArrayBuilder : IArrayBuilder
    {
        private readonly int _indentation;
        private readonly StringBuilder _builder;
        private bool _disposed;
        private bool _valueAdded;

        public JsonArrayBuilder(StringBuilder builder, int indentation = 0)
        {
            _disposed = false;
            _valueAdded = false;
            _indentation = indentation;
            _builder = builder;

            builder.AppendLine("[");
        }

        public void Dispose()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(IArrayBuilder));

            _builder.AppendLine();
            _builder.Append('\t', _indentation);
            _builder.Append(']');
        }

        public void AddValue<T>(T value)
        {
            Print();
            _builder.Append(value.ToJsonString());
        }

        public IObjectBuilder AddObject()
        {
            Print();
            return new JsonObjectBuilder(_builder, _indentation + 1);
        }

        public IArrayBuilder AddArray()
        {
            Print();
            return new JsonArrayBuilder(_builder, _indentation + 1);
        }

        public void Print()
        {
            if (_valueAdded)
                _builder.AppendLine(",");

            _builder.Append('\t', _indentation + 1);
            _valueAdded = true;
        }
    }
}