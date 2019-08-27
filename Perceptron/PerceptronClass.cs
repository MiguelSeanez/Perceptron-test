using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    public class PerceptronClass
    {
        float[] weights = new float[2];
        //List<float[]> weights = new List<float[]>();
        float learningRate;

        public int sign(float n)
        {
            if (n >= 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public PerceptronClass()
        {
            for (int i = 0; i < weights.Count(); i++)
            {
                Random rnd = new Random();
                weights[i] = rnd.Next(-1, 1);
            }
        }

        public int Guess(float[] inputs)
        {
            float sum = 0;
            for (int i = 0; i < weights.Count(); i++)
            {
                sum += inputs[i] * weights[i];
            }
            int output = sign(sum);
            return output;
        }

        public void train(float[] inputs, int target)
        {
            int guess = Guess(inputs);
            int error = target - guess;
            // Tune all the weights
            for (int i = 0; i < weights.Count(); i++)
            {
                weights[i] += error * inputs[i] * learningRate;
            }
        }
    }
}
