using DesignPatterns.Interfaces;
using DesignPatterns.Investimentos;

namespace DesignPatterns.FormatosExportar
{
    public class PORCENTO : IFormato
    {
        public IFormato FormatoSeguinte { get; set; } = null;

        public PORCENTO(IFormato formatoSeguinte)
        {
            FormatoSeguinte = formatoSeguinte;
        }

        public string Requisicao(Conta conta, Formato formato)
        {
            if (formato == Formato.PORCENTO)
            {
                string separador = "%";
                return "Cliente: " + conta.Cliente + separador +
                        "Agência: " + conta.Agencia + separador +
                        "Conta :" + conta.NumConta + separador +
                        "Saldo: " + conta.Saldo;
            }

            if (FormatoSeguinte != null)
                return FormatoSeguinte.Requisicao(conta, formato);

            return "Falha em obter requisição!";
        }
    }
}
