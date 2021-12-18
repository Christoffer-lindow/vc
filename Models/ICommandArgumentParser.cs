using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vc.Enums;

namespace vc.Models
{
  public interface ICommandArgumentParser
  {
    CommandArgumentEnum Parse();
  }
}
