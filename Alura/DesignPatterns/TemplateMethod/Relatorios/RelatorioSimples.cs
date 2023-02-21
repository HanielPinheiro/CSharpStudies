using DesignPatterns.Investimentos;
using System.Collections.Generic;

namespace DesignPatterns.TemplateMethod.Relatorios
{
    public class RelatorioSimples : TemplateRelatorio
    {
        protected override string Cabecalho(Banco banco)
        {
            return banco.nome + "\r\n" + "\r\n";
        }

        protected override string Corpo(List<Conta> contas)
        {
            string corpo = "";
            foreach (var conta in contas)            
                corpo += "Titular: " + conta.Cliente + " Saldo: " + conta.Saldo + "\r\n";
            return corpo;
        }

        protected override string Rodape(Banco banco)
        {
            return "\r\n" + banco.telefone + "\r\n";
        }
    }
}
