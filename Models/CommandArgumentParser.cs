using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vc.Enums;
using vc.Exceptions;

namespace vc.Models
{
  public class CommandArgumentParser : ICommandArgumentParser
  {
    private const string ADD = "add";
    private const string COMMIT = "commit";
    private const string STATUS = "status";
    private readonly string _argument;
    public CommandArgumentParser(string argument)
    {
      if (String.IsNullOrEmpty(argument))
      {
        throw new CommandArgumentEmptyException();
      }
      _argument = argument;
    }
    public CommandArgumentEnum Parse() =>
    _argument.ToLower() switch
    {
      ADD => CommandArgumentEnum.Add,
      COMMIT => CommandArgumentEnum.Commit,
      STATUS => CommandArgumentEnum.Status,
      _ => CommandArgumentEnum.Invalid
    };

  }
}
