// LFInteractive LLC. 2021-2024﻿

OptionsManager manager = new("Chase CLI Parser");
manager.Add(new() { ShortName = "i", LongName = "input", HasArgument = true, Required = true, Description = "The input file." });
manager.Add(new() { ShortName = "o", LongName = "output", HasArgument = true, Required = true, Description = "The output file." });
manager.Add(new() { ShortName = "c", LongName = "continue", HasArgument = false, Required = false, Description = "continues the application." });
manager.Add(new() { ShortName = "cc", LongName = "connections", HasArgument = true, Required = false, Description = "the number of connections of the application" });

OptionsParser parser = manager.Parse(Environment.GetCommandLineArgs());
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