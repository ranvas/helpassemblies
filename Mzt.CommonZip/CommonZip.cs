using SharpCompress.Compressors;
using SharpCompress.Compressors.Deflate;
using SharpCompress.Readers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzt.CommonZip
{
    /// <summary>
    /// SharpCompress package based
    /// </summary>
    public class CommonZip
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="outputDirectory"></param>
        /// <returns></returns>
        public static int DecompressTar(string fileName, string outputDirectory)
        {
            var i = 0;
            using (Stream stream = File.OpenRead(fileName))
            {
                var reader = ReaderFactory.Open(stream);
                while (reader.MoveToNextEntry())
                {
                    if (!reader.Entry.IsDirectory)
                    {
                        i++;
                        //fix some problems with fileNames
                        var newFileName = reader.Entry.Key.Replace(':', '_');
                        reader.WriteEntryToFile(Path.Combine(outputDirectory, newFileName));
                    }
                }
            }
            return i;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="outputDirectory"></param>
        /// <param name="predicate">Predicate check if entry with current fileName is needed to extract(narrow neck)</param>
        /// <returns></returns>
        public static int DecompressTar(string fileName, string outputDirectory, Func<string, string, string, bool> predicate)
        {
            var i = 0;
            using (Stream stream = File.OpenRead(fileName))
            {
                var reader = ReaderFactory.Open(stream);
                while (reader.MoveToNextEntry())
                {
                    if (!reader.Entry.IsDirectory)
                    {
                        //fix some problems with fileNames
                        var newFileName = reader.Entry.Key.Replace(':', '_');
                        if (predicate == null || predicate(newFileName, fileName, outputDirectory))
                        {
                            reader.WriteEntryToFile(Path.Combine(outputDirectory, newFileName));
                            i++;
                        }
                    }
                }
            }
            return i;
        }

        /// <summary>
        /// Decompress GZip
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="outputDirectory"></param>
        /// <returns>extracted file</returns>
        public static string DecompressGZip(string filePath, string outputDirectory = null)
        {
            var currentFileName = Path.GetFileName(filePath);
            var newFileName = currentFileName.Remove(currentFileName.Length - Path.GetExtension(filePath).Length);
            var newFilePath = string.IsNullOrEmpty(outputDirectory) ?
                Path.Combine(Path.GetDirectoryName(filePath), newFileName) :
                Path.Combine(outputDirectory, newFileName);
            using (var inStream = File.OpenRead(filePath))
            {
                using (var decompressedFileStream = File.Create(newFilePath))
                {
                    using (var decompressionStream = new GZipStream(inStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                    }
                }
            }
            return newFilePath;
        }
    }
}
