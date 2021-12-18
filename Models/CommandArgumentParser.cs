using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using vc.Enums;
using vc.Exceptions;

namespace vc.Models
{
  public class CommandArgumentParser : ICommandArgumentParser
  {
    private const string INIT = "init";
    private const string ADD = "add";
    private const string COMMIT = "commit";
    private const string STATUS = "status";
    private const string MESSAGE = "-m";
    private const string ALL = ".";
    private readonly string _argument;
    public CommandArgumentParser(string argument)
    {
      if (String.IsNullOrEmpty(argument))
      {
        throw new CommandArgumentEmptyException();
      }
      _argument = argument;
    }

    private bool IsMessageString()
    {
      return (_argument[0] == '"' && _argument[_argument.Length - 1] == '"');
    }
    private (CommandArgumentEnum, string) CreateReturnTuple(
      CommandArgumentEnum argument) =>
      (argument, _argument);
    public (CommandArgumentEnum, string) Parse() =>
      _argument.ToLower() switch
      {
        INIT => CreateReturnTuple(CommandArgumentEnum.Init),
        ADD => CreateReturnTuple(CommandArgumentEnum.Add),
        COMMIT => CreateReturnTuple(CommandArgumentEnum.Commit),
        STATUS => CreateReturnTuple(CommandArgumentEnum.Status),
        MESSAGE => CreateReturnTuple(CommandArgumentEnum.Message),
        ALL => CreateReturnTuple(CommandArgumentEnum.All),
        _ => CreateReturnTuple(CommandArgumentEnum.MessageString)
      };

  }
}
