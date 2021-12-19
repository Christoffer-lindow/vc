using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace vc.Models
{
  public class VcDirectory
  {
    public List<FileInfo> Files { get; } = new();
    public List<DirectoryInfo> Directories { get; } = new();

    public VcDirectory(string[] files, string[] directories)
    {
      Array.ForEach(files, file => Files.Add(new(file)));
      Array.ForEach(directories, directory => Directories.Add(new(directory)));
    }
  }
}
