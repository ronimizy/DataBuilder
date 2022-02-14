# DataBuilder [![Nuget](https://img.shields.io/nuget/v/DataBuilder?style=flat-square)](https://www.nuget.org/packages/DataBuilder/1.0.0)

A DataBuilder (JSON) abstraction utilising Disposable pattern.

## Pros
- `using` scopes indentation for clearer distinction between generated objects
- Auto-closing objects

## Cons
- An `IDisposable` clusterf*ck

Just a silly idea implemented for fun :)

## [Example](DataBuilder.Sample/Program.cs)

### Code

```cs
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
```

### Output
```json
{
    "prop" : 12,
    "prop" : 12.5,
    "prop" : "adadad",
    "arr" : [
        12000000000000,
        12.443
    ]
}

```