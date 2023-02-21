using DesignPatterns.Interfaces;
using DesignPatterns.Investimentos;

namespace DesignPatterns.FormatosExportar
{
    public class CSV : IFormato
    {
        public IFormato FormatoSeguinte { get; set; } = null;

        public CSV(IFormato formatoSeguinte)
        {
            FormatoSeguinte = formatoSeguinte;
        }

        public string Requisicao(Conta conta, Formato formato)
        {
            if (formato == Formato.CSV)
            {
                string separador = ";";
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
