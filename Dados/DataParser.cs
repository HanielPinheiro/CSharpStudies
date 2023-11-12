using Fderivs.Jobs.CblcPrecoAluguel.Model;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fderivs.Jobs.CblcPrecoAluguel.Try
{
    public class DataParser
    {
        public IEnumerable<LoanBalanceModel> SplitAndParse(string file, char separator)
        {
            string[] stringSplited = file.Split('\r');
            List<LoanBalanceModel> columns = new List<LoanBalanceModel>();
            LoanBalanceModel parsedItem = null;

            foreach (string str in stringSplited)
            {
                var strList = str.Replace("\n", "").Replace("%", "").Replace(" ", "").Replace(".", ",").Split(separator).ToList();

                if (Parser(strList, out parsedItem))
                    columns.Add(parsedItem);
            }

            return columns;
        }

        public bool Parser(List<string> strList, out LoanBalanceModel parsedItem)
        {
            parsedItem = new LoanBalanceModel();
            try
            {
                parsedItem.ACAO = strList[1];
                parsedItem.EMPRESA = strList[3];
                parsedItem.NCONTATOS = Convert.ToDouble(strList[4]);
                parsedItem.QUANTIDADE = Convert.ToDouble(strList[5]);
                parsedItem.VALOR = Convert.ToDouble(strList[6]);
                parsedItem.TAXA_D_Min = Convert.ToDouble(strList[7]) / 100.0;
                parsedItem.TAXA_D = Convert.ToDouble(strList[8]) / 100.0;
                parsedItem.TAXA_D_Max = Convert.ToDouble(strList[9]) / 100.0;
                parsedItem.TAXA_T_Min = Convert.ToDouble(strList[10]) / 100.0;
                parsedItem.TAXA_T = Convert.ToDouble(strList[11]) / 100.0;
                parsedItem.TAXA_T_max = Convert.ToDouble(strList[12]) / 100.0;
                parsedItem.DATA_ARQUIVO = Convert.ToDateTime(strList[0]);
                //parsedItem.DATA_ENTRADA = DateTime.Now;
                if (strList[13] == null || strList[13] == "")
                    parsedItem.MERCADO_NOME = "Balcao";
                else
                    parsedItem.MERCADO_NOME = strList[13];

                return true;
            }
            catch
            {
                parsedItem = null;
                return false;
            }
        }
    }
}
