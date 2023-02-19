using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Investimentos
{
    public interface Investimento
    {
        double RetornoSobreInvestimento(double saldo);
    }
}
