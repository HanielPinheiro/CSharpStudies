using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Share.Entities
{
    public class Blob
    {
        [Key]
        public string Name { get; set; } = string.Empty;

        public string Extension { get; set; } = string.Empty;

        public byte[] Content { get; set; } = Array.Empty<byte>();

        public void GenerateBlobFromFilePath(string filepath, string name)
        {
            try
            {
                FileInfo fileInfo = new(filepath);
                long numBytes = fileInfo.Length;
                string extension = fileInfo.Extension;

                FileStream fileStream = new(filepath, FileMode.Open, FileAccess.Read);

                int bytesRead;
                byte[] buffer = new byte[2048];
                using (Stream source = File.OpenRead(filepath))
                    while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                        fileStream.Write(buffer, 0, bytesRead);

                Name = name;
                Extension = extension;
                Content = new BinaryReader(fileStream).ReadBytes((int)numBytes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
