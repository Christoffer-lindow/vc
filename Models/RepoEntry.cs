using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vc.Models
{
  public record RepoEntry(string FilePath, string FileName, string Extension, DateTime LastEditedOn, bool IsDirectory);
}
