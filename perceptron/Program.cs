
using perceptron;

RedeNeuralArtificial redeNeural = new ();
redeNeural.Iniciar();

return;

float[] bias = new float[1] { -2 };
float[] passos = new float[1] { 0.1F };
float[] pesos = new float[] { 1, 1 };
float[] neuronios = new float[1];
float[] erros = new float[1];
float[] grafico = new float[9];

float[] last_entrada, last_esperados;

Console.WriteLine($"Passos: {passos[0]:n2}");

bool nao_treinar = false;
bool treinar_and = false;
bool treinar_or = false;

Console.WriteLine();
while (true)
{
    try
    {
        Console.Write("Deseja treinar a máquina? (Sim, Não): ");
        var input = Console.ReadLine().ToLower();
        nao_treinar = new string[] { "não", "nao", "n" }.Any(x => x == input);

        if (!nao_treinar)
        {
            Console.Write("Escolha o modelo; função `And` (1), função `OR` (2): ");
            input = Console.ReadLine();

            treinar_and = Convert.ToSByte(input) == 1;
            treinar_or = Convert.ToSByte(input) == 2;
        }

        break;
    }
    catch (Exception ex)
    {
    }
}


if (!nao_treinar)
{
    Console.WriteLine();
    Console.WriteLine("Treinando Neorônio Perceptron");
    Console.WriteLine("-----------------------------");
    Console.WriteLine();

    if (treinar_or)
    {
        // Operador OR

        TreinarIA(new float[] { 1, 1 }, new float[] { 1 }); // 1, 1, 1
        TreinarIA(new float[] { 1, 0 }, new float[] { 1 }); // 1, 0, 1
        TreinarIA(new float[] { 0, 1 }, new float[] { 1 }); // 0, 1, 1
        TreinarIA(new float[] { 0, 0 }, new float[] { 0 }); // 0, 0, 0
    }
    if (treinar_and)
    {
        // Operador AND

        TreinarIA(new float[] { 1, 1 }, new float[] { 1 }); // 1, 1, 1
        TreinarIA(new float[] { 1, 0 }, new float[] { 0 }); // 1, 0, 0
        TreinarIA(new float[] { 0, 1 }, new float[] { 0 }); // 0, 1, 0
        TreinarIA(new float[] { 0, 0 }, new float[] { 0 }); // 0, 0, 0
    }
}

Console.WriteLine();
while (true)
{
    Console.Write("Informe valores de entrada (Ex.: 0,1,1): ");

    try
    {
        float[] input = Console.ReadLine().Split(',').Select(x => Convert.ToSingle(x)).ToArray();
        var entrada = last_entrada = input.Take(2).ToArray();
        var esperado = last_esperados = input.Skip(2).ToArray();
        var resultado = Neuronio(0, entrada, esperado);

        if (erros[0] == 1)
        {
            Console.Write("Corrigir IA? (Sim, Não): ");
            var inpt = Console.ReadLine();

            if (new string[] { "sim", "s" }.Any(x => x == inpt))
            {
                TreinarIA(last_entrada, last_esperados);
            }
        }
    }
    catch (Exception ex)
    {
    }
}

void Grafico()
{
    for (int i = 0; i < grafico.Length; i++)
    {
        grafico[i] = bias[0] - pesos[0] * (i - 4) / pesos[1];
    }
}

float[] Neuronio(int n, float[] entradas, float[] esperados)
{
    neuronios[n] = (pesos[0] * entradas[0]) + (pesos[1] * entradas[1]) + bias[0];
    
    // Função Ativação
    float[] ativacao = new float[1] {
        neuronios[0] > 0 ? 1 : 0,
    };

    Console.WriteLine($"Entradas: {entradas[0]}, {entradas[1]}");
    Console.WriteLine($"Esperado: {esperados[0]}");
    Console.WriteLine($"Saídas: {ativacao[0]}");
    Console.WriteLine($"Pesos: {pesos[0]}, {pesos[1]}");
    Console.WriteLine($"Bias: {bias[0]}");
    
    erros[n] = esperados[0] - ativacao[0];

    var tmpBack = Console.BackgroundColor;
    var tmpColor = Console.ForegroundColor;
    if (erros[n] == 0)
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.Black;
    }
    else
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.White;
    }
    Console.WriteLine($"Erro: {erros[n]}");

    Console.BackgroundColor = tmpBack;
    Console.ForegroundColor = tmpColor;

    Console.WriteLine($"Neurônio: {neuronios[n]}");

    return ativacao;
}

void TreinarIA(float[] entradas, float[] esperados)
{
    while (true)
    {
        Console.WriteLine();
        Console.WriteLine("".PadLeft(50, '-'));

        int n = 0;
        float[] ativacao = Neuronio(n, entradas, esperados);

        if (erros[n] == 1)
        {
            float[] db = new float[] {
                erros[0] * passos[0]            // Delta Bias
            };
            Console.WriteLine($"Delta Bias: {db[0]}");

            float[] dw = new float[] {      // Delta Peso
                erros[0] * passos[0] * entradas[0],     // Entrada 1
                erros[0] * passos[0] * entradas[1],     // Entrada 2
            };
            Console.WriteLine($"Delta Entradas: {dw[0]}, {dw[1]}");

            float[] new_entrada = new float[]
            {
                entradas[0] + dw[0],
                entradas[1] + dw[1]
            };
            Console.WriteLine($"New Entradas: {new_entrada[0]}, {new_entrada[1]}");

            bias[0] += db[0];
            pesos[0] += dw[0];
            pesos[1] += dw[1];

            Console.WriteLine($"New Bias: {bias[0]}");
            Console.WriteLine($"New Pesos: {pesos[0]}, {pesos[1]}");

            Grafico();
        }
        else
            break;
    }

    Console.WriteLine();
}