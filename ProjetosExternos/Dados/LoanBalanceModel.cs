using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fderivs.Util.TextDumbSerializer.Attributes;

namespace Fderivs.Jobs.CblcPrecoAluguel.Model
{
    [DelimitedFather("pt-BR")]
    [Table("tb_cblc_aluguel_todosdados")]
    public class LoanBalanceModel
    {
        [DelimitedMember(3)]
        public string ISIN { get; set; }

        [Column]
        [DelimitedMember(2)]
        public string ACAO { get; set; }

        [Column]
        [DelimitedMember(1)]
        public DateTime DATA_ARQUIVO { get; set; }

        [Column]
        public DateTime DATA_ENTRADA { get; } = DateTime.Now;

        [Column]
        [DelimitedMember(4)]
        public string EMPRESA { get; set; }

        [Column]
        [DelimitedMember(5)]
        public double NCONTATOS { get; set; }

        [Column]
        [DelimitedMember(6)]
        public double QUANTIDADE { get; set; }

        [Column]
        [DelimitedMember(7)]
        public double VALOR { get; set; }

        [Column]
        [DelimitedMember(8)]
        public double TAXA_D_Min { get; set; }

        [Column]
        [DelimitedMember(9)]
        public double TAXA_D { get; set; }

        [Column]
        [DelimitedMember(10)]
        public double TAXA_D_Max { get; set; }

        [Column]
        [DelimitedMember(11)]
        public double TAXA_T_Min { get; set; }
        
        [Column]
        [DelimitedMember(12)]
        public double TAXA_T { get; set; }

        [Column]
        [DelimitedMember(13)]
        public double TAXA_T_max { get; set; }

        [Column]
        [DelimitedMember(14, "Balcao")]
        public string MERCADO_NOME { get; set; }
    }
}
