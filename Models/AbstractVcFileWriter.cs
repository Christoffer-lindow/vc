namespace vc.Models
{
  public abstract class AbstractVcFileWriter
  {
    public static readonly string CurrentWorkingFolder = Directory.GetCurrentDirectory();
    public static readonly string RootVcDirectory = "vc";
    public static readonly string RepoFileName = "vc.repo.xml";

    public abstract string[] GetFiles();
    public abstract string[] GetDirectories();

    public static string RepoFilePath => $"{CurrentWorkingFolder}/{RootVcDirectory}/{RepoFileName}";
    public abstract bool VcRootDirectoryExists();
    public abstract bool VcRootFileExists();
    public abstract void CreateVcRootDirectory();
    public abstract void CreateVcRootFile();
  }
}
