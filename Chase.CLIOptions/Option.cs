// LFInteractive LLC. 2021-2024
﻿namespace clip;

public struct Option
{
    public string ShortName { get; set; }
    public string LongName { get; set; }
    public bool Required { get; set; }
    public bool HasArgument { get; set; }
    public string Description { get; set; }

    public Option(string shortName, string longName, bool required, bool hasArgument, string description)
    {
        ShortName = shortName;
        LongName = longName;
        Required = required;
        HasArgument = hasArgument;
        Description = description;
    }
}