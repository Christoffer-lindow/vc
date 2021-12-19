using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace vc.Models
{
  public interface IVcXmlWriter
  {
    void WriteRepoFile(string path, IEnumerable<RepoEntry> entries);
  }
}
