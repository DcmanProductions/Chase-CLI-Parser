// LFInteractive LLC. 2021-2024﻿

namespace Chase.CLIOptions;

/// <summary>
/// Parses arguments from the command-line
/// </summary>
public class OptionsParser
{
    private readonly OptionsManager manager;
    private readonly Dictionary<Option, string> usedArguments;

    internal OptionsParser(OptionsManager manager, string[] args)
    {
        this.manager = manager;
        usedArguments = new();
        List<string> invalidArgs = new();

        for (int i = 0; i < args.Length; i++)
        {
            try
            {
                string arg = args[i];
                string parameter = "";
                if (i < args.Length - 1)
                {
                    if (!args[i + 1].StartsWith('-'))
                    {
                        parameter = args[i + 1];
                    }
                }
                if (arg.StartsWith("--"))
                {
                    Option? option = manager.options.FirstOrDefault(i => i.LongName.Equals(arg[2..]));
                    if (option != null && option.HasValue)
                    {
                        if (option.Value.HasArgument)
                        {
                            if (!string.IsNullOrEmpty(parameter))
                            {
                                usedArguments.Add(option.Value, parameter);
                            }
                            else
                            {
                                invalidArgs.Add(arg);
                            }
                        }
                        else
                        {
                            usedArguments.Add(option.Value, "");
                        }
                    }
                    else
                    {
                        invalidArgs.Add(arg);
                    }
                }
                else if (arg.StartsWith("-"))
                {
                    Option? option = manager.options.FirstOrDefault(i => i.ShortName.Equals(arg[1..]));
                    if (option != null && option.HasValue)
                    {
                        if (option.Value.HasArgument)
                        {
                            if (!string.IsNullOrEmpty(parameter))
                            {
                                usedArguments.Add(option.Value, parameter);
                            }
                            else
                            {
                                invalidArgs.Add(arg);
                            }
                        }
                        else
                        {
                            usedArguments.Add(option.Value, "");
                        }
                    }
                    else
                    {
                        invalidArgs.Add(arg);
                    }
                }
            }
            catch
            {
            }
        }

        if (IsPresent("h"))
        {
            manager.PrintHelp();
            Environment.Exit(0);
        }
        bool isInvalid = false;
        IEnumerable<Option> missingRequiredFields = manager.options.Where(i => i.Required && !usedArguments.ContainsKey(i));
        if (missingRequiredFields.Any())
        {
            foreach (Option option in missingRequiredFields)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine($"Missing required field: -{option.ShortName} | --{option.LongName}");
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            isInvalid = true;
            Console.ResetColor();
        }
        if (invalidArgs.Any())
        {
            foreach (string field in invalidArgs)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine($"invalid field provided: {field}");
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            isInvalid = true;
            Console.ResetColor();
        }
        if (isInvalid)
        {
            Environment.Exit(1);
        }
    }

    /// <summary>
    /// Checks if the argument is present and returns the parameter
    /// </summary>
    /// <param name="arg">the arguments long or short name</param>
    /// <param name="parameter">the argument parameter</param>
    /// <returns></returns>
    public bool IsPresent(string arg, out string parameter) => usedArguments.TryGetValue(manager.options.FirstOrDefault(i => i.LongName == arg || i.ShortName == arg), out parameter);

    /// <summary>
    /// Checks if the argument is present
    /// </summary>
    /// <param name="arg">the arguments long or short name</param>
    /// <returns></returns>
    public bool IsPresent(string arg) => IsPresent(arg, out _);
}