using DesignPatterns.Investimentos;


namespace DesignPatterns.Interfaces
{
    public enum Formato
    {
        XML,
        CSV,
        PORCENTO
    }

    public interface IFormato
    {
        IFormato FormatoSeguinte { get; set; }
        string Requisicao(Conta conta, Formato formato);
    }
}
