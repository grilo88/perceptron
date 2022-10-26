
int[] entradas = new[] { 0, 1, 2 };
Console.WriteLine($"Entradas: {entradas[0]}, {entradas[1]}, {entradas[2]}");

int[] esperados = new int[] { 0, 1, 1 };
Console.WriteLine($"Esperados: {esperados[0]}, {esperados[1]}, {esperados[2]}");

int[] pesos = new[] { 1, 1, 1 };
Console.WriteLine($"Pesos: {pesos[0]}, {pesos[1]}, {pesos[2]}");

int[] abias = new[] { 1, 1, 1 };
Console.WriteLine($"Abias: {abias[0]}, {abias[1]}, {abias[2]}");

int[] neuronios = new[] {
    ((pesos[0] * entradas[0]) + (pesos[1] * entradas[1]) + (pesos[2] * entradas[2]) + abias[0]),
    ((pesos[0] * entradas[0]) + (pesos[1] * entradas[1]) + (pesos[2] * entradas[2]) + abias[1]),
    ((pesos[0] * entradas[0]) + (pesos[1] * entradas[1]) + (pesos[2] * entradas[2]) + abias[2])
};

Console.WriteLine($"Neurônios: {neuronios[0]}, {neuronios[1]}, {neuronios[2]}");

int[] saidas = new[] {
    neuronios[0] > 0 ? 1 : 0,
    neuronios[1] > 0 ? 1 : 0,
    neuronios[2] > 0 ? 1 : 0
};

Console.WriteLine($"Saídas: {saidas[0]}, {saidas[1]}, {saidas[2]}");
