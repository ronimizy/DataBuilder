using System.Text;

// ReSharper disable once CheckNamespace
namespace DataBuilder
{
    public interface IDataBuilder
    {
        IArrayBuilder BuildArray(StringBuilder stringBuilder, int indentationLevel = 0);

        IObjectBuilder BuildObject(StringBuilder stringBuilder, int indentationLevel = 0);
    }
}