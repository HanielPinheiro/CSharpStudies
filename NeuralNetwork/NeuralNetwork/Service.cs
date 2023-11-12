using NeuralNetworkLib;

namespace NeuralNetworkService
{
    public class Service
    {
        public Service() { }

        public void RunSingle()
        {
            var neuralNetwork = new NeuralNetwork(1, 3);

            Console.WriteLine("Synaptic weights before training:");
            PrintMatrix(neuralNetwork.SynapsesMatrix!);

            var trainingInputs = new double[,] { { 0, 0, 1 }, { 1, 1, 1 }, { 1, 0, 1 }, { 0, 1, 1 } };
            var trainingOutputs = new double[,] { { 0, 1, 1, 0 } };
            
            neuralNetwork.Train(trainingInputs, trainingOutputs, 10000);

            Console.WriteLine("\nSynaptic weights after training:");
            PrintMatrix(neuralNetwork.SynapsesMatrix!);

            // testing neural networks against a new problem 
            var output = neuralNetwork.Think(new double[,] { { 1, 0, 0 } });
            Console.WriteLine("\nConsidering new problem [1, 0, 0] => :");
            PrintMatrix(output);

            Console.Read();
        }

        private void PrintMatrix(double[,] matrix)
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", matrix[i, j]));
                }
                Console.Write(Environment.NewLine);
            }
        }
    }
}
