using System;
using vc.Enums;
using vc.Exceptions;
using vc.Models;


var commandLineArguments = new List<(CommandArgumentEnum, string)>();
foreach (var argument in args)
{
  commandLineArguments.Add(new CommandArgumentParser(argument).Parse());
}

new CommandHandler(commandLineArguments).Handle();

Console.WriteLine();

