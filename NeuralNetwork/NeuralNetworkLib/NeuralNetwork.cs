namespace NeuralNetworkLib
{
    public class NeuralNetwork
    {
        private readonly Random? randomObj;
        private readonly MatrixManipulator matrixManipulator = new MatrixManipulator();
        private readonly ActivationFunctions activationFunctions = new ActivationFunctions();

        public int SynapseMatrixColumns { get; private set; }
        public int SynapseMatrixLines { get; private set; }
        public double[,]? SynapsesMatrix { get; private set; }

        public NeuralNetwork(int synapseMatrixColumns, int synapseMatrixLines)
        {
            SynapseMatrixColumns = synapseMatrixColumns;
            SynapseMatrixLines = synapseMatrixLines;

            randomObj = new Random(1);// make sure that for every instance of the neural network we are geting the same random values
            GenerateSynapsesMatrix();
        }

        /// <summary>
        /// Generate our matrix with the weight of the synapses
        /// </summary>
        private void GenerateSynapsesMatrix()
        {
            SynapsesMatrix = new double[SynapseMatrixLines, SynapseMatrixColumns];

            for (var i = 0; i < SynapseMatrixLines; i++)            
                for (var j = 0; j < SynapseMatrixColumns; j++)                
                    SynapsesMatrix[i, j] = (2 * randomObj!.NextDouble()) - 1;
        }               

        /// <summary>
        /// Will return the outputs give the set of the inputs
        /// </summary>
        public double[,] Think(double[,] inputMatrix)
        {
            var productOfTheInputsAndWeights = matrixManipulator.MatrixDotProduct(inputMatrix, SynapsesMatrix!);

            return activationFunctions.CalculateSigmoid(productOfTheInputsAndWeights);

        }

        /// <summary>
        /// Train the neural network to achieve the output matrix values
        /// </summary>
        public void Train(double[,] trainInputMatrix, double[,] trainOutputMatrix, int interactions)
        {
            trainOutputMatrix = matrixManipulator.MatrixTranspose(trainOutputMatrix);

            // we run all the interactions
            for (var i = 0; i < interactions; i++)
            {
                // calculate the output
                var output = Think(trainInputMatrix);
                var curSigmoidDerivative = activationFunctions.CalculateSigmoidDerivative(output);

                // calculate the error
                var error = matrixManipulator.MatrixSubstract(trainOutputMatrix, output);
                var error_SigmoidDerivative = matrixManipulator.MatrixProduct(error, curSigmoidDerivative);

                // calculate the adjustment :) 
                var transpose = matrixManipulator.MatrixTranspose(trainInputMatrix);
                var adjustment = matrixManipulator.MatrixDotProduct(transpose, error_SigmoidDerivative);

                SynapsesMatrix = matrixManipulator.MatrixSum(SynapsesMatrix!, adjustment);
            }
        }        

    }
}
