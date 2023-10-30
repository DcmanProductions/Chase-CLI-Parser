# cclip.net Documentation

## Introduction

The cclip.net (C# Command Line Interface Parser for .NET) library is a lightweight command-line argument parsing tool for .NET applications. It simplifies the process of parsing command-line arguments and provides an easy-to-use interface for defining and handling command-line options.

This documentation will guide you through using the cclip.net library to define and parse command-line arguments in your .NET application.

## Installation

Before you can start using the cclip.net library, you need to include it in your .NET project. You can do this by adding a reference to the Chase ccliparser.dll assembly in your project.

### Using NuGet Package Manager

You can also install the cclip.net library using NuGet Package Manager:

```shell
Install-Package cclip.net
```

## Usage

### Initializing the OptionsManager

To get started with cclip.net, you first need to create an `OptionsManager` object to define the command-line options that your application will accept.

```csharp
OptionsManager manager = new OptionsManager("cclip.net");
```

### Adding Command-Line Options

You can add command-line options to the `OptionsManager` using the `Add` method. Each option is defined by an `Option` object, which specifies its short name, long name, whether it has an argument, whether it is required, and a description.

```csharp
manager.Add(new Option()
{
    ShortName = "i",
    LongName = "input",
    HasArgument = true,
    Required = true,
    Description = "The input file."
});

manager.Add(new Option()
{
    ShortName = "o",
    LongName = "output",
    HasArgument = true,
    Required = true,
    Description = "The output file."
});

manager.Add(new Option()
{
    ShortName = "c",
    LongName = "continue",
    HasArgument = false,
    Required = false,
    Description = "Continue the application."
});

manager.Add(new Option()
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

Here's an example of how you can use cclip.net in your .NET application:

```csharp
using cclip;

internal class Program
{
    private static void Main(string[] args)
    {
        OptionsManager manager = new("application name");
        manager.Add(new() { ShortName = "v", LongName = "version", HasArgument = false, Required = false, Description = "displays the version" });
        manager.Add(new() { ShortName = "p", LongName = "print", HasArgument = true, Required = false, Description = "prints the text inputted" });
        manager.Add(new() { ShortName = "i", LongName = "input", HasArgument = true, Required = true, Description = "input path" });

        OptionsParser parser = manager.Parse(args);

        if (parser.IsPresent("version"))
        {
            Console.WriteLine("1.0.0");
        }
        else if (parser.IsPresent("print", out string print))
        {
            Console.WriteLine(print);
        }
        else if (parser.IsPresent("input", out string input))
        {
            Console.WriteLine(input);
        }
    }
}
```

# Auto Help generation
there is no need to to add a help option you can type `-h` `-?` or `--help` to display the help
![image](https://github.com/Drew-Chase/clip.net/assets/5598099/c04e16cf-2eaf-434e-98a3-c0da4c4d9147)

