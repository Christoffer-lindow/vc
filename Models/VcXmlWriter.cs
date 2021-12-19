using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace vc.Models
{
  public class VcXmlWriter : IVcXmlWriter
  {
    private const string START_DIRECTORY_ELEMENT = "directory";
    private const string ATTRIBUTE_NAME = "directory";
    private const string ATTRIBUTE_LAST_EDITED = "last_edited_on";
    private const string ATTRIBUTE_DIRECTORY = "is_directory";
    private const string ATTRIBUTE_EXTENSIONS = "extensions";
    private const string START_FILE_ELEMENT = "file";
    private XmlWriterSettings _settings;

    public VcXmlWriter()
    {
      XmlWriterSettings settings = new XmlWriterSettings();
      settings.Indent = true;
      settings.NewLineOnAttributes = true;
      _settings = settings;
    }


    public void WriteRepoFile(string path, IEnumerable<RepoEntry> entries)
    {
      XmlWriter xmlWriter = XmlWriter.Create(path, _settings);
      xmlWriter.WriteStartDocument();
      xmlWriter.WriteStartElement("entries");
      Array.ForEach(entries.ToArray(), entry => WriteElement(xmlWriter, entry));
      xmlWriter.WriteEndElement();
      xmlWriter.WriteEndDocument();
      xmlWriter.Close();
    }

    private void WriteElement(XmlWriter writer, RepoEntry entry)
    {
      if (entry.IsDirectory)
      {
        writer.WriteStartElement(START_DIRECTORY_ELEMENT);
      }
      else
      {
        writer.WriteStartElement(START_FILE_ELEMENT);
      }
      writer.WriteAttributeString(ATTRIBUTE_NAME, entry.FilePath);
      writer.WriteAttributeString(ATTRIBUTE_EXTENSIONS, entry.Extension);
      writer.WriteAttributeString(ATTRIBUTE_LAST_EDITED, entry.LastEditedOn.ToString());
      writer.WriteAttributeString(ATTRIBUTE_DIRECTORY, entry.IsDirectory.ToString());
      writer.WriteString(entry.FileName);
      writer.WriteEndElement();
    }
  }
}
