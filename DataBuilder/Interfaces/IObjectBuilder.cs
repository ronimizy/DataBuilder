using System;

// ReSharper disable once CheckNamespace
namespace DataBuilder
{
    public interface IObjectBuilder : IDisposable, IDataVisitor
    {
        void AddValueProperty<T>(string name, T value);
        IObjectBuilder AddObjectProperty(string name);
        IArrayBuilder AddArrayProperty(string name);
    }
}