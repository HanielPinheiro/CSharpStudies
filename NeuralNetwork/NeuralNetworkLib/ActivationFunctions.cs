using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkLib
{
    public class ActivationFunctions
    {
        public ActivationFunctions(){}

        /// <summary>
        /// Calculate the sigmoid of a value
        /// </summary>
        /// <returns></returns>
        public double[,] CalculateSigmoid(double[,] matrix)
        {

            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    var value = matrix[i, j];
                    matrix[i, j] = 1 / (1 + Math.Exp(value * -1));
                }
            }
            return matrix;
        }

        /// <summary>
        /// Calculate the sigmoid derivative of a value
        /// </summary>
        /// <returns></returns>
        public double[,] CalculateSigmoidDerivative(double[,] matrix)
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);
            double value;

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    value = matrix[i, j];
                    matrix[i, j] = value * (1 - value);
                }
            }
            return matrix;
        }
    }
}
