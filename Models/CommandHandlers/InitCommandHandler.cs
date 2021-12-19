using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vc.Models.CommandHandlers
{
  public class InitCommandHandler
  {
    private readonly AbstractVcFileWriter _vcFileWriter;
    private readonly IVcXmlWriter _vcXmlWriter;
    private readonly VcDirectory _vcDirectory;

    public InitCommandHandler(AbstractVcFileWriter vcFileWriter, IVcXmlWriter xmlWriter)
    {
      _vcFileWriter = vcFileWriter;
      _vcXmlWriter = xmlWriter;
      _vcDirectory = new VcDirectory(_vcFileWriter.GetFiles(), _vcFileWriter.GetDirectories());
    }

    private List<RepoEntry> GetRepoEntryList()
    {
      var repoEntries = new List<RepoEntry>();
      foreach (var item in _vcDirectory.Directories)
      {
        repoEntries.Add(new(item.FullName, item.Name, item.Extension, item.LastWriteTime, true));
      }
      foreach (var item in _vcDirectory.Files)
      {
        repoEntries.Add(new(item.FullName, item.Name, item.Extension, item.LastWriteTime, false));
      }
      return repoEntries;
    }

    public void Handle()
    {
      if (!_vcFileWriter.VcRootDirectoryExists())
      {
        _vcFileWriter.CreateVcRootDirectory();
        _vcFileWriter.CreateVcRootFile();
      }

      _vcXmlWriter.WriteRepoFile(VcFileWriter.RepoFilePath, GetRepoEntryList());
    }
  }
}
