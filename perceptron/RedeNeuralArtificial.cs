using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perceptron
{
    internal class RedeNeuralArtificial
    {
        internal RedeNeuralArtificial()
        {

        }

        internal void Iniciar()
        {
            float[] entrada = new float[] { 1, 2, 3, 4, 5 };
            float[] esperado = new float[] { 9, 8, 7, 6, 1 };

            float passos = 0.01F;
            int neuronios = 3;
            int epoch = 7000;

            var camada = GerarCamadaNeural(neuronios, entrada, esperado);

            Inferencia(camada, entrada, esperado);

        }

        internal void Inferencia(CamadaNeural camada, float[] entrada, float[] esperado)
        {
            // Entrada * Peso
            for (int i = 0; i < camada.entrada.Length; i++)
                camada.entrada[i] = camada.entrada[i] * camada.peso[i];

            // Soma dos pesos
            for (int i = 0; i < camada.entrada.Length; i++)
                camada.soma += camada.entrada[i];

            camada.soma += camada.bias;
        }

        internal CamadaNeural GerarCamadaNeural(int neuronios, float[] entrada, float[] esperado)
        {
            var camada = new CamadaNeural()
            {
                derivado = new float[neuronios],
                bias = new float[neuronios],
                ativacao = new float[neuronios],
                erro = new float[neuronios],
                esperado = esperado,
                entrada = entrada,
                peso = new float[entrada.Length],
                transf = new float[neuronios],
                soma = 0,
                saida = new float[neuronios]
            };

            for (int i = 0; i < camada.bias.Length; i++) camada.bias[i] = -2;
            for (int i = 0; i < camada.peso.Length; i++) camada.peso[i] = 1;

            return camada;
        }
    }
}
