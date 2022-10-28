using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perceptron
{
    internal struct CamadaNeural
    {
        internal float soma;
        internal float[] derivado;
        internal float[] bias;
        internal float[] esperado;
        internal float[] entrada;
        internal float[] peso;
        internal float[] transf;
        internal float[] saida;
        internal float[] ativacao;
        internal float[] erro;
    }
}
