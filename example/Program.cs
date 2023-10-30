// LFInteractive LLC. 2021-2024
﻿namespace example;

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