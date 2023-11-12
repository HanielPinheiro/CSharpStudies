namespace NeuralNetworkService
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Service service = new Service();
                service.RunSingle();
            }
            catch(InvalidOperationException iex)
            {
                Console.WriteLine(iex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}