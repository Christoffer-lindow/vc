using System;
using vc.Exceptions;
using vc.Models;

foreach (var argument in args)
{
  var a = new CommandArgumentParser(argument);
  Console.WriteLine(a.Parse());
}

Console.WriteLine(args);

