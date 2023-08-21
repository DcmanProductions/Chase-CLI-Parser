# Chase CLI Parser Documentation

## Introduction

The Chase CLI Parser library is a lightweight command-line argument parsing tool for .NET applications. It simplifies the process of parsing command-line arguments and provides an easy-to-use interface for defining and handling command-line options.

This documentation will guide you through using the Chase CLI Parser library to define and parse command-line arguments in your .NET application.

## Installation

Before you can start using the Chase CLI Parser library, you need to include it in your .NET project. You can do this by adding a reference to the Chase CLIParser.dll assembly in your project.

### Using NuGet Package Manager

You can also install the Chase CLI Parser library using NuGet Package Manager:

```shell
Install-Package Chase-CLI-Parser
```

## Usage

### Initializing the OptionsManager

To get started with Chase CLI Parser, you first need to create an `OptionsManager` object to define the command-line options that your application will accept.

```csharp
OptionsManager manager = new OptionsManager("Chase CLI Parser");
```

### Adding Command-Line Options

You can add command-line options to the `OptionsManager` using the `Add` method. Each option is defined by an `OptionDefinition` object, which specifies its short name, long name, whether it has an argument, whether it is required, and a description.

```csharp
manager.Add(new OptionDefinition()
{
    ShortName = "i",
    LongName = "input",
    HasArgument = true,
    Required = true,
    Description = "The input file."
});

manager.Add(new OptionDefinition()
{
    ShortName = "o",
    LongName = "output",
    HasArgument = true,
    Required = true,
    Description = "The output file."
});

manager.Add(new OptionDefinition()
{
    ShortName = "c",
    LongName = "continue",
    HasArgument = false,
    Required = false,
    Description = "Continue the application."
});

manager.Add(new OptionDefinition()
{
    ShortName = "cc",
    LongName = "connections",
    HasArgument = true,
    Required = false,
    Description = "The number of connections of the application."
});
```

### Parsing Command-Line Arguments

Once you've defined your command-line options, you can use the `OptionsParser` to parse the command-line arguments passed to your application.

```csharp
OptionsParser parser = manager.Parse(Environment.GetCommandLineArgs());
```

### Checking for Option Presence

You can check if a specific option is present in the parsed arguments using the `IsPresent` method of the `OptionsParser`. It also allows you to retrieve the value of an option with an argument.

```csharp
if (parser.IsPresent("i", out string input))
{
    Console.WriteLine($"Input file is {input}");
}

if (parser.IsPresent("o", out string output))
{
    Console.WriteLine($"Output file is {output}");
}

if (parser.IsPresent("c"))
{
    Console.WriteLine("Continue is enabled");
}
else
{
    Console.WriteLine("Continue is disabled");
}

if (parser.IsPresent("cc", out string connections))
{
    Console.WriteLine($"Connections set to {connections}");
}
else
{
    Console.WriteLine($"Connections set to 6");
}
```

## Example

Here's an example of how you can use Chase CLI Parser in your .NET application:

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        OptionsManager manager = new OptionsManager("Chase CLI Parser");

        // Define command-line options here

        OptionsParser parser = manager.Parse(args);

        if (parser.IsPresent("i", out string input))
        {
            Console.WriteLine($"Input file is {input}");
        }

        // Check other options here

        // Your application logic goes here
    }
}
```

## Conclusion

The Chase CLI Parser library simplifies the process of parsing command-line arguments in your .NET application. By defining and parsing options using the `OptionsManager` and `OptionsParser`, you can easily handle command-line arguments and build more user-friendly command-line interfaces for your applications.