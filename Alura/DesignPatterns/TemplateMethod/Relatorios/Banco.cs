namespace DesignPatterns.TemplateMethod.Relatorios
{
    public class Banco
    {
        public string nome;
        public string telefone;
        public string endereco;
        public string email;

        public Banco(string nome, string telefone, string endereco, string email)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.endereco = endereco;
            this.email = email;
        }
    }
}
