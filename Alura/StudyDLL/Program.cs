using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDLL
{
    //Challenge is create all classes like internal
    internal class Program
    {        
        public static AnyTypesOfCollections generateData = new AnyTypesOfCollections();
        public static IEnumerable<int> data;
        public static SaveListLikeFile<IEnumerable<int>> saveListLikeFile = new SaveListLikeFile<IEnumerable<int>>();
        public static string path = @"\\fderivssv10\Folder Redirection$\haniel.pereira\Desktop\TramposHaniel\CursoUdemy\Git\Alura\ExportedFiles";

        static void Main(string[] args)
        {            
            generateData.Size = 100;
            generateData.Type = CollectionType.Array;

            Execute();
            Console.WriteLine("All done");
        }

        private static void Execute()
        {
            
            //Create a task here
            Console.WriteLine("Starting work...");

            Console.WriteLine("Generating Data");  
            data = generateData.Generate();

            Console.WriteLine("Writing Data");

            
            saveListLikeFile.Export(path, FileFormat.Xml, data);
            saveListLikeFile.Export(path, FileFormat.Xml, data);

            Console.ReadLine();

        }
    }
}
