using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vc.Models.CommandHandlers
{
  public class InitCommandHandler
  {
    private readonly string _currentWorkingFolder;
    private readonly string[] _files;
    private readonly string[] _directories;
    private const string ROOT_VC_DIRECTORY = "vc";
    private const string REPO_FILE_NAME = "vc.repo.txt";

    private string REPO_FILE_PATH => $"{_currentWorkingFolder}/{ROOT_VC_DIRECTORY}/{REPO_FILE_NAME}";

    public InitCommandHandler()
    {
      _currentWorkingFolder = Directory.GetCurrentDirectory();
      _files = Directory.GetFiles(_currentWorkingFolder);
      _directories = Directory.GetDirectories(_currentWorkingFolder);
    }

    private bool RootVcDirectoryExists() =>
      _directories.Any(directory => directory == ROOT_VC_DIRECTORY);

    private bool CreateRootVcDirectory() =>
      Directory.CreateDirectory($"{_currentWorkingFolder}/{ROOT_VC_DIRECTORY}").Exists;
    private void AddText(FileStream fs, string value)
    {
      var formattedValue = value.Replace(_currentWorkingFolder + "/", "");
      byte[] info = new UTF8Encoding(true).GetBytes(formattedValue + '\n');
      fs.Write(info, 0, info.Length);
    }
    private void InitRepoFile() =>
      File.Create($"{_currentWorkingFolder}/{ROOT_VC_DIRECTORY}/{REPO_FILE_NAME}").Close();

    private void WriteFileStructure()
    {

      using (FileStream fs = File.Open(REPO_FILE_PATH, FileMode.Create))
      {
        AddText(fs, "Files");
        Array.ForEach(_files, file => AddText(fs, file));
        AddText(fs, "\nDirectories");
        Array.ForEach(_directories, directory => AddText(fs, directory));
      }
    }
    public void Handle()
    {
      if (!RootVcDirectoryExists())
      {
        CreateRootVcDirectory();
        InitRepoFile();
      }
      WriteFileStructure();
    }
  }
}
