namespace DesignPatterns.Descontos
{
    public interface IDesconto
    {
        IDesconto proximoDesconto { get; set; }

        double DescontoAplicado(Compra compra);
    }
}
