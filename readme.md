# Morts StringExtensions

When validating input, or checking config settings loaded from files, i often find my self writing an extension method for validating the strings i load.

In this repo, and its associated nuget package, you will find three groups of extension methods and a struct

## Extension methods
* Checking extensions   
     **IsNullEmptyOrWhitespace**   
     This does exactly the same as *string.IsNullOrWhitespace*, except nearly twice as fast.   
     The build in method looks at one char at the time, my implementation looks at the beginning and the end at the same time, and works it self towards the middle.
* Throwing extensions   
     **ThrowIfNullEmptyOrWhitespace**   
     This method throws instead of returning a bool
* Return or throw extensions.
      **ReturnOrThrowIfNullEmptyOrWhitespace**   
      This method will return the string, if it is not null, empty or whitespace. Otherwise it will throw

## Struct
### ValidString
Use this struct instead of a string where you would usually take a string as an argument   
this will automatically ensure that the string is never null, empty or whitespace.

```csharp
namespace Morts.StringExtensions.Examples
{
    internal class ImportantClass
    {
        public string Input { get; }

        public ImportantClass(ValueString input)
        {
            Input = input;
        }
    }

    public class EdgeOfPackageOrAppApi
    {
        public bool TakesExternalInput(string someInput)
        {
            try
            {
                var importantClass = new ImportantClass(someInput);

                _service.ThatCanBreak(importantClass);

                return true;
            }
            catch (Exception)
            {
                // ErrorHandling here
                throw; // Or return something
            }
        }
    }
}
```