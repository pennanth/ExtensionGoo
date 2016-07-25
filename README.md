#Extension Goo

    PM> Install-Package ExtensionGoo

ExtensionGoo is a set of simple extensions to make common but perhaps non-trivial tasks easier. Sometimes you write simple programs where the boiler plate code to download or deserialise things is larger than the actual "real" code!

It's designed to remove complexity from smaller or simple programs such as Azure Functions.


###Simple Examples

Note: The Nuget package supports PCL and .NET Standard packages. 

Once the Nuget is installed you can start calling extension methods!

Make sure you include the usings first or the extensions may not show up.
```C#
using ExtensionGoo.Standard.Extensions;

```

####Serialise and Deserilise things (or ize)

To serialise something:
```C#
 var testClass = new TestSerClass
 {
     Name = "Jordan",
     Age = 21
 };

 var result = testClass.Serialise();

```

	{"Name":"Jordan","Age":21}

To go back the other way:

```C#
var data = "{\"Name\":\"Jordan\",\"Age\":21}".DeSerialise<TestSerClass>();

```

Note that I put the extension method straight on the string in quotes, it will also work from a regular string variable. 

####Post and download and things

Download a URL to a string: 

```c#
var result = await "http://www.xamling.net".GetRaw();
```

Parse the content of a URL in to an entity: 

```c#
var url = "http://jsonplaceholder.typicode.com/posts/1";

var obj = await url.GetAndParse<TestEntity>();

```

Post an entity and get result

```c#
var sampleUp = new SomeUploadEntity();

var downloadResult = await url.PostAndParse<SomeResultEntity, SomeUploadEntity>(sampleData);

```