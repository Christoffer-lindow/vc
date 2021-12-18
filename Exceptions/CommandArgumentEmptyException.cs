namespace vc.Exceptions
{
  public class CommandArgumentEmptyException : Exception
  {
    public CommandArgumentEmptyException() : base("Command argument cannot be empty")
    {
    }
  }
}
