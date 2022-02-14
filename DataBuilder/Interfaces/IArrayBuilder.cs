using System;

// ReSharper disable once CheckNamespace
namespace DataBuilder
{
    public interface IArrayBuilder : IDisposable, IDataVisitor
    {
        void AddValue<T>(T value);
        IObjectBuilder AddObject();
        IArrayBuilder AddArray();
    }
}