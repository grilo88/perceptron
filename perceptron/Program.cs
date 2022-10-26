
int[] entrada = new[] { 0, 1, 2 };

int[] pesos = new[] { 1, 1, 1 };

int[] abias = new[] { 1, 1, 1 };

int[] neuronios = new[] {
    pesos[0] * entrada[0] + abias[0],
    pesos[1] * entrada[1] + abias[1],
    pesos[2] * entrada[2] + abias[2]
};

int[] saidas = new[] {
    1,
    2,
    3
};

int[] ativacao = new[] {
    1,
    2,
    3
};

