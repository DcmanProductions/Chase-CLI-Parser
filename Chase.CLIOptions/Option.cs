// LFInteractive LLC. 2021-2024﻿
namespace Chase.CLIOptions;

public struct Option
{
    public required string ShortName { get; set; }
    public required string LongName { get; set; }
    public required bool Required { get; set; }
    public required bool HasArgument { get; set; }
    public required string Description { get; set; }

    public Option(string shortName, string longName, bool required, bool hasArgument, string description)
    {
        ShortName = shortName;
        LongName = longName;
        Required = required;
        HasArgument = hasArgument;
        Description = description;
    }
}