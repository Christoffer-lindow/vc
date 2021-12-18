using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using vc.Enums;
using vc.Models.CommandHandlers;

namespace vc.Models
{
  public class CommandHandler : ICommandHandler
  {
    private readonly IEnumerable<(CommandArgumentEnum, string)> _commandArguments;
    private StringBuilder builder = new();
    private readonly string _stringRepresentation;
    private const string INIT = "Init";
    private const string ADD_ALL = "AddAll";
    private const string COMMIT_MESSAGE = "CommitMessageMessageString";
    private const string STATUS = "Status";
    public CommandHandler(IEnumerable<(CommandArgumentEnum, string)> commandArguments)
    {
      _commandArguments = commandArguments;
      StringifyArguments();
      _stringRepresentation = builder.ToString();
    }

    private void CreateRepo()
    {
      throw new NotImplementedException();
    }

    private void StringifyArguments() =>
      Array.ForEach(_commandArguments.ToArray(), (type) => builder.Append(type.Item1));

    private void HandleInit() => new InitCommandHandler().Handle();
    public void Handle()
    {
      if (String.IsNullOrEmpty(_stringRepresentation))
      {
        return;
      }
      switch (_stringRepresentation)
      {
        case INIT: HandleInit(); break;
        case ADD_ALL: Console.WriteLine("found read all"); break;
        case COMMIT_MESSAGE: Console.WriteLine("found commit message"); break;
        case STATUS: Console.WriteLine("status found"); break;
        default: Console.WriteLine(_stringRepresentation); break;
      };
    }
  }
}
