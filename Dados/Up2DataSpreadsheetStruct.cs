using Fderivs.Util.TextDumbSerializer.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fderivs.Jobs.CblcPrecoAluguel.Model
{
    public class Up2DataSpreadsheetStruct
    {
        //Coluna no arquivo; Coluna no banco

        //public string ISIN { get; set; } // 3 ; Não tem
        public string ACAO { get; set; } //2 ; 1
        public string EMPRESA { get; set; } // 4 ; 2
        public double NCONTATOS { get; set; } //5 ; 3
        public double QUANTIDADE { get; set; } //6 ; 4
        public double VALOR { get; set; } //7 ; 5
        public double TAXA_D_Min { get; set; } //8 ; 6
        public double TAXA_D { get; set; } //9 ; 7
        public double TAXA_D_Max { get; set; } //10 ; 8
        public double TAXA_T_Min { get; set; } //11 ; 9
        public double TAXA_T { get; set; } // 12 ; 10
        public double TAXA_T_max { get; set; }//13 ; 11
        public DateTime DATA_ARQUIVO { get; set; }//1 ; 12
        public DateTime DATA_ENTRADA { get; set; } //Não tem ; 13
        public string MERCADO_NOME { get; set; } //14 ; 14
    }
}
