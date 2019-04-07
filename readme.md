# Morts StringExtensions

When validating input, or checking config settings loaded from files, i often find my self writing an extension method for validating the strings i load.

In this repo, and its associated nuget package, you will find three groups of extension methods
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
