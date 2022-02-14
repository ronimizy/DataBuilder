// See https://aka.ms/new-console-template for more information

using System.Text;
using DataBuilder.Json;

var sb = new StringBuilder();
var jsonBuilder = new JsonDataBuilder();

using (var obj = jsonBuilder.BuildObject(sb))
{
    obj.AddValueProperty("prop", 12);
    obj.AddValueProperty("prop", 12.5);
    obj.AddValueProperty("prop", "adadad");
    using (var arr = obj.AddArrayProperty("arr"))
    {
        arr.AddValue(12e12);
        arr.AddValue(12.443);
    }
}

Console.WriteLine(sb.ToString());