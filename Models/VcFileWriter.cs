using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vc.Models
{

  public class VcFileWriter : AbstractVcFileWriter
  {
    private readonly string[] _files;
    private readonly string[] _directories;

    override public string[] GetFiles() => _files;
    override public string[] GetDirectories() => _directories;
    public VcFileWriter()
    {
      _files = Directory.GetFiles(CurrentWorkingFolder);
      _directories = Directory.GetDirectories(CurrentWorkingFolder);
    }
    override public void CreateVcRootFile() =>
      File.Create($"{CurrentWorkingFolder}/{RootVcDirectory}/{RepoFileName}").Close();


    override public void CreateVcRootDirectory() =>
      Directory.CreateDirectory($"{CurrentWorkingFolder}/{RootVcDirectory}");

    override public bool VcRootDirectoryExists()
    => _directories.Any(directory => directory == RootVcDirectory);

    override public bool VcRootFileExists()
      => File.Exists(RepoFilePath);

  }
}
