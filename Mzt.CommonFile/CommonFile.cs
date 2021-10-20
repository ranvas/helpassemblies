using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Mzt.CommonFile
{
    public class CommonFile
    {
        public static List<string> MoveFiles(string inputFolder, string outputFolder, string filter = null, bool overwrite = false)
        {
            return MoveFiles(GetAllFileNames(inputFolder, filter, true), outputFolder, overwrite);
        }

        public static List<string> MoveFiles(IEnumerable<string> list, string folder, bool overwrite = false)
        {
            var result = new List<string>();
            foreach (var filePath in list)
            {
                try
                {
                    var filePathToMove = Path.Combine(folder, Path.GetFileName(filePath));
                    if (overwrite && File.Exists(filePathToMove))
                        File.Delete(filePathToMove);
                    new FileInfo(filePathToMove).Directory.Create();
                    File.Move(filePath, filePathToMove);
                    result.Add(filePathToMove);
                }
                catch (Exception e)
                {

                }
            }
            return result;
        }

        public static void DeleteFiles(IEnumerable<string> list, string folder)
        {
            foreach (var file in list)
            {
                if (File.Exists(file))
                    File.Delete(file);
            }
        }

        /// <summary>
        /// Get all file names from source path by filter
        /// </summary>
        /// <param name="path">Full path to search</param>
        /// <param name="filter">example "*.json"</param>
        /// <returns></returns>
        public static List<string> GetAllFileNames(string path, string filter = null, bool fullPath = false)
        {
            if (string.IsNullOrEmpty(filter))
                filter = "*.*";
            return Directory.GetFiles(path, filter)
                                     .Select(p => fullPath ? Path.GetFullPath(p) : Path.GetFileName(p))
                                     .ToList();
        }

        public static T GetObjectFromXmlFile<T>(string path)
        {
            using (var stream = File.OpenRead(path))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(stream);
            }
        }
    }
}
