// LFInteractive LLC. 2021-2024
﻿namespace cclip;

/// <summary>
/// Represents an option.
/// </summary>
public struct Option
{
    /// <summary>
    /// The short name of the option ex: -h without the '-'.
    /// </summary>
    public string ShortName { get; set; }

    /// <summary>
    /// The long name of the option ex: --help without the '--'.
    /// </summary>
    public string LongName { get; set; }

    /// <summary>
    /// Whether the option is required.
    /// </summary>
    public bool Required { get; set; }

    /// <summary>
    /// Whether the option has an argument.
    /// </summary>
    public bool HasArgument { get; set; }

    /// <summary>
    /// The description of the option.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Option"/> struct.
    /// </summary>
    /// <param name="shortName"></param>
    /// <param name="longName"></param>
    /// <param name="required"></param>
    /// <param name="hasArgument"></param>
    /// <param name="description"></param>
    public Option(string shortName, string longName, bool required, bool hasArgument, string description)
    {
        ShortName = shortName;
        LongName = longName;
        Required = required;
        HasArgument = hasArgument;
        Description = description;
    }
}