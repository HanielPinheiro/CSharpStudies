using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDLL
{    
    public enum FileFormat
    {
        Xml = 1,
        Json = 2
    }
    internal class SaveListLikeFile<T> where T : class
    {
        public void Export(string path, FileFormat format, IEnumerable<T> data)
        {
            try
            {
                Validate(path, format, data);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Validate(string path, FileFormat format, IEnumerable<T> data)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new Exception("Caminho do arquivo não informado.");
            }
            else if (format != FileFormat.Xml)
            {
                if (format != FileFormat.Json)
                    throw new Exception("Formato de arquivo desejado não encontrado.");
                else
                    JsonFile(path, format, data);
            }
            else
            {
                XmlFile(path, format, data);
            }            
        }

        private void XmlFile(string path, FileFormat format, IEnumerable<T> data)
        {
            Console.WriteLine("Xml...");
            
            Console.WriteLine("Done");
        }

        private void JsonFile(string path, FileFormat format, IEnumerable<T> data)
        {
            Console.WriteLine("Json...");

            Console.WriteLine("Done");
        }
    }
}
