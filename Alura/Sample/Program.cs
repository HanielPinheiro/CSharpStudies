using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample
{
    internal class Program
    {
        const string BASE_PATH = "D:\\UP2DATA\\Files\\Regulatory_Data\\Listed";
        const string IF_PREFIX = "InstrumentsConsolidatedFile_";
        const string OP_PREFIX = "DerivativesOpenPositionFile_";

        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                RunHistoric(DateTime.ParseExact(args[0], "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture), DateTime.ParseExact(args[1], "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture));
            }
            else
            {
                RunCurrent();
            }
        }

        #region CURRENT

        private static void RunCurrent()
        {
            var lastSearch = LoadFilesList();
            var currentSearch = SearchLatestFilesList(BASE_PATH, new string[] { IF_PREFIX, OP_PREFIX });
            var currentSearchNewItems = currentSearch.Except(lastSearch).ToList();
            if (currentSearchNewItems.Count() > 0)
            {
                SaveFilesList(currentSearch);

                //Fazer algo com o arquivio novo
                string ultimoArquivoOpenPositionParaAquelaData = currentSearchNewItems.Last(p => p.StartsWith(OP_PREFIX));
                string ultimoArquivoInstrumentsParaAquelaData = currentSearchNewItems.Last(p => p.StartsWith(IF_PREFIX));
            }
        }

        private static HashSet<string> LoadFilesList()
        {
            if (File.Exists("fileslist.index"))
            {
                return new HashSet<string>(System.IO.File.ReadAllText("fileslist.index").Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
            }
            return new HashSet<string>();
        }

        private static HashSet<string> SearchLatestFilesList(string basePath, string[] searchPrefixes)
        {
            HashSet<string> result = new HashSet<string>();
            string latestDirectoryPath = Directory.GetDirectories(basePath, "*", SearchOption.TopDirectoryOnly).OrderBy(p => p).LastOrDefault();
            foreach (var searchPrefix in searchPrefixes)
            {
                string searchPattern = searchPrefix + "*";
                foreach (var instrumentsFilename in Directory.GetFiles(latestDirectoryPath, searchPattern))
                {
                    result.Add(instrumentsFilename);
                }
            }
            return result;
        }

        private static void SaveFilesList(HashSet<string> filesList)
        {
            File.WriteAllText("fileslist.index", string.Join(Environment.NewLine, filesList));
        }

        #endregion

        #region HISTORIC

        private static void RunHistoric(DateTime startDate, DateTime endDate)
        {
            Dictionary<DateTime, HashSet<string>> indexedIFFiles = IndexFiles(BASE_PATH, IF_PREFIX);
            Dictionary<DateTime, HashSet<string>> indexedOPFiles = IndexFiles(BASE_PATH, OP_PREFIX);

            foreach (KeyValuePair<DateTime, HashSet<string>> indexedOPFile in indexedOPFiles.Where(p => p.Key >= startDate && p.Key <= endDate))
            {
                KeyValuePair<DateTime, HashSet<string>> indexedIFFile = indexedIFFiles.LastOrDefault(p => p.Key <= indexedOPFile.Key);
                
                //Fazer algo com o arquivo velho
                string ultimoArquivoOpenPositionParaAquelaData = indexedOPFile.Value.Last();
                string ultimoArquivoInstrumentsParaAquelaData = indexedIFFile.Value.Last();
            }
        }

        private static Dictionary<DateTime, HashSet<string>> IndexFiles(string basePath, string searchPrefix)
        {
            Dictionary<DateTime, HashSet<string>> result = new Dictionary<DateTime, HashSet<string>>();
            string searchPattern = searchPrefix + "*";

            IEnumerable<string> directoriesPaths = Directory.GetDirectories(basePath, "*", SearchOption.TopDirectoryOnly).OrderBy(p => p);
            foreach (var directoryPath in directoriesPaths)
            {
                foreach (var filename in Directory.GetFiles(directoryPath, searchPattern))
                {
                    string filenameDateAsString = Path.GetFileNameWithoutExtension(Path.GetFileName(filename)).Substring(searchPrefix.Length, 8);
                    DateTime filenameDate = DateTime.ParseExact(filenameDateAsString, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

                    if (!result.TryGetValue(filenameDate, out HashSet<string> resultValues))
                    {
                        resultValues = new HashSet<string>();
                        result.Add(filenameDate, resultValues);
                    }
                    resultValues.Add(filename);
                }
            }
            return result;
        }

        #endregion
    }
}
