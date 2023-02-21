using DesignPatterns.Investimentos;
using System;
using System.Collections.Generic;

namespace DesignPatterns.TemplateMethod.Relatorios
{
    public class RelatorioComplexo : TemplateRelatorio
    {

        protected override string Cabecalho(Banco banco)
        {
            return banco.nome + " - " + banco.endereco + " - " + banco.telefone + "\r\n" + "\r\n";
        }

        protected override string Corpo(List<Conta> contas)
        {
            string corpo = "";
            foreach (var conta in contas)
                corpo += conta.ToString() + "\r\n";
            return corpo;
        }

        protected override string Rodape(Banco banco)
        {
            return "\r\n" + banco.email + " - " + DateTime.Today.Date.ToString() + "\r\n" + "\r\n";
        }
    }
}
