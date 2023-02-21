using DesignPatterns.Investimentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.TemplateMethod.Relatorios
{
    public abstract class TemplateRelatorio
    {
        public void ImprimeRelatorio(Banco banco, List<Conta> contas)
        {
            Console.WriteLine(  Cabecalho(banco) + Corpo(contas) + Rodape(banco) );
        }

        protected abstract string Cabecalho(Banco banco);
        protected abstract string Corpo(List<Conta> contas);
        protected abstract string Rodape(Banco banco);
    }
}
